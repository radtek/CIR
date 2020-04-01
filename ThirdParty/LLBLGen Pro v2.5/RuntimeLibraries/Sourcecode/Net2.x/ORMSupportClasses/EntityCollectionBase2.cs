//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2006 Solutions Design. All rights reserved.
// 
// The ORM Support classes library sourcecode is released under the following license: (BSD2)
// ----------------------------------------------------------------------
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met: 
//
// 1) Redistributions of source code must retain the above copyright notice, this list of 
//    conditions and the following disclaimer. 
// 2) Redistributions in binary form must reproduce the above copyright notice, this list of 
//    conditions and the following disclaimer in the documentation and/or other materials 
//    provided with the distribution. 
// 
// THIS SOFTWARE IS PROVIDED BY SOLUTIONS DESIGN ``AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
// INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL SOLUTIONS DESIGN OR CONTRIBUTORS BE LIABLE FOR 
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR 
// BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE 
// USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
//
// The views and conclusions contained in the software and documentation are those of the authors 
// and should not be interpreted as representing official policies, either expressed or implied, 
// of Solutions Design. 
//
//////////////////////////////////////////////////////////////////////
// Contributers to the code:
//		- Frans Bouma [FB]
//////////////////////////////////////////////////////////////////////
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Reflection;
using System.Diagnostics;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Collections.Specialized;

#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of the entity collection base class.
	/// </summary>
#if !CF
	[Serializable]
#if !MONO
	[Designer( typeof( EntityCollectionComponentDesigner ) ),
     ToolboxItem(typeof(EntityCollectionToolboxItem))]
#endif // MONO
#endif // !CF
	public abstract class EntityCollectionBase2<TEntity> : CollectionCore<TEntity>, IEntityCollection2, IXmlSerializable, IListSource, 
			IEntityCollectionAccess2
#if !CF
			,IFastSerializableEntityCollection2
