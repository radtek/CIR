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
using System.Text;
using System.Data;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which implements a scalar query which is usable inside an expression. This expression assumes the query formulated will result in a single value.
	/// If that's not the case, use the overload of the CTor which accepts a value for forceRowLimit or set its ForceRowLimit property to true (default: false). 
	/// If forceRowLimit is set to true, a TOP 1 clause will be emitted into the query to force the query to result into a single value. Normally you don't need
	/// to do this as a scalar query has to be formulated as a single value anyway. 
	/// </summary>
	[Serializable]
	public class ScalarQueryExpression : IScalarQueryExpression, IExpression
	{
		#region Class Member Declarations
		private IEntityFieldCore _selectField;
		private IFieldPersistenceInfo _selectFieldPersistenceInfo;
		private IPredicateExpression _filterToUse;
		private IRelationCollection _relationsToUse;
		private ISortExpression _sorterToUse;
		private IGroupByCollection _groupByClause;
		private bool _forceRowLimit;

		[NonSerialized]
		private List<IDataParameter> _parameters;
		[NonSerialized]
		private IDbSpecificCreator _creator;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField )
			: this( selectField, null, null, null, null, false )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField, IPredicate filterToUse, IRelationCollection relationsToUse )
			: this( selectField, filterToUse, relationsToUse, null, null, false )
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="forceRowLimit">If set to true, it will force a TOP 1 clause to be emitted into the SQL (or equivalent if the db doesn't support TOP)</param>
		public ScalarQueryExpression(IEntityFieldCore selectField, IPredicate filterToUse, IRelationCollection relationsToUse, bool forceRowLimit)
			: this(selectField, filterToUse, relationsToUse, null, null, forceRowLimit)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="sorterToUse">The sorter to use.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField, IPredicate filterToUse, ISortExpression sorterToUse )
			: this(selectField, filterToUse, null, sorterToUse, null, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField, IPredicate filterToUse )
			: this(selectField, filterToUse, null, null, null, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="sorterToUse">The sorter to use.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField, IPredicate filterToUse, IRelationCollection relationsToUse, ISortExpression sorterToUse )
			: this(selectField, filterToUse, relationsToUse, sorterToUse, null, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="sorterToUse">The sorter to use.</param>
		/// <param name="groupByClause">The group by clause.</param>
		public ScalarQueryExpression( IEntityFieldCore selectField, IPredicate filterToUse, IRelationCollection relationsToUse, ISortExpression sorterToUse, 
				IGroupByCollection groupByClause) : this(selectField, filterToUse, relationsToUse, sorterToUse, groupByClause, false)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ScalarQueryExpression"/> class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="sorterToUse">The sorter to use.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="forceRowLimit">If set to true, it will force a TOP 1 clause to be emitted into the SQL (or equivalent if the db doesn't support TOP)</param>
		public ScalarQueryExpression(IEntityFieldCore selectField, IPredicate filterToUse, IRelationCollection relationsToUse, ISortExpression sorterToUse,
				IGroupByCollection groupByClause, bool forceRowLimit)
		{
			IFieldPersistenceInfo persistenceInfo = selectField as IFieldPersistenceInfo;	// selfservicing fields contain the persistence info.
			InitClass(selectField, persistenceInfo, filterToUse, relationsToUse, sorterToUse, groupByClause, forceRowLimit);
		}


		/// <summary>
		/// Retrieves a ready to use text representation of the scalar query
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <returns>The contained function call in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IScalarQueryExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		public string ToQueryText( ref int uniqueMarker )
		{
			return ToQueryText( ref uniqueMarker, false );
		}


		/// <summary>
		/// Retrieves a ready to use text representation of the scalar query
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IScalarQueryExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		public string ToQueryText( ref int uniqueMarker, bool inHavingClause )
		{
			if( _creator == null )
			{
				throw new ApplicationException( "_creator isn't set so this ScalarQueryExpression object can't be converted to a query." );
			}

			Parameters.Clear();

			// simply create a subquery using the variables specified. 
			IEntityFieldCore[] selectList = new IEntityFieldCore[1];
			selectList[0] = _selectField;
			IFieldPersistenceInfo[] persistenceInfos = new IFieldPersistenceInfo[1];
			persistenceInfos[0] = _selectFieldPersistenceInfo;

			long maxNumberOfItemsToReturn = 0;
			if(_forceRowLimit)
			{
				maxNumberOfItemsToReturn = 1;
			}
			IRetrievalQuery subQuery = _creator.CreateSubQuery( selectList, persistenceInfos, _filterToUse, maxNumberOfItemsToReturn, _sorterToUse, _relationsToUse,
					_groupByClause, ref uniqueMarker );

			// add the parameters of the subquery to the parameters list of this scalar query object. 
			List<IDataParameter> parameters = new List<IDataParameter>();
			for( int i = 0; i < subQuery.Parameters.Count; i++ )
			{
				parameters.Add( (IDataParameter)subQuery.Parameters[i] );
			}
			// clear the subquery's command's parameter collection, as we're moving the parameters from one collection to another.
			subQuery.Parameters.Clear();
			for( int i = 0; i < parameters.Count; i++ )
			{
				_parameters.Add( parameters[i] );
			}

			return string.Format("({0})", subQuery.Command.CommandText);
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="selectField">The select field.</param>
		/// <param name="selectFieldPersistenceInfo">The select field persistence info.</param>
		/// <param name="filterToUse">The filter to use.</param>
		/// <param name="relationsToUse">The relations to use.</param>
		/// <param name="sorterToUse">The sorter to use.</param>
		/// <param name="groupByClause">The group by clause.</param>
		/// <param name="forceRowLimit">if set to <c>true</c> [force row limit].</param>
		private void InitClass( IEntityFieldCore selectField, IFieldPersistenceInfo selectFieldPersistenceInfo,
				IPredicate filterToUse, IRelationCollection relationsToUse, ISortExpression sorterToUse, IGroupByCollection groupByClause, bool forceRowLimit )
		{
			_forceRowLimit = forceRowLimit;
			_selectField = selectField;
			_selectFieldPersistenceInfo = selectFieldPersistenceInfo;
			_filterToUse = null;
			IPredicateExpression filterAsExpression = filterToUse as IPredicateExpression;
			if( filterAsExpression == null )
			{
				if(filterToUse != null)
				{
					_filterToUse = new PredicateExpression(filterToUse);
				}
			}
			else
			{
				_filterToUse = filterAsExpression;
			}
			_relationsToUse = relationsToUse;
			_sorterToUse = sorterToUse;
			_parameters = new List<IDataParameter>();
			_groupByClause = groupByClause;
			_creator = null;
		}
		

		#region IExpression Members
		/// <summary>
		/// Retrieves a ready to use text representation of the contained expression.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the expression and also in the expression(s) containing the expression.</param>
		/// <returns>
		/// The contained expression in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string IExpression.ToQueryText( ref int uniqueMarker )
		{
			return this.ToQueryText( ref uniqueMarker );
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the scalar query
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IScalarQueryExpression.DatabaseSpecificCreator is not set to a valid value.</exception>
		string IExpression.ToQueryText( ref int uniqueMarker, bool inHavingClause )
		{
			return this.ToQueryText( ref uniqueMarker, inHavingClause );
		}

		/// <summary>
		/// The list of parameters created when the Expression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		/// <value></value>
		List<System.Data.IDataParameter> IExpression.Parameters
		{
			get { return this.Parameters; }
		}

		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters,
		/// and conversion routines, and field names, including prefix/postfix characters.
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		/// <value></value>
		IDbSpecificCreator IExpression.DatabaseSpecificCreator
		{
			get
			{
				return this.DatabaseSpecificCreator;
			}
			set
			{
				this.DatabaseSpecificCreator = value;
			}
		}

		/// <summary>
		/// Gets the left expression operand. Set by the constructor used.
		/// </summary>
		/// <value></value>
		IExpressionElement IExpression.LeftOperand
		{
			get { return new ExpressionElement<IScalarQueryExpression>( ExpressionElementType.ScalarQuery, this ); }
		}

		/// <summary>
		/// Gets the right expression operand. Set by the constructor used.
		/// Can be null
		/// </summary>
		/// <value></value>
		IExpressionElement IExpression.RightOperand
		{
			get { return null; }
		}

		/// <summary>
		/// Gets the operator of the expression. Not valid (ExOp.None) if RightOperand is null. Set by the constructor used.
		/// </summary>
		/// <value></value>
		ExOp IExpression.Operator
		{
			get { return ExOp.None; }
		}

		#endregion


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets ForceRowLimit. If set to true (default: false), it will force a TOP 1 clause to be emitted into the SQL (or equivalent if the db 
		/// doesn't support TOP)
		/// </summary>
		public bool ForceRowLimit
		{
			get
			{
				return _forceRowLimit;
			}
			set
			{
				_forceRowLimit = value;
			}
		}


		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters, 
		/// and conversion routines, and field names, including prefix/postfix characters. 
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		public IDbSpecificCreator DatabaseSpecificCreator
		{
			get
			{
				return _creator;
			}
			set
			{
				_creator = value;
			}
		}


		/// <summary>
		/// The list of parameters created when the ScalarQueryExpression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		public List<IDataParameter> Parameters 
		{
			get 
			{
				if(_parameters==null)
				{
					_parameters = new List<IDataParameter>();
				}
				return _parameters;
			}
		}

		/// <summary>
		/// Gets / sets selectFieldPersistenceInfo
		/// </summary>
		public IFieldPersistenceInfo SelectFieldPersistenceInfo
		{
			get
			{
				return _selectFieldPersistenceInfo;
			}
			set
			{
				_selectFieldPersistenceInfo = value;
			}
		}

		/// <summary>
		/// Gets / sets filterToUse
		/// </summary>
		public IPredicateExpression FilterToUse
		{
			get
			{
				return _filterToUse;
			}
			set
			{
				_filterToUse = value;
			}
		}

		/// <summary>
		/// Gets / sets relationsToUse
		/// </summary>
		public IRelationCollection RelationsToUse
		{
			get
			{
				return _relationsToUse;
			}
			set
			{
				_relationsToUse = value;
			}
		}


		/// <summary>
		/// Gets / sets sorterToUse
		/// </summary>
		public ISortExpression SorterToUse
		{
			get
			{
				return _sorterToUse;
			}
			set
			{
				_sorterToUse = value;
			}
		}

		/// <summary>
		/// Gets / sets selectField
		/// </summary>
		public IEntityFieldCore SelectField
		{
			get
			{
				return _selectField;
			}
			set
			{
				_selectField = value;
			}
		}

		/// <summary>
		/// Gets / sets groupByClause
		/// </summary>
		public IGroupByCollection GroupByClause
		{
			get
			{
				return _groupByClause;
			}
			set
			{
				_groupByClause = value;
			}
		}

		#endregion
	}
}
