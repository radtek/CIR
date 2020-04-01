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
using System.Collections.Specialized;
#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for Typed Lists. This class is a thin wrapper around the DataTable to make sure
	/// the member variable obeyWeakRelations is serialized: in VB.NET it's not possible to program
	/// this construct, because in VB.NET you can't re-implement an interface. 
	/// </summary>
#if !CF
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
	public abstract class TypedListCore : DataTable, ISerializable, ITypedListCore
#else
	public abstract class TypedListCore : DataTable, ITypedListCore
#endif
	{
		#region Class Member Declarations
		private bool _obeyWeakRelations;
		#endregion


		/// <summary>
		/// Empty CTor
		/// </summary>
		public TypedListCore()
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="tableName">name for the datatable</param>
		public TypedListCore(string tableName):base(tableName)
		{
		}

#if !CF
		/// <summary>
		/// Protected constructor for deserialization.
		/// Idea borrowed from Dino Esposito's article: http://msdn.microsoft.com/msdnmag/issues/02/12/CuttingEdge/default.aspx
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TypedListCore(SerializationInfo info, StreamingContext context)
		{
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{

				// Extract from the serialization info
				ArrayList colNames, colTypes, dataRows;

				colNames = (ArrayList)info.GetValue("ColNames", typeof(ArrayList));
				colTypes = (ArrayList)info.GetValue("ColTypes", typeof(ArrayList)); 
				dataRows = (ArrayList)info.GetValue("DataRows", typeof(ArrayList)); 

				// Add columns
				for(int i=0;i<colNames.Count; i++)
				{
					DataColumn col = new DataColumn(colNames[i].ToString(), Type.GetType(colTypes[i].ToString() )); 	
					this.Columns.Add(col);
				}

				// Add rows
				for(int i=0; i<dataRows.Count; i++)
				{
					this.LoadDataRow((object[])dataRows[i], true);
				}

				_obeyWeakRelations=info.GetBoolean("_obeyWeakRelations");
				base.TableName = info.GetString("_tableName");
			}
			else
			{
				InitClass(false);
				SerializationHelper.Deserialize(this, info, context);
			}
		}


		/// <summary>
		/// ISerializable member. Does custom serialization so members also get serialized (obeyWeakRelationships).
		/// Serializes members of this entity class and uses the base class' implementation to serialize the rest.
		/// Idea borrowed from Dino Esposito's article: http://msdn.microsoft.com/msdnmag/issues/02/12/CuttingEdge/default.aspx
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		void System.Runtime.Serialization.ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if(SerializationHelper.Optimization == SerializationOptimization.None)
			{
				// Add arrays
				ArrayList colNames = new ArrayList();
				ArrayList colTypes = new ArrayList();
				ArrayList dataRows = new ArrayList();

				// Insert column information (names and types) into worker arrays
				foreach(DataColumn col in this.Columns)
				{
					colNames.Add(col.ColumnName); 
					colTypes.Add(col.DataType.FullName);   
				}

				// Insert rows information into a worker array
				foreach(DataRow row in this.Rows)
				{
					dataRows.Add(row.ItemArray);
				}

				// Add arrays to the serialization info structure
				info.AddValue("ColNames", colNames, typeof(ArrayList));
				info.AddValue("ColTypes", colTypes, typeof(ArrayList));
				info.AddValue("DataRows", dataRows, typeof(ArrayList));

				info.AddValue("_obeyWeakRelations", _obeyWeakRelations);
				info.AddValue("_tableName", base.TableName);
			}
			else
			{
				SerializationHelper.Serialize(this, info, context);
			}
		}
#endif

		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="obeyWeakRelations">if set to <c>true</c> [obey weak relations].</param>
		protected virtual void InitClass(bool obeyWeakRelations)
		{
		}


		/// <summary>
		/// Method which is called at the end of the generated BuildRelationSet method and which can be used to add additional relations to 
		/// the relationcollection of the typedlist.
		/// </summary>
		/// <param name="relations">The relations collection of the typed list</param>
		protected virtual void OnRelationSetBuilt( IRelationCollection relations )
		{
		}


		/// <summary>
		/// Method which is called at the end of the InitClass() method in the generated typedlist class. This method can be used to add 
		/// additional DataColumn definitions to the typedlist's base class, which is a datatable. 
		/// </summary>
		protected virtual void OnInitialized()
		{
		}

		
