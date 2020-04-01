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
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Reflection;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// EntityView provides 'view' capabilities for an entity collection. This class supports filtering and sorting in-memory,
	/// using type safe objects. Binding an entity collection to a grid or other complex databinding control will actually make the control
	/// bind to an instance of this class.
	/// </summary>
	/// <remarks>Selfservicing specific</remarks>
	public class EntityView<TEntity> : EntityViewBase<TEntity>, IEntityView
		where TEntity : EntityBase, IEntity
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="relatedCollection">entity collection which is the data-container for the data viewed through this view.</param>
		public EntityView( EntityCollectionBase<TEntity> relatedCollection )
			: this( relatedCollection, null, null, PostCollectionChangeAction.ReapplyFilterAndSorter )
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="relatedCollection">entity collection which is the data-container for the data viewed through this view.</param>
		/// <param name="filter">The filter to apply</param>
		public EntityView( EntityCollectionBase<TEntity> relatedCollection, IPredicate filter )
			: this( relatedCollection, filter, null, PostCollectionChangeAction.ReapplyFilterAndSorter )
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="relatedCollection">entity collection which is the data-container for the data viewed through this view.</param>
		/// <param name="sorter">The sorter to apply</param>
		public EntityView( EntityCollectionBase<TEntity> relatedCollection, ISortExpression sorter )
			: this( relatedCollection, null, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter )
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="relatedCollection">entity collection which is the data-container for the data viewed through this view.</param>
		/// <param name="filter">The filter to apply</param>
		/// <param name="sorter">The sorter to apply</param>
		public EntityView( EntityCollectionBase<TEntity> relatedCollection, IPredicate filter, ISortExpression sorter )
			: this( relatedCollection, filter, sorter, PostCollectionChangeAction.ReapplyFilterAndSorter )
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="relatedCollection">entity collection which is the data-container for the data viewed through this view.</param>
		/// <param name="filter">The filter to apply</param>
		/// <param name="sorter">The sorter to apply</param>
		/// <param name="dataChangeAction">The data change action to take if data in the related collection changes.</param>
		public EntityView( EntityCollectionBase<TEntity> relatedCollection, IPredicate filter, ISortExpression sorter, PostCollectionChangeAction dataChangeAction )
		{
			if( relatedCollection == null )
			{
				throw new ArgumentNullException( "relatedCollection can't be null" );
			}
			base.InitClassCore( relatedCollection, filter, sorter, dataChangeAction );
		}


		/// <summary>
		/// Copies all entities in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <returns>New collection with all entities in this view</returns>
		public EntityCollectionBase<TEntity> ToEntityCollection()
		{
			return ToEntityCollection( 0 );
		}


		/// <summary>
		/// Copies all entities starting at startIndex in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <param name="startIndex">The start index for the interval to copy to the entity collection</param>
		/// <returns>
		/// New collection with all entities in this view
		/// </returns>
		public virtual EntityCollectionBase<TEntity> ToEntityCollection( int startIndex )
		{
			// check index specified. Only valid if there are actually instances in the view.
			if((startIndex < 0) || ((startIndex >= this.Count) && (this.Count>0)))
			{
				throw new ArgumentOutOfRangeException( "startIndex", "The specified index is outside the range of the available indices in this view." );
			}

			EntityCollectionBase<TEntity> toReturn = (EntityCollectionBase<TEntity>)Activator.CreateInstance(this.RelatedCollectionInternal.GetType());

			for( int i = startIndex; i < this.Count; i++ )
			{
				toReturn.Add( this[i] );
			}

			return toReturn;
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination )
		{
			this.CreateProjection( propertyProjectors, destination, true, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		public virtual void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates, IPredicate filter )
		{
			IEntityDataProjector projector = new DataProjectorToDataTable( destination );
			base.CreateProjection( propertyProjectors, allowDuplicates, filter, projector );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination )
		{
			this.CreateProjection( propertyProjectors, destination, false, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set. 
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		public virtual void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination, bool allowDuplicates, IPredicate filter )
		{
			IEntityDataProjector projector = new DataProjectorToIEntityCollection( (IEntityCollection)destination );
			base.CreateProjection( propertyProjectors, allowDuplicates, filter, projector );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the projector does with the data is up to the projector.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector )
		{
			this.CreateProjection( propertyProjectors, projector, false, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the projector does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		public void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, projector, allowDuplicates, null );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the projector does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		public virtual void CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates,
				IPredicate filter )
		{
			base.CreateProjection( propertyProjectors, allowDuplicates, filter, projector );
		}
		

		/// <summary>
		/// Gets the entity field property descriptors for the dummy instance passed in.
		/// </summary>
		/// <param name="dummyInstance">The dummy instance.</param>
		/// <param name="instanceProperties">The instance properties.</param>
		/// <param name="namesAdded">The names added by this routine</param>
		protected override void GetEntityFieldPropertyDescriptors( IEntityCore dummyInstance, ref List<PropertyDescriptor> instanceProperties, ref Dictionary<string, PropertyDescriptor> namesAdded )
		{
			FieldUtilities utils = new FieldUtilities();
			utils.GetEntityFieldPropertyDescriptors( (IEntity)dummyInstance, ref instanceProperties, ref namesAdded );
		}


		/// <summary>
		/// Creates a dummy instance for the related entity collection of this view. This is done using the entityfactory of that entitycollection.
		/// </summary>
		/// <returns></returns>
		protected override IEntityCore CreateDummyInstance()
		{
			EntityCollectionBase<TEntity> relatedCollection = this.RelatedCollection;
			if( (relatedCollection == null) || ((relatedCollection != null) && (relatedCollection.EntityFactoryToUse == null)) )
			{
				return null;
			}
			return relatedCollection.EntityFactoryToUse.Create();
		}


		/// <summary>
		/// Gets the property descriptor for the first sortclause. 
		/// </summary>
		/// <param name="appliedSorter">The applied sorter on this view..</param>
		/// <returns></returns>
		protected override PropertyDescriptor GetSortProperty( ISortExpression appliedSorter )
		{
			if(( appliedSorter == null ) ||((appliedSorter!=null) && (appliedSorter.Count<=0)))
			{
				return null;
			}

			if(appliedSorter[0].FieldToSortCore is IEntityField)
			{
				IEntityCore dummyInstance = CreateDummyInstance();
				return new EntityPropertyDescriptor((IEntityField)appliedSorter[0].FieldToSortCore, dummyInstance.GetType());
			}
			else
			{
				return ((EntityProperty)appliedSorter[0].FieldToSortCore).RepresentingPropertyDescriptor;
			}
		}



		#region IEntityView explicit implementation

		/// <summary>
		/// Gets or sets the data change action which specifies what to do when the data in the related collection of an entity view changes. A change in 
		/// data can be: entity added or changed. If an entity is removed from the underlying collection, the entity is simply removed from the entity 
		/// view, as the view doesn't contain any data by itself.
		/// </summary>
		/// <value>The data change action.</value>
		PostCollectionChangeAction IEntityView.DataChangeAction
		{
			get
			{
				return base.DataChangeAction;
			}
			set
			{
				base.DataChangeAction = value;
			}
		}


		/// <summary>
		/// Gets or sets the sorter for this entity view. Setting this property will re-sort the view and will reset the view in databinding scenario's.
		/// </summary>
		/// <value>The sort expression to use.</value>
		ISortExpression IEntityView.Sorter
		{
			get
			{
				return base.Sorter;
			}
			set
			{
				base.Sorter = value;
			}
		}

		/// <summary>
		/// Gets or sets the filter to use for this entity view.
		/// </summary>
		/// <value>The filter to use</value>
		IPredicate IEntityView.Filter
		{
			get
			{
				return base.Filter;
			}
			set
			{
				base.Filter = value;
			}
		}

		/// <summary>
		/// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.</returns>
		int IEntityView.Count
		{
			get { return base.Count; }
		}

		/// <summary>
		/// Gets the <see cref="IEntity"/> at the specified index in the view
		/// </summary>
		/// <value></value>
		IEntity IEntityView.this[int index]
		{
			get 
			{
				return (IEntity)base[index];
			}
		}

		/// <summary>
		/// Gets whether you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can add items to the list using <see cref="M:System.ComponentModel.IBindingList.AddNew"></see>; otherwise, false.</returns>
		bool IEntityView.AllowNew
		{
			get
			{
				return base.AllowNew;
			}
			set
			{
				base.AllowNew = value;
			}
		}

		/// <summary>
		/// Gets whether you can update items in the list.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can update the items in the list; otherwise, false.</returns>
		bool IEntityView.AllowEdit
		{
			get
			{
				return base.AllowEdit;
			}
			set
			{
				base.AllowEdit = value;
			}
		}

		/// <summary>
		/// Gets whether you can remove items from the list, using <see cref="M:System.Collections.IList.Remove(System.Object)"></see> or <see cref="M:System.Collections.IList.RemoveAt(System.Int32)"></see>.
		/// </summary>
		/// <value></value>
		/// <returns>true if you can remove items from the list; otherwise, false.</returns>
		bool IEntityView.AllowRemove
		{
			get
			{
				return base.AllowRemove;
			}
			set
			{
				base.AllowRemove = value;
			}
		}

		/// <summary>
		/// Gets the related collection set for this view.
		/// </summary>
		/// <value>The related collection.</value>
		IEntityCollection IEntityView.RelatedCollection
		{
			get { return this.RelatedCollection; }
		}


		/// <summary>
		/// Copies all entities in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <returns>New collection with all entities in this view</returns>
		IEntityCollection IEntityView.ToEntityCollection()
		{
			return this.ToEntityCollection();
		}


		/// <summary>
		/// Copies all entities starting at startIndex in this view to a new entity collection and returns that collection. The returned collection is of
		/// the same type as the related collection. Entities aren't copied, just references to the entities.
		/// </summary>
		/// <param name="startIndex">The start index for the interval to copy to the entity collection</param>
		/// <returns>
		/// New collection with all entities in this view
		/// </returns>
		IEntityCollection IEntityView.ToEntityCollection( int startIndex )
		{
			return this.ToEntityCollection( startIndex );
		}


		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination )
		{
			this.CreateProjection( propertyProjectors, destination );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in a datatable using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		/// <param name="destination">The destination datatable which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, DataTable destination, bool allowDuplicates, IPredicate filter )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates, filter );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination )
		{
			this.CreateProjection( propertyProjectors, destination );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityCollection destination, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in an entity collection  using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		/// <param name="destination">The destination entity collection which will contain the data from this view and which forms a new set.
		/// Data which is an object references is not copied by value, but is copied by reference.</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors,
			 IEntityCollection destination, bool allowDuplicates, IPredicate filter )
		{
			this.CreateProjection( propertyProjectors, destination, allowDuplicates, filter );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <remarks>Doesn't perform distinct filtering</remarks>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector )
		{
			this.CreateProjection( propertyProjectors, projector );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates )
		{
			this.CreateProjection( propertyProjectors, projector, allowDuplicates );
		}

		/// <summary>
		/// Projects the data in the view onto a new set, stored in a collection using the property projector objects to produce the actual data.
		/// </summary>
		/// <param name="propertyProjectors">The property projector objects to produce the data for the new set.</param>
		/// <param name="projector">The projector engine which will produce new objects in the returned list from the projection results per entity.
		/// The data is offered to the projector on a per-row projection basis, what the project does with the data is up to the projector.</param>
		/// <param name="allowDuplicates">if set to false, it will perform distinct filtering on all values in the projection result.</param>
		/// <param name="filter">Filter to apply on every entity in this view. If the filter resolves to true, the entity is used for projection</param>
		void IEntityView.CreateProjection( List<IEntityPropertyProjector> propertyProjectors, IEntityDataProjector projector, bool allowDuplicates,
				IPredicate filter )
		{
			this.CreateProjection( propertyProjectors, projector, allowDuplicates, filter );
		}

		
		/// <summary>
		/// Determines whether this entity view contains the entity passed in. This method returns false if the entity is outside the filter, but in the related
		/// entity collection, as it's then not contained in the entity view.
		/// </summary>
		/// <param name="value">The entity to check</param>
		/// <returns>True if the entity is present, otherwise false.</returns>
		bool IEntityView.Contains( IEntity value )
		{
			TEntity entity = value as TEntity;
			if( entity != null )
			{
				return base.Contains( entity );
			}
			else
			{
				throw new ArgumentException( "value isn't of the right type" );
			}
		}

		/// <summary>
		/// Determines the index of the entity passed in in the entity view in filtered and sorted state.
		/// </summary>
		/// <param name="value">The entity to get the index of.</param>
		/// <returns>Index of the entity in this entityview</returns>
		int IEntityView.IndexOf( IEntity value )
		{
			TEntity entity = value as TEntity;
			if( entity != null )
			{
				return base.IndexOf( entity );
			}
			else
			{
				throw new ArgumentException( "value isn't of the right type" );
			}
		}
		#endregion



		#region Class Property Declarations
		/// <summary>
		/// Gets the related collection set for this view.
		/// </summary>
		/// <value>The related collection.</value>
		public EntityCollectionBase<TEntity> RelatedCollection
		{
			get { return (EntityCollectionBase<TEntity>)base.RelatedCollectionInternal; }
		}
		#endregion

	}
}
