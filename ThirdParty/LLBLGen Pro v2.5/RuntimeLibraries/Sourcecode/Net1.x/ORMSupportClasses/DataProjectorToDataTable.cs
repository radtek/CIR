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
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Projector engine which projects raw projection result data onto datarows which are added to a single datatable.
	/// Used by creation of projections of EntityView(2) data to datatables.
	/// </summary>
	public class DataProjectorToDataTable : IEntityDataProjector, IGeneralDataProjector
	{
		#region Class Member Declarations
		private DataTable _destination;
		private bool _createColumns;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataProjectorToDataTable"/> class.
		/// </summary>
		/// <param name="destination">The destination of the data.</param>
		/// <remarks>If the datatable doesn't have any columns defined, new ones are created using the propertyprojectors passed in when the first
		/// row is created, and the types of the data.</remarks>
		public DataProjectorToDataTable(DataTable destination )
		{
			if( destination == null )
			{
				throw new ArgumentNullException( "destination", "destination can't be null" );
			}

			_destination = destination;
			_createColumns = (_destination.Columns.Count <= 0);
		}


		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="propertyProjectors">Property projectors.</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void IEntityDataProjector.AddProjectionResultToContainer(ArrayList propertyProjectors, object[] rawProjectionResult )
		{
			this.AddProjectionResultToContainer(propertyProjectors, rawProjectionResult);
		}


		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="valueProjectors">List of value projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void IGeneralDataProjector.AddProjectionResultToContainer( ArrayList valueProjectors, object[] rawProjectionResult )
		{
			this.AddProjectionResultToContainer(valueProjectors, rawProjectionResult);
		}


		/// <summary>
		/// Performs the actual projection
		/// </summary>
		/// <param name="projectors">The projectors.</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		/// <remarks>If the datatable already contains columns, the columns are re-used as indexes into the propertyprojectors: a column without a propertyprojector
		/// won't receive a value and also a value without a corresponding column won't end up in the row.</remarks>
		private void AddProjectionResultToContainer( IList projectors, object[] rawProjectionResult )
		{
			if( _createColumns )
			{
				CreateColumns( projectors, rawProjectionResult );
				_createColumns = false;	
			}
			// columns already exist, load per column the data from the rawProjectionResult. If a column doesn't have a propertyProjector, no data is copied.
			// if a propertyprojector isn't mentioned as a column, also no data is copied. 
			DataRow newRow = _destination.NewRow();
			for(int i=0;i<projectors.Count;i++)
			{
				if( _destination.Columns[((IProjector)projectors[i]).ProjectedResultName] != null )
				{
					newRow[((IProjector)projectors[i]).ProjectedResultName] = rawProjectionResult[i];
				}
			}
			_destination.Rows.Add( newRow );
		}


		/// <summary>
		/// Creates the columns in the destination datatable
		/// </summary>
		/// <param name="projectors">The projectors.</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		private void CreateColumns( IList projectors, object[] rawProjectionResult )
		{
			if( _destination.Columns.Count > 0 )
			{
				return;
			}

			for( int i = 0; i < projectors.Count; i++ )
			{
				IProjector projector = (IProjector)projectors[i];
				_destination.Columns.Add( new DataColumn( projector.ProjectedResultName, projector.ValueType) );
			}
		}
	}
}