#endif
		where TEntity : EntityBase2, IEntity2
	{
		#region Class Member Declarations
		private IEntityFactory2		_entityFactoryToUse;
		private IEntity2			_containingEntity;
		private	string				_containingEntityMappedField;

		[NonSerialized]
		private Context				_activeContext;
		[NonSerialized]
		private Dictionary<int, List<IEntity2>> _cachedPkHashes;
		[NonSerialized]
		private EntityView2<TEntity> _defaultView;
		[NonSerialized]
		private IEntityCollection2	 _removedEntitiesTracker;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <remarks>En</remarks>
		public EntityCollectionBase2()
		{
			base.InitCoreClass(0);

			_entityFactoryToUse = DetermineEntityFactory();
			InitClass();
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFactoryToUse">The entity factory object to use when this collection has to construct new objects.
		/// This is the case when the collection is bound to a grid-like control for example.</param>
		public EntityCollectionBase2(IEntityFactory2 entityFactoryToUse)
		{
			IEntityFactory2 toPass = entityFactoryToUse;
			if(entityFactoryToUse == null)
			{
				toPass = DetermineEntityFactory();
			}
			InitClass(toPass);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="initialContents">initial contents for this collection</param>
		public EntityCollectionBase2( IList<TEntity> initialContents ) 
			: this ()
		{
			AddRange(initialContents);
		}


		/// <summary>
		/// Private CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollectionBase2(SerializationInfo info, StreamingContext context) : base(info, context)
		{
			try
			{
				base.DeserializationInProgress=true;
				if(SerializationHelper.Optimization == SerializationOptimization.None)
				{
					_entityFactoryToUse = (IEntityFactory2)info.GetValue("_entityFactoryToUse", typeof(IEntityFactory2));
					_containingEntity = (IEntity2)info.GetValue("_containingEntity", typeof(IEntity2));
					_containingEntityMappedField = info.GetString("_containingEntityMappedField");
				}
				else
				{
					SerializationHelper.Deserialize(this, info, context);
					OnDeserialized(info, context);
				}
			}
			finally
			{
				base.DeserializationInProgress=false;
			}
		}


		/// <summary>
		/// Will add a new entity to the list, will set its parent collection property so CancelEdit will remove
		/// it from the list again, and will set its flag that it is added by databinding. 
		/// </summary>
		/// <remarks>Do not call this method from your own code. This is a databinding ONLY method.</remarks>
		/// <exception cref="InvalidOperationException">If this collection is set to ReadOnly</exception>
		public override TEntity AddNew()
		{
			if( this.IsReadOnly && !EntityCollectionComponentDesigner.InDesignMode)
			{
				throw new InvalidOperationException( "This collection is read-only." );
			}

			TEntity newEntity = (TEntity)_entityFactoryToUse.Create();
			newEntity.IsNewViaDataBinding = true;
			newEntity.ParentCollection = this;
			this.Add(newEntity);
			return newEntity;
		}


		/// <summary>
		/// Sets the entity information of the entity object containing this collection. Call this method only from
		/// entity classes which contain EntityCollection members, like 'Customer' which contains 'Orders' entity collection.
		/// </summary>
		/// <param name="containingEntity">The entity containing this entity collection as a member variable</param>
		/// <param name="fieldName">The field the related entity has mapped onto the relation which delivers the entities contained
		/// in this collection</param>
		public void SetContainingEntityInfo(IEntity2 containingEntity, string fieldName)
		{
			_containingEntity = containingEntity;
			_containingEntityMappedField = fieldName;
			this.ActiveContext = _containingEntity.ActiveContext;
			EntityBase2 containingEntityAsEntityBase2 = containingEntity as EntityBase2;
			if( containingEntityAsEntityBase2 != null )
			{
				base.Site = containingEntityAsEntityBase2.Site;
			}
			AddContainedEntitiesToContext();
		}


		/// <summary>
		/// ISerializable member. 
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{
				base.GetObjectData(info, context);
				info.AddValue("_entityFactoryToUse", _entityFactoryToUse);
				info.AddValue("_containingEntity", _containingEntity);
				info.AddValue("_containingEntityMappedField", _containingEntityMappedField);
			}
			else
			{
				SerializationHelper.Serialize(this, info, context);
				OnGetObjectData(info, context);
			}
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, a new datatable is created inside destination. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(DataSet destination)
		{
			List<IViewProjectionData> collectionProjections = new List<IViewProjectionData>();
			Dictionary<Type, IEntityCollection2> entitiesPerType = null;
			BuildCollectionProjectors(collectionProjections, out entitiesPerType);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in 
		/// this collection. Per entity type found, an entry is stored inside the destination dictionary. It will simply project every data element. 
		/// </summary>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(Dictionary<Type, IEntityCollection2> destination)
		{
			List<IViewProjectionData> collectionProjections = new List<IViewProjectionData>();
			Dictionary<Type, IEntityCollection2> entitiesPerType = null;
			BuildCollectionProjectors(collectionProjections, out entitiesPerType);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}
		
		
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Dictionary<Type, IEntityCollection2> entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}


		/// <summary>
		/// Creates a hierarchical projection of all the data in this view and for each type in the complete graph found starting with each entity in this view,
		/// using the viewProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		public void CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection2> destination)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			Dictionary<Type, IEntityCollection2> entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);

			CreateHierarchicalProjectionInternal(collectionProjections, destination, entitiesPerType);
		}

		
		/// <summary>
		/// Builds the collection projectors for this collection.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void BuildCollectionProjectors(List<IViewProjectionData> collectionProjections, out Dictionary<Type, IEntityCollection2> entitiesPerType)
		{
			ObjectGraphUtils graphUtils = new ObjectGraphUtils();
			entitiesPerType = graphUtils.ProduceCollectionsPerTypeFromGraph(this);
			foreach(KeyValuePair<Type, IEntityCollection2> pair in entitiesPerType)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance(pair.Key);
				// build projectors. Only project fields.
				List<IEntityPropertyProjector> projectors = EntityFields2.ConvertToProjectors(dummy.Fields);
				ViewProjectionData<EntityBase2> projector = new ViewProjectionData<EntityBase2>(projectors, null, true, pair.Key);
				collectionProjections.Add(projector);
			}
		}


		/// <summary>
		/// Creates the hierarchical projection for the entities per type passed in into the destination specified.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void CreateHierarchicalProjectionInternal(List<IViewProjectionData> collectionProjections, DataSet destination,
			Dictionary<Type, IEntityCollection2> entitiesPerType)
		{
			destination.Tables.Clear();
			Dictionary<Type, List<IEntityRelation>> relationsPerType = new Dictionary<Type, List<IEntityRelation>>();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection2 toProject = null;
				if(!entitiesPerType.TryGetValue(projectionData.TypeOfTargetEntity, out toProject))
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = new EntityCollectionNonGeneric(dummy.GetEntityFactory());
				}
				DataTable resultsTable = new DataTable(dummy.LLBLGenProEntityName);
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsTable, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Tables.Add(resultsTable);
				int numberOfPkFields = FieldUtilities.DetermineNumberOfPkFields(dummy.PrimaryKeyFields);
				if(numberOfPkFields>0)
				{
					DataColumn[] pkColumns = new DataColumn[numberOfPkFields];
					for(int i = (dummy.PrimaryKeyFields.Count - numberOfPkFields), j = 0; j < numberOfPkFields; j++)
					{
						IEntityField2 primaryKeyField = dummy.PrimaryKeyFields[i + j];
						pkColumns[j] = resultsTable.Columns[primaryKeyField.Name];
					}
					resultsTable.PrimaryKey = pkColumns;
				}
			}

			// create datarelations. 
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				// has to be there.
				List<IEntityRelation> relations = relationsPerType[projectionData.TypeOfTargetEntity];
				// create datarelations. 
				projectionData.CreateDataRelations(destination, relations);
			}
		}


		/// <summary>
		/// Creates the hierarchical projection for the entities per type passed in into the destination specified.
		/// </summary>
		/// <param name="collectionProjections">The collection projections.</param>
		/// <param name="destination">The destination.</param>
		/// <param name="entitiesPerType">Type of the entities per.</param>
		private void CreateHierarchicalProjectionInternal(List<IViewProjectionData> collectionProjections, 
				Dictionary<Type, IEntityCollection2> destination, Dictionary<Type, IEntityCollection2> entitiesPerType)
		{
			destination.Clear();
			Dictionary<Type, List<IEntityRelation>> relationsPerType = new Dictionary<Type, List<IEntityRelation>>();
			foreach(IViewProjectionData projectionData in collectionProjections)
			{
				IEntity2 dummy = (IEntity2)Activator.CreateInstance(projectionData.TypeOfTargetEntity);
				relationsPerType[projectionData.TypeOfTargetEntity] = dummy.GetAllRelations();

				IEntityCollection2 toProject = null;
				if(!entitiesPerType.TryGetValue(projectionData.TypeOfTargetEntity, out toProject))
				{
					// no entity of this type found in the graph. Use an empty collection instead.
					toProject = new EntityCollectionNonGeneric(dummy.GetEntityFactory());
				}
				EntityCollectionNonGeneric resultsCollection = new EntityCollectionNonGeneric(dummy.GetEntityFactory());
				toProject.DefaultView.CreateProjection(projectionData.Projectors, resultsCollection, projectionData.AllowDuplicates, projectionData.AdditionalFilter);
				destination.Add(dummy.GetType(), resultsCollection);
			}
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView()
		{
			return CreateView(null, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter)
		{
			return CreateView(filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter, ISortExpression sorter)
		{
			return CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView2 on this collection</returns>
		public IEntityView2 CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
		{
			return new EntityView2<TEntity>(this, filter, sorter, dataChangeAction);
		}


		/// <summary>
		/// Sorts the collection.
		/// </summary>
		/// <param name="fieldIndex">Field to sort on</param>
		/// <param name="direction">the sort direction</param>
		/// <param name="comparerToUse">The comparer to use. If null, it will use the default comparer.</param>
		/// <remarks>For backwards compatibility.</remarks>
		public override void Sort( int fieldIndex, ListSortDirection direction, IComparer<object> comparerToUse )
		{
			if( this.Count <= 0 )
			{
				return;
			}

			if( (fieldIndex < 0) || (fieldIndex >= this[0].Fields.Count) )
			{
				return;
			}

			PropertyDescriptor descriptor = TypeDescriptor.GetProperties( this[0].GetType() )[this[0].Fields[fieldIndex].Name];
			Sort( descriptor, direction, comparerToUse );
		}

		
		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(out string entityCollectionXml)
		{
			WriteXml(XmlFormatAspect.None, "EntityCollection", out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(string rootNodeName, out string entityCollectionXml)
		{
			WriteXml(XmlFormatAspect.None, rootNodeName, out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML, recursively. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, out string entityCollectionXml)
		{
			WriteXml(aspects, "EntityCollection", out entityCollectionXml);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="entityCollectionXml">The complete outer XML as string, representing this complete entity object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, out string entityCollectionXml)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			using(MemoryStream stream = new MemoryStream())
			{
				XmlWriter writer = XmlWriter.Create(stream, settings);
				WriteXml(writer, aspects, rootNodeName);
				writer.Close();
				stream.Seek(0, SeekOrigin.Begin);
				using(StreamReader reader = new StreamReader(stream))
				{
					entityCollectionXml = reader.ReadToEnd();
					reader.Close();
				}
				stream.Close();
			}
		}
		

		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(XmlFormatAspect.None, "EntityCollection", parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(XmlFormatAspect.None, rootNodeName, parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. Uses "EntityCollection" for the rootnode name
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			WriteXml(aspects, "EntityCollection", parentDocument, out entityCollectionNode);
		}


		/// <summary>
		/// Converts this entity collection to XML. 
		/// </summary>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="parentDocument">the XmlDocument which will contain the node this method will create. This document is required
		/// to create the new node object</param>
		/// <param name="entityCollectionNode">The XmlNode representing this complete entitycollection object, including containing data.</param>
		public void WriteXml(XmlFormatAspect aspects, string rootNodeName, XmlDocument parentDocument, out XmlNode entityCollectionNode)
		{
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.OmitXmlDeclaration = true;
			using(MemoryStream stream = new MemoryStream())
			{
				XmlWriter writer = XmlWriter.Create(stream, settings);
				WriteXml(writer, aspects, rootNodeName);
				writer.Close();
				stream.Seek(0, SeekOrigin.Begin);
				XmlDocument tmpDoc = new XmlDocument();
				tmpDoc.Load(stream);
				entityCollectionNode = parentDocument.ImportNode(tmpDoc.FirstChild, true);
				stream.Close();
			}
		}


		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		public void WriteXml(XmlWriter writer, XmlFormatAspect aspects)
		{
			WriteXml(writer, aspects, "EntityCollection");
		}


		/// <summary>
		/// Converts this entity collection to XML
		/// </summary>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		public void WriteXml(XmlWriter writer, XmlFormatAspect aspects, string rootNodeName)
		{
			EntityCollection2Xml(rootNodeName, writer, new Dictionary<Guid, IEntity2>(), aspects, true, true);
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="xmlData">string with Xml data which should be read into this entity collection and its members. This string has to be in the
		/// correct format and should be loadable into a new XmlDocument without problems</param>
		public void ReadXml(string xmlData)
		{
			using(MemoryStream stream = new MemoryStream())
			{
				StreamWriter writer = new StreamWriter(stream);
				writer.Write(xmlData);
				writer.Flush();
				stream.Seek(0, SeekOrigin.Begin);
				XmlReader reader = XmlReader.Create(stream);
				XmlFormatAspect format = XmlHelper.GetXmlFormat(reader);
				switch(format)
				{
					case XmlFormatAspect.Compact25:
						ReadXml(reader, format);
						break;
					case XmlFormatAspect.Compact:
					case XmlFormatAspect.None:
						// read into doc, use xmldocument route.
						XmlDocument tmpDoc = new XmlDocument();
						tmpDoc.Load(reader);
						ReadXml(tmpDoc.DocumentElement, format);
						break;
				}

				reader.Close();
				stream.Close();
				writer.Close();
			}
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity collection and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		public void ReadXml(XmlNode node)
		{
			ReadXml(node.OuterXml);
		}


		/// <summary>
		/// Will fill the entity collection and its containing members (recursively) with the data stored in the XmlNode passed in. The XmlNode has to
		/// be filled with Xml in the format written by IEntityCollection2.WriteXml() and the Xml has to be compatible with the structure of this entity collection.
		/// </summary>
		/// <param name="node">XmlNode with Xml data which should be read into this entity collection and its members. Node's root element is the root element
		/// of the entity collection's Xml data</param>
		/// <param name="format">The format.</param>
		private void ReadXml(XmlNode node, XmlFormatAspect format)
		{
			if(format == XmlFormatAspect.Compact25)
			{
				ReadXml(node);
			}
			List<NodeEntityReference> nodeEntityReferences = new List<NodeEntityReference>();
			Dictionary<Guid, IEntity2> processedObjectIDs = new Dictionary<Guid, IEntity2>();
			Xml2EntityCollection(node, processedObjectIDs, nodeEntityReferences);

			// walk all references found and set them to the correct objects.
			XmlHelper.SetReadReferences(nodeEntityReferences, processedObjectIDs);
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">Reader with xml used to produce an object graph</param>
		public void ReadXml(XmlReader reader)
		{
			// do format check 
			ReadXml(reader, XmlHelper.GetXmlFormat(reader));
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="format">The format the xml of the reader is in.</param>
		public void ReadXml(XmlReader reader, XmlFormatAspect format)
		{
			List<NodeEntityReference> nodeEntityReferences = new List<NodeEntityReference>();
			Dictionary<Guid, IEntity2> processedObjectIDs = new Dictionary<Guid, IEntity2>();

			switch(format)
			{
				case XmlFormatAspect.Compact25:
					Xml2EntityCollection(reader, processedObjectIDs, nodeEntityReferences);
					XmlHelper.SetReadReferences(nodeEntityReferences, processedObjectIDs);
					break;
				case XmlFormatAspect.Compact:
				case XmlFormatAspect.None:
					// read into doc, use xmldocument route.
					XmlDocument tmpDoc = new XmlDocument();
					tmpDoc.Load(reader);
					ReadXml(tmpDoc.DocumentElement);
					break;
			}
		}


		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities,
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="emitFactory">if set to true, the XML will contain the factory name, otherwise it won't. Used in Compact25 format</param>
		/// <param name="isRootElement">if set to true, the start element produced is the absolute root element of the xml to produce.</param>
		internal void EntityCollection2Xml( string rootNodeName, XmlWriter writer, Dictionary<Guid, IEntity2> processedObjectIDs, XmlFormatAspect aspects, 
						bool emitFactory, bool isRootElement)
		{
			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.EntityCollection2Xml", "Method Enter" );

			bool compactXml = ((aspects & XmlFormatAspect.Compact) == XmlFormatAspect.Compact);
			bool compact25Xml = ((aspects & XmlFormatAspect.Compact25) == XmlFormatAspect.Compact25);
			bool verboseXml = !(compact25Xml || compactXml);
			bool datesInXmlDataType = ((aspects & XmlFormatAspect.DatesInXmlDataType) == XmlFormatAspect.DatesInXmlDataType);
			bool mlInCDataBlocks = ((aspects & XmlFormatAspect.MLTextInCDataBlocks) == XmlFormatAspect.MLTextInCDataBlocks);
			if(compact25Xml && compactXml)
			{
				// only one allowed
				compactXml = false;
			}

			writer.WriteStartElement(rootNodeName);  // root node
			if(compact25Xml)
			{
				if((this.EntityFactoryToUse != null) && emitFactory)
				{
					// write factory as attribute in start element.
					writer.WriteAttributeString("Factory", FieldUtilities.CreateFullTypeName(this.EntityFactoryToUse.GetType()));
				}
				if(isRootElement)
				{
					writer.WriteAttributeString("Format", "Compact25");
				}
			}
			if(verboseXml)
			{
				// add assembly and type as attributes to root node
				writer.WriteAttributeString("Assembly", this.GetType().Assembly.FullName);
				writer.WriteAttributeString("Type", this.GetType().FullName);
			}

			if(!compact25Xml)
			{
				writer.WriteStartElement("Entities");	// <Entities> element. 
			}

			// write all entity elements
			for( int i = 0; i < this.Count; i++ )
			{
				EntityBase2 entity = (EntityBase2)this[i];
				entity.Entity2Xml(entity.LLBLGenProEntityName, writer, processedObjectIDs, aspects, false);
			}
			if(!compact25Xml)
			{
				writer.WriteEndElement();	// </Entities> element
			}

			if(!compact25Xml)
			{
				writer.WriteStartElement("EntityFactoryToUse");		// <EntityFactoryToUse> element
				if(this.EntityFactoryToUse == null)
				{
					writer.WriteAttributeString("Assembly", "Unknown");
				}
				else
				{
					writer.WriteAttributeString("Assembly", this.EntityFactoryToUse.GetType().Assembly.FullName);
					writer.WriteAttributeString("Type", this.EntityFactoryToUse.GetType().FullName);
				}
				writer.WriteEndElement();		// </EntityFactoryToUse>

				if(verboseXml && (this.ConcurrencyPredicateFactoryToUse != null))
				{
					writer.WriteStartElement("ConcurrencyPredicateFactoryToUse");	// <ConcurrencyPredicateFactoryToUse>
					writer.WriteAttributeString("Assembly", this.ConcurrencyPredicateFactoryToUse.GetType().Assembly.FullName);
					writer.WriteAttributeString("Type", this.ConcurrencyPredicateFactoryToUse.GetType().FullName);
					writer.WriteEndElement();	// </ConcurrencyPredicateFactoryToUse>
				}
			}

			// append the rest of the properties to the root element. Do this via reflection. 
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( this.GetType() );
#if CF
			PropertyInfo[] propertyInfos = this.GetType().GetProperties();
			Hashtable propertyInfoHT = new Hashtable(propertyInfos.Length);
			foreach(PropertyInfo pinfo in propertyInfos)
			{
				propertyInfoHT.Add(pinfo.Name, pinfo);
			}
#endif
			Dictionary<string, object> propertyNamesToExclude = new Dictionary<string, object>();
			propertyNamesToExclude.Add("ConcurrencyPredicateFactoryToUse", null);
			propertyNamesToExclude.Add("EntityFactoryToUse", null);

			for( int i = 0; i < properties.Count; i++ )
			{
				if(propertyNamesToExclude.ContainsKey(properties[i].Name))
				{
					continue;
				}

#if !CF
				if( properties[i].Attributes.Contains(new XmlIgnoreAttribute()))
				{
					// ignore this property
					continue;
				}
#else
				PropertyInfo currentPropertyInfo = (PropertyInfo)propertyInfoHT[properties[i].Name];
				object[] customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(XmlIgnoreAttribute), true);
				if(customAttributes.Length>0)
				{
					// ignore
					continue;
				}
#endif
				// Normal not yet handled property. Add it, if appropriate
				if( compactXml || compact25Xml )
				{
					// only IBindingList.Allow* properties are added, or properties which are marked with the IncludeInCompactXmlAttribute attribute.
#if CF
					customAttributes = currentPropertyInfo.GetCustomAttributes(typeof(IncludeInCompactXmlAttribute), true);
					bool includeInXml = (customAttributes.Length > 0);
#else
					bool includeInXml = properties[i].Attributes.Contains( new IncludeInCompactXmlAttribute() );
#endif
					switch(properties[i].Name)
					{
						case "AllowNew":
						case "AllowEdit":
						case "AllowRemove":
						case "DoNotPerformAddIfPresent":
							if(compact25Xml)
							{
								// excluded
								continue;
							}
							break;
						default:
							if(!includeInXml)
							{
								continue;
							}
							break;
					}
				}
				writer.WriteStartElement(properties[i].Name);	// <propertyName>
				XmlHelper.WriteValueAsStringToXml(properties[i].PropertyType, properties[i].GetValue(this), verboseXml, !compact25Xml, writer, datesInXmlDataType, mlInCDataBlocks);
				writer.WriteEndElement();		// </propertyName>
			}

			if(compact25Xml)
			{
				// emit state element
				BitVector32 stateFlags = new BitVector32();
				stateFlags[1] = this.AllowEdit;
				stateFlags[2] = this.AllowNew;
				stateFlags[4] = this.AllowRemove;
				stateFlags[8] = this.DoNotPerformAddIfPresent;

				writer.WriteStartElement("_lps");		// <_lps>
				writer.WriteAttributeString("f", stateFlags.Data.ToString());
				writer.WriteEndElement();	// </_lps>
			}

			writer.WriteEndElement(); // root node

			TraceHelper.WriteLineIf( TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.EntityCollection2Xml", "Method Exit" );
		}

		
		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// It will produce "EntityCollectionBase2", if the passed in switch flag is false, to prevent performance loss due to
		/// reflection activity for trace results which will never be seen.
		/// </summary>
		/// <param name="switchFlag">switch flag. If this flag is false, "EntityCollectionBase2" will be returned</param>
		/// <returns></returns>
		internal string GetEntityCollectionDescription( bool switchFlag )
		{
			if( !switchFlag || this.DeserializationInProgress)
			{
				return "EntityCollectionBase2";
			}

			StringBuilder description = new StringBuilder( 256 );
			description.AppendFormat( null, "\r\n\tEntityCollection: {0}.", this.GetType().FullName );
			if( this.EntityFactoryToUse != null )
			{
				description.AppendFormat( null, "\tWill contain entities of type: {0}\r\n", this.EntityFactoryToUse.Create().LLBLGenProEntityName );
			}
			if( _containingEntity != null )
			{
				description.AppendFormat( null, "\tContained in: {0}", ((EntityBase2)_containingEntity).GetEntityDescription( switchFlag ) );
			}

			return description.ToString();
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data.
		/// </summary>
		/// <param name="reader">The reader to read xml from.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		/// <remarks>Assumes Compact25 formatted xml is present in the reader.</remarks>
		internal void Xml2EntityCollection(XmlReader reader, Dictionary<Guid, IEntity2> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlReader..)", "Method Enter");
				this.DeserializationInProgress = true;

				if(reader.ReadState == ReadState.Initial)
				{
					reader.Read();
					if(reader.NodeType == XmlNodeType.XmlDeclaration)
					{
						reader.Read();
					}
				}

				// reader has to be on a start element.
				if(reader.NodeType != XmlNodeType.Element)
				{
					throw new ORMGeneralOperationException(
							string.Format("The Xml deserialization routine EntityCollectionBase2.Xml2EntityCollection encountered a problem: the reader passed in isn't positioned on a valid Xml element but on the element of type '{0}' and name '{1]'.", reader.NodeType.ToString(), reader.LocalName));
				}

				string startElementName = reader.LocalName;

				// position is on first node. 
				string factoryTypeName = reader.GetAttribute("Factory");
				if(factoryTypeName!=null)
				{
					this.EntityFactoryToUse = (IEntityFactory2)Activator.CreateInstance(Type.GetType(factoryTypeName));
				}

				if(this.EntityFactoryToUse == null)
				{
					throw new ORMGeneralOperationException("There's no entity factory set nor defined in the XML. Can't deserialize entity collection XML.");
				}

				// read childnodes. 
				int index = -1;
				while(reader.Read() && !((reader.LocalName==startElementName) && (reader.NodeType==XmlNodeType.EndElement)))
				{
					switch(reader.NodeType)
					{
						case XmlNodeType.Element:
							if(reader.LocalName == "_lps")
							{
								// llblgen pro state block
								int flagValues = Convert.ToInt32(reader.GetAttribute("f"));
								BitVector32 stateFlags = new BitVector32(flagValues);
								this.AllowEdit = stateFlags[1];
								this.AllowNew = stateFlags[2];
								this.AllowRemove = stateFlags[4];
								this.DoNotPerformAddIfPresent = stateFlags[8];
								if(!reader.IsEmptyElement)
								{
									// read away the end element.
									reader.Read();
								}
							}
							else
							{
								index++;
								// entity start node
								string refID = reader.GetAttribute("Ref");
								if(refID != null)
								{
									// entity we've already seen
									NodeEntityReference newReference = new NodeEntityReference();
									newReference.ObjectID = new Guid(refID);
									newReference.PropertyHoldingInstance = this;
									newReference.IsCollectionAdd = true;
									newReference.Position = index;
									newReference.ReferencingProperty = null;
									nodeEntityReferences.Add(newReference);
									if(!reader.IsEmptyElement)
									{
										reader.Read();	// read away the end node as the reader is still positioned on the end node.
									}
								}
								else
								{
									TEntity newEntity = null;
									string entityTypeValueAsString = reader.GetAttribute("EntityType");
									if(entityTypeValueAsString != null)
									{
										newEntity = (TEntity)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsString));
									}
									else
									{
										newEntity = (TEntity)this.EntityFactoryToUse.Create();
									}
									newEntity.IsDeserializing = true;
									try
									{
										newEntity.Xml2Entity(reader, processedObjectIDs, nodeEntityReferences);
										this.Add(newEntity);
									}
									finally
									{
										newEntity.IsDeserializing = false;
									}
								}
							}
							break;
						case XmlNodeType.EndElement:
							// can't encounter end elements.
							if(reader.LocalName != startElementName)
							{
								throw new ORMGeneralOperationException(
									string.Format("The Xml deserialization routine EntityCollectionBase2.Xml2EntityCollection encountered a problem: the reader encountered an unexpected EndElement, with name '{0}'.", reader.LocalName));
							}
							break;
					}
				}
			}
			finally
			{
				this.DeserializationInProgress = false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlReader...", "Method Exit");
			}
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		/// <remarks>Assumes Verbose or Compact formatted xml is present in the reader</remarks>
		internal void Xml2EntityCollection(XmlNode node, Dictionary<Guid, IEntity2> processedObjectIDs, List<NodeEntityReference> nodeEntityReferences)
		{
			try
			{
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlNode...", "Method Enter");

				this.DeserializationInProgress = true;
				XmlHelper typeConverter = new XmlHelper();

				// get this instance's properties.
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(this.GetType());

				// we need the factory FIRST. Grab that factory specification, then move on to the rest of the nodes.
				XmlNamespaceManager nsmgr = null;
				string nsprefix = string.Empty;
				if(node.NamespaceURI.Length>0)
				{
					// has namespace specified. As .NET has some nice XML bugs, we have to specify a 
					// namespace manager and a fake prefix.
					nsmgr = new XmlNamespaceManager(node.OwnerDocument.NameTable);
					if(node.Prefix.Length<=0)
					{
						// use fake ns
						nsprefix = "col";
					}
					else
					{
						nsprefix = node.Prefix;
					}
					nsmgr.AddNamespace(nsprefix, node.NamespaceURI);
					nsprefix += ":";
				}
#if CF
				XmlNode entityFactoryElement = XmlCFUtilities.SelectSingleNode(node, "EntityFactoryToUse");
#else
				XmlNode entityFactoryElement = node.SelectSingleNode(nsprefix + "EntityFactoryToUse", nsmgr);
#endif
				if(entityFactoryElement==null)
				{
					// serious problem, abort
					return;
				}
				string entityFactoryAssemblyName = entityFactoryElement.Attributes["Assembly"].Value;
				if(entityFactoryAssemblyName!="Unknown")
				{
					Assembly entityFactoryAssembly = Assembly.Load(entityFactoryAssemblyName);
					string entityFactoryClassType = entityFactoryElement.Attributes["Type"].Value;
					this.EntityFactoryToUse = (IEntityFactory2)entityFactoryAssembly.CreateInstance(entityFactoryClassType);
				}

				// then walk the subnodes and process only the direct childs, skipping entity collections and entity references.
				foreach(XmlNode currentElement in node.ChildNodes)
				{
					switch(currentElement.Name)
					{
						case "Entities":
							// first test if this node is empty
							if(currentElement.ChildNodes.Count<=0)
							{
								// is empty
								continue;
							}

							int currentEntityInCollectionIndex = -1;

							// get all child nodes and de-serialize them one by one.
							XmlNodeList entityNodes = currentElement.ChildNodes;
							foreach(XmlNode entityNode in entityNodes)
							{
								currentEntityInCollectionIndex++;

								// check if this node is a reference node
								if(entityNode.Name=="ProcessedObjectReference")
								{
									NodeEntityReference newReference = new NodeEntityReference();
									newReference.ObjectID = new Guid(entityNode.Attributes["ObjectID"].Value);
									newReference.PropertyHoldingInstance = this;
									newReference.IsCollectionAdd=true;
									newReference.Position = currentEntityInCollectionIndex;
									newReference.ReferencingProperty = null;
									nodeEntityReferences.Add(newReference);
									// done with this node.
									continue;
								}

								TEntity referencedEntity = null;
								if(entityNode.Attributes.GetNamedItem("Assembly")==null)
								{								
									// check if there's an attribute 'EntityType'. 
									XmlNode entityTypeValueAsNode = entityNode.Attributes.GetNamedItem("EntityType");
									if(entityTypeValueAsNode != null)
									{
										referencedEntity = (TEntity)this.EntityFactoryToUse.CreateEntityFromEntityTypeValue(Convert.ToInt32(entityTypeValueAsNode.Value));
									}
									else
									{
										referencedEntity = (TEntity)this.EntityFactoryToUse.Create();
									}
								}
								else
								{
									// get type and assembly for entity instance.
									string entityAssemblyName = entityNode.Attributes["Assembly"].Value;
									string entityTypeName = entityNode.Attributes["Type"].Value;
									// load assembly
									Assembly entityAssembly = Assembly.Load(entityAssemblyName);
									// create instance
									referencedEntity = (TEntity)entityAssembly.CreateInstance( entityTypeName );
								}
								referencedEntity.IsDeserializing=true;
								try
								{
									// convert this entity's xml into data inside this entity
									referencedEntity.Xml2Entity(entityNode, processedObjectIDs, nodeEntityReferences);
									// add to collection.
									this.Add(referencedEntity);
								}
								finally
								{
									referencedEntity.IsDeserializing=false;
								}
							}
							break;
						case "ConcurrencyPredicateFactoryToUse":
							// this node is not present in compact XML
							string cpFactoryAssemblyName = currentElement.Attributes["Assembly"].Value;
							if(cpFactoryAssemblyName=="Unknown")
							{
								// no factory object set nor serialized
								continue;
							}
							Assembly cpFactoryAssembly = Assembly.Load(cpFactoryAssemblyName);
							string cpFactoryClassType = currentElement.Attributes["Type"].Value;
							this.ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)cpFactoryAssembly.CreateInstance(cpFactoryClassType);
							break;
						case "EntityFactoryToUse":
							// already processed before this loop.
							break;
						default:
							// custom property, not a field.
							string elementTypeName = string.Empty;
							if(currentElement.Attributes.GetNamedItem("Type")==null)
							{
								elementTypeName = properties[currentElement.Name].PropertyType.UnderlyingSystemType.FullName.ToString();
							}
							else
							{
								elementTypeName = currentElement.Attributes["Type"].Value;
							}
							string xmlValue = currentElement.InnerText;
							PropertyDescriptor descriptor = properties[currentElement.Name];
							if(descriptor != null)
							{
								descriptor.SetValue(this, typeConverter.XmlValueToObject(elementTypeName, xmlValue));
							}
							break;
					}
				}
			}
			finally
			{
				this.DeserializationInProgress = false;
				TraceHelper.WriteLineIf(TraceHelper.GeneralSwitch.TraceInfo, "EntityCollectionBase2.Xml2EntityCollection(XmlNode...", "Method Exit");
			}
		}

		#region ICollectionMaintenance explicit implementations
		/// <summary>
		/// Removes the passed in entity from the collection without notifying the entity to remove that it has been removed from this collection.
		/// </summary>
		/// <param name="toRemove">To remove.</param>
		void ICollectionMaintenance.SilentRemove( IEntityCore toRemove )
		{
			base.SilentRemove( (TEntity)toRemove );
		}

		/// <summary>
		/// Raises the list changed event, with the parameters passed in.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <param name="typeOfChange">The type of change.</param>
		void ICollectionMaintenance.RaiseListChanged( int index, ListChangedType typeOfChange )
		{
			base.OnListChanged( index, typeOfChange );
		}

		/// <summary>
		/// Gets or sets a value indicating whether [surpress list changed events].
		/// </summary>
		/// <value>
		/// 	<c>true</c> if [surpress list changed events]; otherwise, <c>false</c>.
		/// </value>
		bool ICollectionMaintenance.SurpressListChangedEvents
		{
			get { return base.SurpressListChangedEventsInternal; }
			set { base.SurpressListChangedEventsInternal = value; }
		}

		/// <summary>
		/// Resets the CachedPkHashes. 
		/// </summary>
		void ICollectionMaintenance.ResetCachedPkHashes()
		{
			_cachedPkHashes = null;
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		void ICollectionMaintenance.Clear()
		{
			this.Clear();
		}


		/// <summary>
		/// Gets / sets the DeserializationInProgress flag.
		/// </summary>
		bool ICollectionMaintenance.DeserializationInProgress 
		{
			get { return this.DeserializationInProgress; }
			set { this.DeserializationInProgress = value; }
		}

		/// <summary>
		/// Gets the entity collection description. This string is used in verbose trace messages.
		/// </summary>
		/// <param name="switchFlag">switch flag.</param>
		/// <returns></returns>
		string ICollectionMaintenance.GetEntityCollectionDescription( bool switchFlag )
		{
			return this.GetEntityCollectionDescription( switchFlag );
		}

		/// <summary>
		/// Creates a dummy instance using the entity factory stored in an inherited collection. This dummy instance is then used to produce
		/// property descriptors.
		/// </summary>
		/// <returns>
		/// Dummy instance of entity contained in this collection, using the set factory.
		/// </returns>
		IEntityCore ICollectionMaintenance.CreateDummyInstance()
		{
			if( _entityFactoryToUse == null )
			{
				return null;
			}
			else
			{
				return _entityFactoryToUse.Create();
			}
		}

		#endregion

		#region IEntityCollectionAccess2 Explicit implementation
		/// <summary>
		/// Produces the actual XML for this entity collection, recursively. Because it recurses through contained entities,
		/// it keeps track of which objects are processed so cyclic references are not resulting in cyclic recursion and thus a crash.
		/// </summary>
		/// <param name="rootNodeName">name of root element to use when building a complete XML representation of this entity collection.</param>
		/// <param name="writer">The writer to write the output to.</param>
		/// <param name="processedObjectIDs">Hashtable with ObjectIDs of all the objects already processed. If an entity's ObjectID is in the
		/// hashtable's key list, a ProcessedObjectReference tag is emitted and the entity will not recurse further.</param>
		/// <param name="aspects">The aspect flags to control the format of the XML produced</param>
		/// <param name="emitFactory">if set to true, the XML will contain the factory name, otherwise it won't. Used in Compact25 format</param>
		/// <param name="isRootElement">if set to true, the start element produced is the absolute root element of the xml to produce.</param>
		void IEntityCollectionAccess2.EntityCollection2Xml(string rootNodeName, XmlWriter writer, Dictionary<Guid, IEntity2> processedObjectIDs,
						XmlFormatAspect aspects, bool emitFactory, bool isRootElement)
		{
			this.EntityCollection2Xml(rootNodeName, writer, processedObjectIDs, aspects, emitFactory, isRootElement);
		}


		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data. 
		/// </summary>
		/// <param name="node">current node which points to an entity collection node.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		void IEntityCollectionAccess2.Xml2EntityCollection( XmlNode node, Dictionary<Guid, IEntity2> processedObjectIDs,
				List<NodeEntityReference> nodeEntityReferences )
		{
			this.Xml2EntityCollection( node, processedObjectIDs, nodeEntityReferences );
		}
		
		/// <summary>
		/// Performs the actual conversion from Xml to entity collection data.
		/// </summary>
		/// <param name="reader">The reader to read xml from.</param>
		/// <param name="processedObjectIDs">ObjectID's of all entities instantiated</param>
		/// <param name="nodeEntityReferences">list with all the references to entity objects we probably do not yet have instantiated. This list
		/// is traversed after the xml tree has been processed. (not done by this routine, but by the caller)</param>
		/// <remarks>Assumes Compact25 formatted xml is present in the reader.</remarks>
		void IEntityCollectionAccess2.Xml2EntityCollection(XmlReader reader, Dictionary<Guid, IEntity2> processedObjectIDs,
				List<NodeEntityReference> nodeEntityReferences)
		{
			this.Xml2EntityCollection(reader, processedObjectIDs, nodeEntityReferences);
		}
				
		/// <summary>
		/// Gets the cached pk hashes, if available, otherwise null
		/// </summary>
		/// <returns></returns>
		Dictionary<int, List<IEntity2>> IEntityCollectionAccess2.GetCachedPkHashes()
		{
			return this.CachedPkHashes;
		}

		/// <summary>
		/// Sets the cached pk hashes to the passed dictionary
		/// </summary>
		/// <param name="pkHashes">The pk hashes.</param>
		void IEntityCollectionAccess2.SetCachedPkHashes( Dictionary<int, List<IEntity2>> pkHashes )
		{
			this.CachedPkHashes = pkHashes;
		}
		#endregion


		/// <summary>
		/// Performs the set related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the setrelated entity action on.</param>
		protected override void PerformSetRelatedEntity( TEntity entity )
		{
			if( (_containingEntity != null) && !EntityCollectionComponentDesigner.InDesignMode )
			{
				entity.SetRelatedEntity( _containingEntity, _containingEntityMappedField );
			}
		}

		/// <summary>
		/// Performs the unset related entity action on the passed in entity. This action is delegated to an inheritor.
		/// </summary>
		/// <param name="entity">The entity to perform the unsetrelated entity action on.</param>
		protected override void PerformUnsetRelatedEntity( TEntity entity )
		{
			if( (_containingEntity != null) && !EntityCollectionComponentDesigner.InDesignMode )
			{
				entity.UnsetRelatedEntity( _containingEntity, _containingEntityMappedField );
			}
		}

		/// <summary>
		/// Performs the add action to the active context for this collection
		/// </summary>
		/// <param name="entity">The entity.</param>
		protected override void PerformAddToActiveContext( TEntity entity )
		{
			if( _activeContext != null )
			{
				_activeContext.Add( entity );
			}
		}


		/// <summary>
		/// Gets the entity description for the entity passed in.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="switchFlag">if true, the method will produce TEntity.GetEntityDescription, otherwise it's a no-op</param>
		/// <returns></returns>
		protected override string GetEntityDescription( TEntity entity, bool switchFlag )
		{
			if(this.DeserializationInProgress)
			{
				return "EntityBase2";
			}
			return ((EntityBase2)entity).GetEntityDescription( switchFlag );
		}


		/// <summary>
		/// Places the item in the set RemovedEntitiesTracker.
		/// </summary>
		/// <param name="item">The item to add to the tracker.</param>
		protected override void PlaceInRemovedEntitiesTracker(TEntity item)
		{
			// if there's no tracker, return. Also if the entity is still in the collection, don't add it, because the tracker is used for
			// tracking entities to delete. As the entity is still in the collection, it can't be deleted from the db, as it's still present in the
			// collection. This is a safety check, to make sure that when a user does this:
			// myOrder.Customer = myCustomer;
			// myCustomer.Orders.Add(myOrder);// A
			// at line A, myOrder is already in myCustomer.Orders, because LLBLGen Pro syncs relations. Re-adding it will dereference myOrder first, making it
			// getting removed from myCustomer.Orders, then it gets re-added, and resynced. 
			if((_removedEntitiesTracker == null) || this.Contains(item))
			{
				return;
			}

			item.MarkedForDeletion = true;
			_removedEntitiesTracker.Add(item);
		}


		/// <summary>
		/// Adds the contained entities to the active set context.
		/// </summary>
		protected virtual void AddContainedEntitiesToContext()
		{
			if(_activeContext==null)
			{
				return;
			}

			foreach(IEntity2 containedEntity in this)
			{
				if(containedEntity.ActiveContext==null)
				{
					_activeContext.Add(containedEntity);
				}
			}
		}


		/// <summary>
		/// Determines the entity factory based on TEntity's value.
		/// </summary>
		/// <returns>the entity factory to set</returns>
		private IEntityFactory2 DetermineEntityFactory()
		{
			IEntityFactory2 toReturn = null;

			// create the entityfactory, as none is supplied, IF possible.
			Type typeOfContainedEntity = typeof(TEntity);
			if(!typeOfContainedEntity.IsAbstract)
			{
				TEntity dummy = Activator.CreateInstance(typeOfContainedEntity) as TEntity;
				toReturn = dummy.CallCreateEntityFactory();
			}

			return toReturn;
		}


		/// <summary>
		/// Inits the class
		/// </summary>
		/// <param name="entityFactoryToUse">The EntityFactory2 to use when creating entity objects when a bound control is adding a new entity.</param>
		private void InitClass(IEntityFactory2 entityFactoryToUse)
		{
			base.InitCoreClass(0);
			_entityFactoryToUse = entityFactoryToUse;
			InitClass();
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		private void InitClass()
		{
			_containingEntity = null;
			_containingEntityMappedField = string.Empty;
			_activeContext = null;
			_cachedPkHashes = null;
			_defaultView = null;
			_removedEntitiesTracker = null;
		}

		
		#region IEntityCollection2 members
		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, a new datatable is created inside destination.
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dataset in which the projection result is stored. Each DataTable has the name of the entity contained,
		/// e.g. "CustomerEntity". DataRelations are created between the data if applicable.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void IEntityCollection2.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, DataSet destination)
		{
			this.CreateHierarchicalProjection(collectionProjections, destination);
		}

		/// <summary>
		/// Creates a hierarchical projection of all the data in this collection and for each type in the complete graph found starting with each entity in this collection,
		/// using the collectionProjections data passed in. Per entity type found, an entry is stored inside the destination dictionary. 
		/// </summary>
		/// <param name="collectionProjections">The projection data per entity type</param>
		/// <param name="destination">The destination dictionary in which the projection result is stored.</param>
		/// <remarks>destination is cleared before a projection is performed.</remarks>
		void IEntityCollection2.CreateHierarchicalProjection(List<IViewProjectionData> collectionProjections, Dictionary<Type, IEntityCollection2> destination)
		{
			this.CreateHierarchicalProjection(collectionProjections, destination);
		}


		/// <summary>
		/// Gets all indices of all the entities in the current order of this collection which match the passed in filter. 
		/// </summary>
		/// <param name="filter">The filter the entity has to match with. If null, all entities match and every index is returned</param>
		/// <returns>List of indices of all entities matching the filter</returns>
		List<int> IEntityCollection2.FindMatches( IPredicate filter )
		{
			return base.FindMatches( filter );
		}

		/// <summary>
		/// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
		/// </summary>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only. </exception>
		void IEntityCollection2.Clear()
		{
			this.Clear();
		}

		/// <summary>
		/// Adds an IEntity2 object to the list.
		/// </summary>
		/// <param name="entityToAdd">Entity2 to add</param>
		/// <returns>Index in list</returns>
		int IEntityCollection2.Add( IEntity2 entityToAdd )
		{
			TEntity entity = entityToAdd as TEntity;
			if( entity != null )
			{
				this.Add( entity );
				return this.Count - 1;
			}
			else
			{
				throw new ArgumentException( "entityToAdd isn't of the right type" );
			}
		}

		/// <summary>
		/// Adds the range of objects passed in. Objects have to be IEntity2 implementing objects
		/// </summary>
		/// <param name="c">Collection to add</param>
		void IEntityCollection2.AddRange(IEntityCollection2 c)
		{
			ICollection<TEntity> collection = c as ICollection<TEntity>;
			if(collection != null)
			{
				this.AddRange(collection);
			}
			else
			{
				throw new ArgumentException("c isn't of the right type");
			}
		}

		/// <summary>
		/// Inserts an IEntity2 on position Index
		/// </summary>
		/// <param name="index">Index where to insert the Object Entity</param>
		/// <param name="entityToAdd">Entity2 to insert</param>
		void IEntityCollection2.Insert( int index, IEntity2 entityToAdd )
		{
			TEntity entity = entityToAdd as TEntity;
			if( entity != null )
			{
				this.Insert( index, entity );
			}
			else
			{
				throw new ArgumentException( "entityToAdd isn't of the right type" );
			}
		}

		/// <summary>
		/// Remove given IEntity2 instance from the list.
		/// </summary>
		/// <param name="entityToRemove">Entity2 object to remove from list.</param>
		void IEntityCollection2.Remove( IEntity2 entityToRemove )
		{
			TEntity entity = entityToRemove as TEntity;
			if( entity != null )
			{
				this.Remove( entity );
			}
			else
			{
				throw new ArgumentException( "entityToRemove isn't of the right type" );
			}

		}

		/// <summary>
		/// Returns true if the list contains the given IEntity2 Object
		/// </summary>
		/// <param name="entityToFind">Entity2 object to check.</param>
		/// <returns>true if Entity2 exists in list.</returns>
		bool IEntityCollection2.Contains( IEntity2 entityToFind )
		{
			TEntity entity = entityToFind as TEntity;
			if( entity != null )
			{
				return this.Contains( entity );
			}
			else
			{
				throw new ArgumentException( "entityToFind isn't of the right type" );
			}
		}

		/// <summary>
		/// Returns index in the list of given IEntity2 object.
		/// </summary>
		/// <param name="entityToFind">Entity2 Object to check</param>
		/// <returns>index in list.</returns>
		int IEntityCollection2.IndexOf( IEntity2 entityToFind )
		{
			TEntity entity = entityToFind as TEntity;
			if( entity != null )
			{
				return this.IndexOf( entity );
			}
			else
			{
				throw new ArgumentException( "entityToFind isn't of the right type" );
			}
		}

		/// <summary>
		/// copy the complete list of IEntity2 objects to an array of IEntity objects.
		/// </summary>
		/// <param name="destination">Array of IEntity2 Objects wherein the contents of the list will be copied.</param>
		/// <param name="index">Start index to copy from</param>
		void IEntityCollection2.CopyTo( IEntity2[] destination, int index )
		{
			TEntity[] dest = destination as TEntity[];
			if( dest != null )
			{
				this.CopyTo( dest, index );
			}
			else
			{
				throw new ArgumentException( "destination isn't of the right type" );
			}
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with no filter nor sorter applied.
		/// </summary>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 IEntityCollection2.CreateView()
		{
			return this.CreateView(null, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter applied
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 IEntityCollection2.CreateView(IPredicate filter)
		{
			return this.CreateView(filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 IEntityCollection2.CreateView(IPredicate filter, ISortExpression sorter)
		{
			return this.CreateView(filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter);
		}


		/// <summary>
		/// Creates a new EntityView2 object of the right type on this collection with the passed in filter and sorter applied to it and the 
		/// dataChangeAction set to the passed in value.
		/// </summary>
		/// <param name="filter">The filter.</param>
		/// <param name="sorter">The sorter.</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		/// <returns>new EntityView2 on this collection</returns>
		IEntityView2 IEntityCollection2.CreateView(IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction)
		{
			return this.CreateView(filter, sorter, dataChangeAction);
		}


		/// <summary>
		/// Returns a readonly collection of entities which are flagged as dirty.
		/// This collection is determined on the fly, you can use this collection to remove dirty entities from this entity collection.
		/// </summary>
		/// <value></value>
		List<IEntity2> IEntityCollection2.DirtyEntities
		{
			get 
			{
				List<IEntity2> toReturn = new List<IEntity2>();
				List<TEntity> tmpDirtyEntities = this.DirtyEntities;
				foreach( IEntity2 entity in tmpDirtyEntities )
				{
					toReturn.Add( entity );
				}

				return toReturn;
			}
		}
		
		/// <summary>
		/// Gets or sets the <see cref="IEntity2"/> at the specified index.
		/// </summary>
		/// <value></value>
		IEntity2 IEntityCollection2.this[int index]
		{
			get { return this[index]; }
			set
			{
				TEntity toSet = value as TEntity;
				if( toSet != null )
				{
					this[index] = toSet;
				}
				else
				{
					throw new ArgumentException( "value isn't of the right type" );
				}
			}
		}

		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is a new instance every time this property is read. It's a new entity view without a 
		/// filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		IEntityView2 IEntityCollection2.DefaultView
		{
			get { return this.DefaultView; }
		}


		/// <summary>
		/// Gets / sets the initial capacity of the entity collection. 
		/// </summary>
		int IEntityCollection2.Capacity
		{
			get { return this.Capacity; }
			set { this.Capacity = value; }
		}
		#endregion

		#region IListSource members
		/// <summary>
		/// Gets a value indicating whether the collection is a collection of <see cref="T:System.Collections.IList"></see> objects.
		/// </summary>
		/// <value></value>
		/// <returns>true if the collection is a collection of <see cref="T:System.Collections.IList"></see> objects; otherwise, false.</returns>
		[Browsable( false ), XmlIgnore]
		public bool ContainsListCollection
		{
			get { return false; }
		}

		/// <summary>
		/// Returns an <see cref="T:System.Collections.IList"></see> that can be bound to a data source from an object that does not implement an <see cref="T:System.Collections.IList"></see> itself.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.IList"></see> that can be bound to a data source from the object.
		/// </returns>
		public System.Collections.IList GetList()
		{
			return this.DefaultView;
		}
		#endregion
		
		#region IXmlSerializable Members

		/// <summary>
		/// Constructs the XML output from the object graph which has this object as the root. 
		/// </summary>
		/// <param name="writer">Writer to which the xml is written to</param>
		/// <remarks>Uses XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType.</remarks>
		public virtual void WriteXml(XmlWriter writer)
		{
			WriteXml(writer, XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType);
		}

		/// <summary>
		/// Produce the schema, always return null, as the XmlSerializer object otherwise can't handle our code.
		/// </summary>
		/// <returns></returns>
		public System.Xml.Schema.XmlSchema GetSchema()
		{
			return null;
		}


		/// <summary>
		/// Constructs an object graph with this object as the root from the xml contained by the passed in XmlReader object.
		/// </summary>
		/// <param name="reader">Reader with xml used to produce an object graph</param>
		/// <remarks>Uses XmlFormatAspect.Compact25 | XmlFormatAspect.MLTextInCDataBlocks | XmlFormatAspect.DatesInXmlDataType. Xml data should have been
		/// produced with WriteXml(writer) or a similar routine which is able to produce similar formatted XML</remarks>
		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			// assume compact25, as the IXmlSerializable.Writer implemenation writes Compact25 xml, bypasses version check.
			bool methodNodeStartRead = false;
			if(reader.ReadState != ReadState.Initial)
			{
				// read away method node
				reader.Read();
				methodNodeStartRead = true;
			}
			string startElementName = reader.LocalName; 
			this.ReadXml(reader, XmlFormatAspect.Compact25);
			if((reader.NodeType == XmlNodeType.EndElement) && (reader.LocalName == startElementName))
			{
				// read away end element of entity and position on next element
				reader.Read();
			}
			if(methodNodeStartRead)
			{
				// read away end node of start element which was read.
				reader.Read();
			}
		}

		#endregion
#if !CF
		#region Optimized Serialization related code.
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <param name="parseEntityList">If set to true, serialization flags are parsed</param>
		/// <param name="includeEntityMemberCollections">If set to true, entity menber collections are included as well.</param>
		/// <returns>Bitvector with the serialization flags</returns>
		internal BitVector32 GetSerializationFlags(bool parseEntityList, bool includeEntityMemberCollections)
		{
			BitVector32 flags = new BitVector32();
			flags[SerializationHelper.CollectionNotHasEntityFactoryMask] = (_entityFactoryToUse == null);
			flags[SerializationHelper.CollectionNotAllowNewMask] = !AllowNew;
			flags[SerializationHelper.CollectionNotAllowRemoveMask] = !AllowRemove;
			flags[SerializationHelper.CollectionNotAllowEditMask] = !AllowEdit;
			flags[SerializationHelper.CollectionReadOnlyMask] = IsReadOnly;
			flags[SerializationHelper.CollectionDoNotPerformAddIfPresentMask] = DoNotPerformAddIfPresent;
			flags[SerializationHelper.CollectionHasEntitiesMask] = Count != 0;
			flags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask] = (ConcurrencyPredicateFactoryToUse != null);

			if(parseEntityList && flags[SerializationHelper.CollectionHasEntitiesMask])
			{
				bool entityTypesAreCommon = AreEntityTypesCommon();
				flags[SerializationHelper.CollectionHasCommonEntityTypesMask] = entityTypesAreCommon;
				if(entityTypesAreCommon)
				{
					IEntityFactory2 commonEntityFactory = EntityFactoryCache2.GetEntityFactory(this[0] as EntityBase2);
					flags[SerializationHelper.CollectionIsCommonEntityFactoryCollectionEntityFactoryMask] =
							((_entityFactoryToUse != null) && (commonEntityFactory.GetType() == _entityFactoryToUse.GetType()));
				}

				bool hasDependentRelatedEntities = false;
				bool hasDependingRelatedEntities = false;
				bool hasPopulatedMemberCollectionEntities = !includeEntityMemberCollections;

				foreach(TEntity entity in this)
				{
					if(!hasDependingRelatedEntities)
					{
						hasDependingRelatedEntities = entity.GetDependingRelatedEntities().Count != 0;
					}
					if(!hasDependentRelatedEntities)
					{
						hasDependentRelatedEntities = entity.GetDependentRelatedEntities().Count != 0;
					}
					if(!hasPopulatedMemberCollectionEntities)
					{
						hasPopulatedMemberCollectionEntities = entity.HasPopulatedMemberEntityCollections();
					}

					// Quick exit once we have all the information we need
					if(hasDependentRelatedEntities && hasDependingRelatedEntities && hasPopulatedMemberCollectionEntities) 
					{
						break;
					}
				}

				flags[SerializationHelper.CollectionHasEntitiesWithDependentRelatedEntitiesMask] = hasDependentRelatedEntities;
				flags[SerializationHelper.CollectionHasEntitiesWithDependingRelatedEntitiesMask] = hasDependingRelatedEntities;
				if(includeEntityMemberCollections)
				{
					flags[SerializationHelper.CollectionHasEntitiesWithPopulatedMemberCollectionsMask] = hasPopulatedMemberCollectionEntities;
				}
			}
			return flags;
		}


		/// <summary>
		/// Method which restores owned data - i.e. considered private to this collection
		/// and not shared with any external object
		/// </summary>
		/// <param name="writer">SerializationWriter</param>
		/// <param name="context">The serialization flags (previously constructed)</param>
		protected virtual void SerializeOwnedData(SerializationWriter writer, object context)
		{
			BitVector32 serializationFlags = (BitVector32)context;

			if(!serializationFlags[SerializationHelper.CollectionNotHasEntityFactoryMask])
			{
				writer.WriteTokenizedObject(EntityFactoryCache2.GetEntityFactory(_entityFactoryToUse), true);
			}

			if(serializationFlags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask])
			{
				writer.WriteTokenizedObject(ConcurrencyPredicateFactoryToUse, false);
			}
		}


		/// <summary>
		/// Method which restores owned data - i.e. considered private to this entity
		/// and not shared with any external object
		/// </summary>
		/// <param name="reader">The SerializationReader containing the serialized data</param>
		/// <param name="context">The serialization flags (previously read)</param>
		protected virtual void DeserializeOwnedData(SerializationReader reader, object context)
		{
			BitVector32 serializationFlags = (BitVector32)context;

			IsReadOnly = serializationFlags[SerializationHelper.CollectionReadOnlyMask];
			AllowNew = !serializationFlags[SerializationHelper.CollectionNotAllowNewMask];
			AllowRemove = !serializationFlags[SerializationHelper.CollectionNotAllowRemoveMask];
			AllowEdit = !serializationFlags[SerializationHelper.CollectionNotAllowEditMask];
			DoNotPerformAddIfPresent = serializationFlags[SerializationHelper.CollectionDoNotPerformAddIfPresentMask];

			if(!serializationFlags[SerializationHelper.CollectionNotHasEntityFactoryMask])
			{
				_entityFactoryToUse = (IEntityFactory2)reader.ReadTokenizedObject();
			}

			if(serializationFlags[SerializationHelper.CollectionHasConcurrencyPredicateFactoryMask])
			{
				ConcurrencyPredicateFactoryToUse = (IConcurrencyPredicateFactory)reader.ReadTokenizedObject();
			}
		}


		/// <summary>
		/// Ares the entity types common.
		/// </summary>
		/// <returns></returns>
		private bool AreEntityTypesCommon()
		{
			if(this.Count == 0)
			{
				return false;
			}
			if(this.Count == 1) 
			{
				return true;
			}

			Type entityType = this[0].GetType();

			// Check in reverse order - quicker exit if sorted by type
			for(int i = this.Count - 1; i > 0; i--)
			{
				if(this[i].GetType() != entityType)
				{
					return false;
				}
			}
			return true;
		}

		#region IFastSerializableEntityCollection2
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <param name="parseEntityList">If set to true, serialization flags are parsed</param>
		/// <param name="includeEntityMemberCollections">If set to true, entity menber collections are included as well.</param>
		/// <returns>Bitvector with the serialization flags</returns>
		BitVector32 IFastSerializableEntityCollection2.GetSerializationFlags(bool parseEntityList, bool includeEntityMemberCollections)
		{
			return GetSerializationFlags(parseEntityList, includeEntityMemberCollections);
		}

		/// <summary>
		/// Adds the specified entity.
		/// </summary>
		/// <param name="entity">The entity.</param>
		void IFastSerializableEntityCollection2.Add(EntityBase2 entity)
		{
			Add((TEntity)entity);
		}

		/// <summary>
		/// Inits the class
		/// </summary>
		void IFastSerializableEntityCollection2.InitClassInternal()
		{
			base.InitCoreClass(0);
			InitClass();
		}
		
		/// <summary>
		/// Gets or sets the containing entity mapped field
		/// </summary>
		/// <value></value>
		string IFastSerializableEntityCollection2.ContainingEntityMappedFieldInternal
		{
			get { return _containingEntityMappedField; }
			set { _containingEntityMappedField = value; }
		}
		#endregion IFastSerializableEntityCollection2

		#region IOwnedDataSerializable
		/// <summary>
		/// Lets the implementing class store internal data directly into a SerializationWriter.
		/// </summary>
		/// <param name="writer">The SerializationWriter to use</param>
		/// <param name="context">Optional context to use as a hint as to what to store (BitVector32 is useful)</param>
		void IOwnedDataSerializable.SerializeOwnedData(SerializationWriter writer, object context)
		{
			SerializeOwnedData(writer, context);
		}

		/// <summary>
		/// Lets the implementing class retrieve internal data directly from a SerializationReader.
		/// </summary>
		/// <param name="reader">The SerializationReader to use</param>
		/// <param name="context">Optional context to use as a hint as to what to retrieve (BitVector32 is useful)</param>
		void IOwnedDataSerializable.DeserializeOwnedData(SerializationReader reader, object context)
		{
			DeserializeOwnedData(reader, context);
		}
		#endregion
		#endregion
#endif
		#region Class Property Declarations
		/// <summary>
		/// The EntityFactory2 to use when creating entity objects when bound to a grid and AddNew is enabled.
		/// </summary>
		public IEntityFactory2 EntityFactoryToUse 
		{
			get { return _entityFactoryToUse; }
			set { _entityFactoryToUse = value;}
		}


		/// <summary>
		/// Gets / sets the active context this entity collection is in. Setting this property is not adding the entity collection to the context, 
		/// it will make contained entities be added to the passed in context. If the entity collection is already in a context, setting this property has no effect. 
		/// Setting this property is done by framework code, use the Context's Add/Get methods to work with contexts and entity collections.
		/// </summary>
		[XmlIgnore]
		public Context ActiveContext 
		{ 
			get { return _activeContext;}
			set 
			{ 
				if( ((_activeContext==null)&&(value!=null)) || ((_activeContext!=null)&&(value==null)))
				{
					if((_activeContext == null) && (value != null))
					{
						// set the dupe prevention flag. 
						DoNotPerformAddIfPresent = true;
					}
					_activeContext = value;
					AddContainedEntitiesToContext();
				}
			}
		}

		/// <summary>
		/// Returns true if this collection contains dirty objects. If this collection contains dirty objects, an 
		/// already filled collection should not be refreshed until a save is performed. This property is calculated in real time
		/// and can be time consuming when the collection contains a lot of objects. Use this property only in cases when the value
		/// of this property is used to do a refetch or not.
		/// </summary>
		[XmlIgnore]
		public bool ContainsDirtyContents
		{
			get
			{
				for( int i = 0; i < this.Count; i++ )
				{
					if( this[i].Fields.IsDirty )
					{
						return true;
					}
				}
				return false;
			}
		}
		
		/// <summary>
		/// Gets the default view for this entitycollection. The returned value is the same instance every time this property is read. 
		/// It's an entity view without a filter or a sorter.
		/// </summary>
		/// <value>The default view.</value>
		[Browsable( false ), XmlIgnore]
		public EntityView2<TEntity> DefaultView
		{
			get 
			{
				if( _defaultView == null )
				{
					_defaultView = new EntityView2<TEntity>(this);
				}
				return _defaultView;
			}
		}


		/// <summary>
		/// Gets or sets the entity collection which should be used as removed entities tracker. If this property is set to an IEntityCollection2 instance,
		/// all entities which are removed from this collection are marked for deletion and placed in this removed entities tracker collection.
		/// This collection can then later on be used to delete these entities from the database in one go.
		/// </summary>
		[Browsable(false), XmlIgnore]
		public IEntityCollection2 RemovedEntitiesTracker
		{
			get { return _removedEntitiesTracker; }
			set { _removedEntitiesTracker = value; }
		}


		/// <summary>
		/// Gets / sets the CachedPkHashes. This is a dictionary with the PK hashes for the entities in this collection. This is set during a 
		/// prefetch path fetch, to cache already calculated PK side hashes.
		/// </summary>
		[Browsable( false ), XmlIgnore]
		internal Dictionary<int, List<IEntity2>> CachedPkHashes
		{
			get
			{
				return _cachedPkHashes;
			}
			set
			{
				_cachedPkHashes = value;
			}
		}

		#endregion
	}
}
