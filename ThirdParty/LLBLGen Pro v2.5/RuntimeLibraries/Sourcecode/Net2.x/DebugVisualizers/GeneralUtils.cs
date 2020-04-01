//////////////////////////////////////////////////////////////////////
// Part of the LLBLGen Pro debug visualizers for VS.NET 2005. 
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
//////////////////////////////////////////////////////////////////////
// The sourcecode for this debug visualizer is released as BSD2 licensed open source, so licensees and others can
// modify, update, extend or use it to write other debug visualizers. 
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2007 Solutions Design. All rights reserved.
// 
// This DQE is released under the following license: (BSD2)
// -------------------------------------------
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

using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.LLBLGen.Pro.DebugVisualizers
{
	/// <summary>
	/// General utility class for usage with the visualizers.
	/// </summary>
	public class GeneralUtils
	{

		/// <summary>
		/// Retrieves the persistence info for the field passed in. 
		/// </summary>
		/// <param name="field">Field which fieldpersistence info has to be retrieved</param>
		/// <returns>the requested persistence information</returns>
		public IFieldPersistenceInfo GetFieldPersistenceInfo( IEntityFieldCore field )
		{
			if( field is IEntityField )
			{
				// self servicing
				return (IFieldPersistenceInfo)field;
			}

			IFieldPersistenceInfo toReturn = new FieldPersistenceInfo( string.Empty, string.Empty, field.ContainingObjectName, field.Name, field.IsNullable,
				(int)SqlDbType.VarChar, field.MaxLength, field.Precision, field.Scale, false, string.Empty, null, field.DataType );
			InsertPersistenceInfoObjects( field.ExpressionToApply );
			return toReturn;
		}

		/// <summary>
		/// Retrieves the persistence info objects for the fields of the entity passed in.
		/// </summary>
		/// <param name="entity">Entity object which fields the persistence information should be retrieved for</param>
		/// <returns>the requested persistence information</returns>
		public IFieldPersistenceInfo[] GetFieldPersistenceInfos( IEntityCore entity )
		{
			IEntity2 entityToUse = entity as IEntity2;
			if( entityToUse == null )
			{
				// self servicing
				return ((IEntity)entity).Fields.GetAsPersistenceInfoArray();
			}

			for( int i = 0; i < entityToUse.Fields.Count; i++ )
			{
				InsertPersistenceInfoObjects( entityToUse.Fields[i].ExpressionToApply );
			}
			IFieldPersistenceInfo[] toReturn = new IFieldPersistenceInfo[entityToUse.Fields.Count];
			for( int i = 0; i < entityToUse.Fields.Count; i++ )
			{
				toReturn[i] = GetFieldPersistenceInfo( entityToUse.Fields[i] );
			}

			return toReturn;
		}


		/// <summary>
		/// Inserts the persistence info objects.
		/// </summary>
		/// <param name="predicate">The predicate.</param>
		public void InsertPersistenceInfoObjects( IPredicate predicate )
		{
			if( predicate is PredicateExpression )
			{
				InsertPersistenceInfoObjects( (PredicateExpression)predicate );
			}
			else
			{
				InsertPersistenceInfoObjects( new PredicateExpression( predicate ) );
			}
		}


		/// <summary>
		/// Inserts in each entityrelation object the persistence info objects for the fields referenced.
		/// </summary>
		/// <param name="relations">IRelationCollection object which has entityrelation objects whose fields' persistence info objects have to be
		/// set to a value.</param>
		public void InsertPersistenceInfoObjects( IRelationCollection relations )
		{
			if( relations == null )
			{
				return;
			}

			for( int i = 0; i < ((RelationCollection)relations).Count; i++ )
			{
				IEntityRelation currentRelation = relations[i];

				for( int j = 0; j < currentRelation.AmountFields; j++ )
				{
					currentRelation.SetFKFieldPersistenceInfo( j, GetFieldPersistenceInfo( currentRelation.GetFKEntityFieldCore( j ) ) );
					currentRelation.SetPKFieldPersistenceInfo( j, GetFieldPersistenceInfo( currentRelation.GetPKEntityFieldCore( j ) ) );
					if( currentRelation.CustomFilter != null )
					{
						InsertPersistenceInfoObjects( currentRelation.CustomFilter );
					}
				}

				if( currentRelation.InheritanceInfoPkSideEntity != null )
				{
					InsertPersistenceInfoObjects( currentRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot );
				}
				if( currentRelation.InheritanceInfoFkSideEntity != null )
				{
					InsertPersistenceInfoObjects( currentRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot );
				}
			}
		}


		/// <summary>
		/// Inserts in each SortClause object the persistence info object for the field referenced.
		/// </summary>
		/// <param name="sortClauses">ISortExpression object which has SortClause objects whose fields persistence info object has to be
		/// set to a value.</param>
		public void InsertPersistenceInfoObjects( ISortExpression sortClauses )
		{
			if( sortClauses == null )
			{
				return;
			}

			for( int i = 0; i < sortClauses.Count; i++ )
			{
				sortClauses[i].PersistenceInfo = GetFieldPersistenceInfo( sortClauses[i].FieldToSortCore );
			}
		}


		/// <summary>
		/// Inserts for each entityfield in the collection the persistence info object 
		/// </summary>
		/// <param name="groupByClause">IGroupByCollection object which has IEntityField(2) objects whose persistence info object has to be
		/// set to a value.</param>
		public void InsertPersistenceInfoObjects( IGroupByCollection groupByClause )
		{
			if( groupByClause == null )
			{
				return;
			}

			for( int i = 0; i < groupByClause.Count; i++ )
			{
				groupByClause.SetFieldPersistenceInfo( GetFieldPersistenceInfo( groupByClause[i] ), i );
			}

			if( groupByClause.HavingClause != null )
			{
				InsertPersistenceInfoObjects( groupByClause.HavingClause );
			}
		}


		/// <summary>
		/// Inserts for each entityfield in the expression the persistence info object 
		/// </summary>
		/// <param name="expression">IExpression object which has IEntityField(2) objects whose persistence info object has to be
		/// set to a value.</param>
		public void InsertPersistenceInfoObjects( IExpression expression )
		{
			if( expression == null )
			{
				return;
			}

			if( expression.LeftOperand == null )
			{
				// none set
				return;
			}

			// left operand isn't null, set it if required
			switch( expression.LeftOperand.Type )
			{
				case ExpressionElementType.Expression:
					InsertPersistenceInfoObjects( (IExpression)expression.LeftOperand.Contents );
					break;
				case ExpressionElementType.Field:
					IExpressionFieldElement fieldElement = (IExpressionFieldElement)expression.LeftOperand;
					fieldElement.PersistenceInfo = GetFieldPersistenceInfo( (IEntityFieldCore)fieldElement.Contents );
					break;
				default:
					// nothing
					break;
			}

			if( expression.RightOperand != null )
			{
				switch( expression.RightOperand.Type )
				{
					case ExpressionElementType.Expression:
						InsertPersistenceInfoObjects( (IExpression)expression.RightOperand.Contents );
						break;
					case ExpressionElementType.Field:
						IExpressionFieldElement fieldElement = (IExpressionFieldElement)expression.RightOperand;
						fieldElement.PersistenceInfo = GetFieldPersistenceInfo( (IEntityFieldCore)fieldElement.Contents );
						break;
					default:
						// nothing
						break;
				}
			}
		}


		/// <summary>
		/// Inserts in each predicate expression element the persistence info object for the field used. If there is already a fieldpersistenceinfo 
		/// element for a given field, it is skipped. 
		/// </summary>
		/// <param name="expression">IPredicateExpression object which has predicate elements whose persistence info objects have to be
		/// set to a value.</param>
		public virtual void InsertPersistenceInfoObjects( IPredicateExpression expression )
		{
			if( expression == null )
			{
				return;
			}

			for( int i = 0; i < expression.Count; i++ )
			{
				if( expression[i].Type != PredicateExpressionElementType.Predicate )
				{
					continue;
				}

				IPredicate currentPredicate = (IPredicate)expression[i].Contents;
				switch( (PredicateType)currentPredicate.InstanceType )
				{
					case PredicateType.Undefined:
						continue;
					case PredicateType.PredicateExpression:
						// recurse
						InsertPersistenceInfoObjects( (IPredicateExpression)expression[i].Contents );
						break;
					case PredicateType.FieldBetweenPredicate:
						FieldBetweenPredicate betweenPredicate = (FieldBetweenPredicate)currentPredicate;
						if( betweenPredicate.PersistenceInfo == null )
						{
							betweenPredicate.PersistenceInfo = GetFieldPersistenceInfo( betweenPredicate.FieldCore );
						}
						if( betweenPredicate.BeginIsField && (betweenPredicate.PersistenceInfoBegin == null) )
						{
							betweenPredicate.PersistenceInfoBegin = GetFieldPersistenceInfo( betweenPredicate.FieldBeginCore );
						}
						if( betweenPredicate.EndIsField && (betweenPredicate.PersistenceInfoEnd == null) )
						{
							betweenPredicate.PersistenceInfoEnd = GetFieldPersistenceInfo( betweenPredicate.FieldEndCore );
						}
						break;
					case PredicateType.FieldCompareNullPredicate:
						FieldCompareNullPredicate compareNullPredicate = (FieldCompareNullPredicate)currentPredicate;
						if( compareNullPredicate.PersistenceInfo == null )
						{
							compareNullPredicate.PersistenceInfo = GetFieldPersistenceInfo( compareNullPredicate.FieldCore );
						}
						break;
					case PredicateType.FieldCompareValuePredicate:
						FieldCompareValuePredicate compareValuePredicate = (FieldCompareValuePredicate)currentPredicate;
						if( compareValuePredicate.PersistenceInfo == null )
						{
							compareValuePredicate.PersistenceInfo = GetFieldPersistenceInfo( compareValuePredicate.FieldCore );
						}
						break;
					case PredicateType.FieldLikePredicate:
						FieldLikePredicate likePredicate = (FieldLikePredicate)currentPredicate;
						if( likePredicate.PersistenceInfo == null )
						{
							likePredicate.PersistenceInfo = GetFieldPersistenceInfo( likePredicate.FieldCore );
						}
						break;
					case PredicateType.FieldCompareRangePredicate:
						FieldCompareRangePredicate compareRangePredicate = (FieldCompareRangePredicate)currentPredicate;
						if( compareRangePredicate.PersistenceInfo == null )
						{
							compareRangePredicate.PersistenceInfo = GetFieldPersistenceInfo( compareRangePredicate.FieldCore );
						}
						break;
					case PredicateType.FieldCompareExpressionPredicate:
						FieldCompareExpressionPredicate expressionPredicate = (FieldCompareExpressionPredicate)currentPredicate;
						if( expressionPredicate.PersistenceInfo == null )
						{
							expressionPredicate.PersistenceInfo = GetFieldPersistenceInfo( expressionPredicate.FieldCore );
						}
						if( expressionPredicate.ExpressionToCompareWith != null )
						{
							InsertPersistenceInfoObjects( expressionPredicate.ExpressionToCompareWith );
						}
						break;
					case PredicateType.FieldFullTextSearchPredicate:
						FieldFullTextSearchPredicate fullTextSearchPredicate = (FieldFullTextSearchPredicate)currentPredicate;
						if( fullTextSearchPredicate.PersistenceInfo == null )
						{
							fullTextSearchPredicate.PersistenceInfo = GetFieldPersistenceInfo( fullTextSearchPredicate.FieldCore );
						}
						break;
					case PredicateType.FieldCompareSetPredicate:
						FieldCompareSetPredicate compareSetPredicate = (FieldCompareSetPredicate)currentPredicate;
						if( (compareSetPredicate.PersistenceInfoField == null) && (compareSetPredicate.FieldCore != null) )
						{
							compareSetPredicate.PersistenceInfoField = GetFieldPersistenceInfo( compareSetPredicate.FieldCore );
						}
						if( compareSetPredicate.PersistenceInfoSetField == null )
						{
							compareSetPredicate.PersistenceInfoSetField = GetFieldPersistenceInfo( compareSetPredicate.SetFieldCore );
						}
						InsertPersistenceInfoObjects( compareSetPredicate.SetFilterAsPredicateExpression );
						InsertPersistenceInfoObjects( compareSetPredicate.SetRelations );
						InsertPersistenceInfoObjects( compareSetPredicate.SetSorter );
						InsertPersistenceInfoObjects( compareSetPredicate.GroupByClause );
						break;
					default:
						if(currentPredicate is MemberPredicate)
						{
							InsertPersistenceInfoObjects(((MemberPredicate)currentPredicate).Filter);
						}
						else
						{
							if(currentPredicate is AggregateSetPredicate)
							{
								AggregateSetPredicate currentPredicateAsAggregateSetPredicate = currentPredicate as AggregateSetPredicate;
								if(currentPredicateAsAggregateSetPredicate.SetFilter != null)
								{
									InsertPersistenceInfoObjects(currentPredicateAsAggregateSetPredicate.SetFilter);
								}
								if(currentPredicateAsAggregateSetPredicate.ValueProducer != null)
								{
									InsertPersistenceInfoObjects(currentPredicateAsAggregateSetPredicate.ValueProducer);
								}
							}
						}
						break;
				}
			}
		}

	}
}