#if !CF
		#region Optimized Serialization related code
		/// <summary>
		/// Gets the serialization flags.
		/// </summary>
		/// <returns></returns>
		internal BitVector32 GetSerializationFlags()
		{
			BitVector32 serializationFlags = new BitVector32();
			serializationFlags[SerializationHelper.TypedListObeyWeakRelations] = _obeyWeakRelations;
			return serializationFlags;
		}

		/// <summary>
		/// Serializes the owned data.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="context">The context.</param>
		protected internal virtual void SerializeOwnedData(SerializationWriter writer, object context)
		{
			SerializationHelper.SerializeSimpleReadOnlyTableData(writer, this);
		}

		/// <summary>
		/// Deserializes the owned data.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="context">The context.</param>
		protected internal virtual void DeserializeOwnedData(SerializationReader reader, object context)
		{
			BitVector32 serializationFlags = (BitVector32)context;
			_obeyWeakRelations = serializationFlags[SerializationHelper.TypedListObeyWeakRelations];
			SerializationHelper.DeserializeSimpleReadOnlyTableData(reader, this);
		}
		#endregion Optimized Serialization
#endif

		#region Class Property Declarations
		/// <summary>
		/// Returns the amount of rows in this typed list.
		/// </summary>
		public abstract int Count {get; }

		/// <summary>
		/// Gets / sets ObeyWeakRelations, which is the flag to signal the collection what kind of join statements to generate in the
		/// query statement. Weak relationships are relationships which are optional, for example a
		/// customer with no orders is possible, because the relationship between customer and order is based on a field in order.
		/// When this property is set to true (default: false), weak relationships will result in LEFT JOIN statements. When
		/// set to false (which is the default), INNER JOIN statements are used.
		/// </summary>
		public bool ObeyWeakRelations
		{
			get { return _obeyWeakRelations; }
			set { _obeyWeakRelations = value; }
		}
		#endregion

	}


	/// <summary>
	/// Base class for typedlist classes in SelfServicing. 
	/// </summary>
	/// <remarks>SelfServicing specific</remarks>
	public abstract class TypedListBase : TypedListCore
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TypedListBase"/> class.
		/// </summary>
		public TypedListBase():base()
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param TypedListCore="tableName">name for the datatable</param>
		public TypedListBase(string tableName):base(tableName)
		{
		}

#if !CF
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TypedListBase( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
		}
#endif

		/// <summary>
		/// Method which is called at the end of the generated BuildResultset method and which can be used to add additional fields to the fields 
		/// object for the typed list, or to manipulate the field objects added to the typed list.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <remarks>Be sure to call fields.Expand(n) first, where n is the number of fields you want to add.</remarks>
		protected virtual void OnResultsetBuilt( IEntityFields fields )
		{
		}
	}

	
	/// <summary>
	/// Base class for typedlist classes in SelfServicing. 
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public abstract class TypedListBase2 : TypedListCore
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TypedListBase"/> class.
		/// </summary>
		public TypedListBase2()
			: base()
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param TypedListCore="tableName">name for the datatable</param>
		public TypedListBase2( string tableName )
			: base( tableName )
		{
		}

#if !CF
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TypedListBase2( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
		}
#endif

		/// <summary>
		/// Method which is called at the end of the generated BuildResultset method and which can be used to add additional fields to the fields 
		/// object for the typed list, or to manipulate the field objects added to the typed list.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <remarks>Be sure to call fields.Expand(n) first, where n is the number of fields you want to add.</remarks>
		protected virtual void OnResultsetBuilt( IEntityFields2 fields )
		{
		}
	}

}
