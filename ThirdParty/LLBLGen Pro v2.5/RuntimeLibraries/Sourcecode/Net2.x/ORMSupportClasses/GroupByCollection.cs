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
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// GroupByCollection class which is used to collect EntityField(2) instances which are used for the 
	/// GROUP BY clause in a retrieval query. When a group by collection is specified in a retrieval query, all
	/// fields in the resultset have to be in this collection.
	/// Generic
	/// </summary>
	[Serializable]
	public class GroupByCollection : IGroupByCollection
	{
		#region Class Member Declarations
		private List<IEntityFieldCore>		_entityFields;
		private List<IFieldPersistenceInfo>	_persistenceInfos;
		private IPredicateExpression		_havingClause;

		[NonSerialized]
		private IDbSpecificCreator _databaseSpecificCreator;
		[NonSerialized]
		private List<IDataParameter> _parameters;
		#endregion
		

		/// <summary>
		/// CTor
		/// </summary>
		public GroupByCollection()
		{
			InitClass();
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="GroupByCollection"/> class.
		/// </summary>
		/// <param name="fieldToAdd">The field to add to the groupbycollection.</param>
		public GroupByCollection(IEntityFieldCore fieldToAdd)
		{
			InitClass();
			if(fieldToAdd != null)
			{
				Add(fieldToAdd);
			}
		}


		/// <summary>
		/// Adds the range of IEntityFieldCore fields to the groupbycollection.
		/// </summary>
		/// <param name="fieldsToAdd">The fields to add to this groupbycollection.</param>
		public void AddRange(IEnumerable fieldsToAdd)
		{
			foreach(IEntityFieldCore toAdd in fieldsToAdd)
			{
				Add(toAdd);
			}
		}


		/// <summary>
		/// Adds the passed in entity field instance to the list. entity fields can be added just once.
		/// If the field is already in the collection, the index of the field in the list is returned.
		/// </summary>
		/// <param name="fieldToAdd">entity field instance to add</param>
		/// <returns>Index of added field in the list.</returns>
		public int Add<TEntityField>(TEntityField fieldToAdd)
			where TEntityField : IEntityFieldCore
		{
			if(fieldToAdd == null)
			{
				return -1;
			}

			int index=_entityFields.IndexOf(fieldToAdd);

			if(index > 0)
			{
				// already in list
				return index;
			}

			_entityFields.Add(fieldToAdd);
			int indexToReturn = _entityFields.Count - 1;

			if( fieldToAdd is IFieldPersistenceInfo )
			{
				// selfservicing
				_persistenceInfos.Add((IFieldPersistenceInfo) fieldToAdd );
			}
			else
			{
				// adapter, will be filled in later.
				_persistenceInfos.Add( null );
			}

			return indexToReturn;
		}


		/// <summary>
		/// Removes the passed in entity field instance. Finds the object to remove using value compare.
		/// </summary>
		/// <param name="fieldToRemove">entity field instance to remove</param>
		public void Remove<TEntityField>(TEntityField fieldToRemove)
			where TEntityField : IEntityFieldCore
		{
			int index = _entityFields.IndexOf(fieldToRemove);

			if(index <0)
			{
				// not in list
				return;
			}

			_entityFields.RemoveAt(index);
			_persistenceInfos.RemoveAt(index);
		}


		/// <summary>
		/// Inserts the field passed in on index specified.
		/// </summary>
		/// <param name="fieldToInsert">entity field to insert</param>
		/// <param name="index">index on which the field should be inserted</param>
		/// <exception cref="InvalidOperationException">If the field is already added.</exception>
		public void Insert<TEntityField>(TEntityField fieldToInsert, int index)
			where TEntityField : IEntityFieldCore
		{
			if(_entityFields.Contains(fieldToInsert))
			{
				throw new InvalidOperationException("Field can be added just once.");
			}

			_entityFields.Insert(index, fieldToInsert);
			if( fieldToInsert is IFieldPersistenceInfo )
			{
				// Selfservicing
				_persistenceInfos.Insert( index, (IFieldPersistenceInfo) fieldToInsert );
			}
			else
			{
				// adapter
				_persistenceInfos.Insert( index, null );		// will be filled in later
			}
		}


		/// <summary>
		/// Removes the IEntityField(2) instance at index specified from the collection.
		/// </summary>
		/// <param name="index">the index of the field to remove</param>
		public void RemoveAt(int index)
		{
			_entityFields.RemoveAt(index);
			_persistenceInfos.RemoveAt(index);
		}


		/// <summary>
		/// Checks if the field is in the list. Does a value compare, not an object reference compare. 
		/// </summary>
		/// <param name="fieldToCheck">entity field to check for presence.</param>
		/// <returns>true if a similar field is found in the collection, false otherwise.</returns>
		public bool Contains<TEntityField>(TEntityField fieldToCheck)
			where TEntityField : IEntityFieldCore
		{
			return _entityFields.Contains(fieldToCheck);
		}


		/// <summary>
		/// Gets the index of the specified field in the list.
		/// </summary>
		/// <param name="fieldToCheck">field to get the index of</param>
		/// <returns>-1 if not found, index otherwise</returns>
		public int IndexOf<TEntityField>(TEntityField fieldToCheck)
			where TEntityField : IEntityFieldCore
		{
			return _entityFields.IndexOf(fieldToCheck);
		}


		/// <summary>
		/// Returns the IEntityFieldCore part of the field at position index
		/// </summary>
		/// <param name="index">index of field to return the IEntityFieldCore portion of</param>
		/// <returns>the IEntityFieldCore part of the field at position index</returns>
		public IEntityFieldCore GetEntityFieldCore(int index)
		{
			return _entityFields[index];
		}


		/// <summary>
		/// Returns the IFieldPersistenceInfo part of the field at position index
		/// </summary>
		/// <param name="index">index of field to return the IFieldPersistenceInfo portion of</param>
		/// <returns>the IFieldPersistenceInfo part of the field at position index</returns>
		public IFieldPersistenceInfo GetFieldPersistenceInfo(int index)
		{
			return _persistenceInfos[index];
		}


		/// <summary>
		/// Sets the IFieldPersistenceInfo part of the field at position index.
		/// Adapter specific.
		/// </summary>
		/// <param name="persistenceInfo">The field persistence info object to set</param>
		/// <param name="index">index of field to set the persistence info of</param>
		public void SetFieldPersistenceInfo(IFieldPersistenceInfo persistenceInfo, int index)
		{
			_persistenceInfos[index] = persistenceInfo;
		}


		/// <summary>
		/// Retrieves a ready to use text representation for the groupby collection
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <returns>string which is usable as the argument for the GROUP BY clause in a query</returns>
		/// <remarks>Emits expressions on fields instead of the field names, if applicable.</remarks>
		public string ToQueryText( ref int uniqueMarker )
		{
			return ToQueryText( ref uniqueMarker, false );
		}


		/// <summary>
		/// Retrieves a ready to use text representation for the groupby collection.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the query</param>
		/// <param name="ignoreExpressions">If set to false (default), it will emit the expression of a field in the groupbycollection instead of the
		/// fieldname.</param>
		/// <returns>
		/// string which is usable as the argument for the GROUP BY clause in a query
		/// </returns>
		public virtual string ToQueryText( ref int uniqueMarker, bool ignoreExpressions )
		{
			StringBuilder queryText = new StringBuilder(256);
			_parameters = new List<IDataParameter>();

			for( int i = 0; i < this.Count; i++ )
			{
				if( i > 0 )
				{
					queryText.Append( ", " );
				}
				IEntityFieldCore currentField = this[i];
				string toGroupOn = string.Empty;
				if(( currentField.ExpressionToApply != null ) && !ignoreExpressions)
				{
					currentField.ExpressionToApply.DatabaseSpecificCreator = _databaseSpecificCreator;
					toGroupOn = currentField.ExpressionToApply.ToQueryText( ref uniqueMarker, false );
					_parameters.AddRange( currentField.ExpressionToApply.Parameters );
				}
				else
				{
					toGroupOn = _databaseSpecificCreator.CreateFieldName(
									GetFieldPersistenceInfo( i ), currentField.Name, currentField.ObjectAlias,
									currentField.ContainingObjectName, currentField.ActualContainingObjectName );
				}

				queryText.Append( toGroupOn );
			}

			if( (_havingClause != null) && (_havingClause.Count > 0) )
			{
				_havingClause.DatabaseSpecificCreator = _databaseSpecificCreator;
				queryText.AppendFormat( null, " HAVING {0}", _havingClause.ToQueryText( ref uniqueMarker, true ) );
				_parameters.AddRange( _havingClause.Parameters );
			}

			return queryText.ToString();
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		private void InitClass()
		{
			_entityFields = new List<IEntityFieldCore>();
			_persistenceInfos = new List<IFieldPersistenceInfo>();
			_havingClause = null;
		}

		#region Class Property Declarations
		/// <summary>
		/// Indexer in the collection.
		/// </summary>
		public IEntityFieldCore this [int index] 
		{
			get { return _entityFields[index]; }
		}

		/// <summary>
		/// The amount of items currently stored in the IGroupByCollection
		/// </summary>
		public int Count 
		{
			get { return _entityFields.Count;}
		}

		/// <summary>
		/// Gets/sets the predicate expression which forms the having clause for this group by collection.
		/// </summary>
		public IPredicateExpression HavingClause 
		{
			get { return _havingClause;}
			set { _havingClause = value;}
		}


		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		public IDbSpecificCreator DatabaseSpecificCreator
		{
			get { return _databaseSpecificCreator; }
			set { _databaseSpecificCreator = value; }
		}

		/// <summary>
		/// The list of parameters created when the Predicate was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		public List<IDataParameter> Parameters
		{
			get
			{
				if( _parameters == null )
				{
					_parameters = new List<IDataParameter>();
				}
				return _parameters;
			}
		}
		#endregion
	}
}
