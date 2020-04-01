//////////////////////////////////////////////////////////////////////
// LLBLGen Pro is (c) 2002-2007 Solutions Design. All rights reserved.
// http://www.llblgen.com
// The sourcecode for the ORM Support classes is released as BSD2 licensed 
// open source, so licensees of LLBLGen Pro can modify, update and/or extend it. 
// Distribution of this sourcecode and binary compiled versions of this sourcecode
// are licensed to LLBLGen Pro licensees using the following license below.
//////////////////////////////////////////////////////////////////////
// COPYRIGHTS:
// Copyright (c)2002-2007 Solutions Design. All rights reserved.
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
using System.Collections;
using System.Text;
using System.Data;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which contains projection data for entity views, used in hierarchical projections of data. The data is applied to a view of all entities
	/// with the type specified as TEntity.
	/// </summary>
	[Serializable]
	public class ViewProjectionData : IViewProjectionData
	{
		#region Class Member Declarations
		private ArrayList _projectors;
		private IPredicate _filter;
		private bool _allowDuplicates;
		private Type _targetType;
		#endregion


		/// <summary>
		/// CTor. Uses no additional filter and allows duplicates.
		/// </summary>
		/// <param name="targetType">Type of the target entity.</param>
		/// <param name="projectors">List of entity property projectors to project the view's data</param>
		public ViewProjectionData(Type targetType, ArrayList projectors)
			: this(targetType, projectors, null, true)
		{
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="targetType">Type of the target entity.</param>
		/// <param name="projectors">List of entity property projectors to project the view's data</param>
		/// <param name="filter">Additional filter to apply to the data before projection. Only matching entities are projected</param>
		/// <param name="allowDuplicates">Flag to signal if duplicate results are allowed.</param>
		public ViewProjectionData(Type targetType, ArrayList projectors, IPredicate filter, bool allowDuplicates)
		{
			_targetType = targetType;
			_allowDuplicates = allowDuplicates;
			_projectors = projectors;
			_filter = filter;
		}


		/// <summary>
		/// Creates the data relations in the dataset passed in for the relations passed in. Only create relations where the start entity is the FK side.
		/// </summary>
		/// <param name="destination">The destination to create the datarelations in.</param>
		/// <param name="relations">The relations to use for creating the datarelations.</param>
		public void CreateDataRelations(DataSet destination, ArrayList relations)
		{
			foreach(IEntityRelation relation in relations)
			{
				if(relation.StartEntityIsPkSide)
				{
					continue;
				}
				string pkSideEntityName = relation.GetPKEntityFieldCore(0).ContainingObjectName;
				string fkSideEntityName = relation.GetFKEntityFieldCore(0).ContainingObjectName;

				// create datarelation between pk side table (parent) and fk side table (child). First find the 
				// tables. If they're not htere, skip this relation.
				DataTable pkSide = destination.Tables[pkSideEntityName];
				if(pkSide == null)
				{
					continue;
				}
				DataTable fkSide = destination.Tables[fkSideEntityName];
				if(fkSide == null)
				{
					continue;
				}

				// find columns. If one of the columns isn't there (e.g. it wasn't projected or renamed), skip this relation.
				ArrayList pkFields = relation.GetAllPKEntityFieldCoreObjects();
				ArrayList fkFields = relation.GetAllFKEntityFieldCoreObjects();
				DataColumn[] pkColumns = new DataColumn[pkFields.Count];
				DataColumn[] fkColumns = new DataColumn[fkFields.Count];
				bool skipRelation = false;
				for(int i = 0; i < pkFields.Count; i++)
				{
					DataColumn column = pkSide.Columns[((IEntityFieldCore)pkFields[i]).Name];
					if(column == null)
					{
						skipRelation = true;
						break;
					}
					pkColumns[i] = column;
				}
				if(skipRelation)
				{
					continue;
				}
				for(int i = 0; i < fkFields.Count; i++)
				{
					DataColumn column = fkSide.Columns[((IEntityFieldCore)fkFields[i]).Name];
					if(column == null)
					{
						skipRelation = true;
						break;
					}
					fkColumns[i] = column;
				}
				if(skipRelation)
				{
					continue;
				}

				string startEntityName = string.Empty;
				if(relation.StartEntityIsPkSide)
				{
					startEntityName = pkSideEntityName;
				}
				else
				{
					startEntityName = fkSideEntityName;
				}
				destination.Relations.Add(new DataRelation(string.Format("{0}_{1}", startEntityName, relation.MappedFieldName), pkColumns, fkColumns, false));
			}
		}



		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the list of entity property projectors to project the view's data
		/// </summary>
		public ArrayList Projectors
		{
			get
			{
				return _projectors;
			}
			set
			{
				_projectors = value;
			}
		}


		/// <summary>
		/// Gets / sets allowDuplicates, a flag to signal if duplicate results are allowed.
		/// </summary>
		public bool AllowDuplicates
		{
			get
			{
				return _allowDuplicates;
			}
			set
			{
				_allowDuplicates = value;
			}
		}


		/// <summary>
		/// Gets the type of the target entity.
		/// </summary>
		public Type TypeOfTargetEntity
		{
			get
			{
				return _targetType;
			}
		}

		/// <summary>
		/// Gets the additional filter to apply to the data before projection. Only matching entities are projected
		/// </summary>
		/// <value>The additional filter.</value>
		public IPredicate AdditionalFilter
		{
			get { return _filter; }
		}

		#endregion
	}
}
