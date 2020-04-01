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
using System.ComponentModel;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Projector engine which projects raw projection result data onto new entities which are added to a single entitycollection.
	/// </summary>
	/// <remarks>Selfservicing specific</remarks>
	public class DataProjectorToIEntityCollection : IEntityDataProjector, IGeneralDataProjector
	{
		#region Class Member Declarations
		private IEntityCollection _destination;
		private Hashtable _propertyDescriptors;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataProjectorToIEntityCollection2"/> class.
		/// </summary>
		/// <param name="destination">The destination of the data. It's required that the destination collection has a factory set.</param>
		public DataProjectorToIEntityCollection( IEntityCollection destination )
		{
			if( destination == null )
			{
				throw new ArgumentNullException( "destination", "destination can't be null" );
			}
			if( destination.EntityFactoryToUse == null )
			{
				throw new ArgumentException( "destination doesn't have an EntityFactory set.", "destination" );
			}

			_destination = destination;
			IEntity newInstance = _destination.EntityFactoryToUse.Create();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( newInstance );

			_propertyDescriptors = new Hashtable( properties.Count );
			foreach( PropertyDescriptor descriptor in properties )
			{
				_propertyDescriptors.Add( descriptor.Name, descriptor );
			}
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
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="projectors">List of projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		private void AddProjectionResultToContainer( IList projectors, object[] rawProjectionResult )
		{
			IEntity newInstance = _destination.EntityFactoryToUse.Create();

			// set fields. This is done through property descriptors. 
			for( int i = 0; i < projectors.Count; i++ )
			{
				IProjector projector = (IProjector)projectors[i];
				IEntityField field = newInstance.Fields[projector.ProjectedResultName];
				object value = rawProjectionResult[i];
				if(( value !=null) && value.Equals( DBNull.Value ) )
				{
					value = null;
				}
				if( field == null )
				{
					// set via property descriptor
					PropertyDescriptor property = (PropertyDescriptor)_propertyDescriptors[((IProjector)projectors[i]).ProjectedResultName];
					if(property!=null)
					{
						property.SetValue( newInstance, value );
					}
				}
				else
				{
					// set through field object.
					if( field.IsReadOnly )
					{
						// just set the value, don't set dirty flags.
						field.ForcedCurrentValueWrite( value );
					}
					else
					{
						newInstance.SetNewFieldValue( field.FieldIndex, value );
					}
				}
			}
			_destination.Add( newInstance );
		}
	}


	/// <summary>
	/// Projector engine which projects raw projection result data onto new entities which are added to a single entitycollection.
	/// </summary>
	/// <remarks>Adapter specific</remarks>
	public class DataProjectorToIEntityCollection2 : IEntityDataProjector, IGeneralDataProjector
	{
		#region Class Member Declarations
		private IEntityCollection2 _destination;
		private Hashtable _propertyDescriptors;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DataProjectorToIEntityCollection2"/> class.
		/// </summary>
		/// <param name="destination">The destination of the data. It's required that the destination collection has a factory set.</param>
		public DataProjectorToIEntityCollection2(IEntityCollection2 destination )
		{
			if( destination == null )
			{
				throw new ArgumentNullException( "destination", "destination can't be null" );
			}
			if( destination.EntityFactoryToUse == null )
			{
				throw new ArgumentException( "destination doesn't have an EntityFactory set.", "destination" );
			}

			_destination = destination;
			IEntity2 newInstance = _destination.EntityFactoryToUse.Create();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( newInstance );

			_propertyDescriptors = new Hashtable( properties.Count );
			foreach( PropertyDescriptor descriptor in properties )
			{
				_propertyDescriptors.Add( descriptor.Name, descriptor );
			}
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
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="projectors">List of projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		private void AddProjectionResultToContainer( IList projectors, object[] rawProjectionResult )
		{
			IEntity2 newInstance = _destination.EntityFactoryToUse.Create();

			// set fields. This is done through property descriptors. 
			for( int i = 0; i < projectors.Count; i++ )
			{
				IProjector projector = (IProjector)projectors[i];
				IEntityField2 field = newInstance.Fields[projector.ProjectedResultName];
				object value = rawProjectionResult[i];
				if(( value !=null) && value.Equals( DBNull.Value ) )
				{
					value = null;
				}
				if( field == null )
				{
					// set via property descriptor
					PropertyDescriptor property = (PropertyDescriptor)_propertyDescriptors[((IProjector)projectors[i]).ProjectedResultName];
					if(property!=null)
					{
						property.SetValue( newInstance, value );
					}
				}
				else
				{
					// set through field object.
					if( field.IsReadOnly )
					{
						// just set the value, don't set dirty flags.
						field.ForcedCurrentValueWrite( value );
					}
					else
					{
						newInstance.SetNewFieldValue( field.FieldIndex, value );
					}
				}
			}

			_destination.Add( newInstance );
		}
	}
}
