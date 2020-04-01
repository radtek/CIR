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
using System.ComponentModel;
using System.Collections;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Projector to project raw projection data onto a custom class.
	/// </summary>
	public class DataProjectorToCustomClass<T> : IEntityDataProjector, IGeneralDataProjector
		where T : class, new()
	{
		#region Class Member Declarations
		private List<T> _destination;
		private Dictionary<string, PropertyDescriptor> _propertyDescriptors;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="destination">destination collection of new projection results</param>
		public DataProjectorToCustomClass( List<T> destination )
		{
			if( destination == null )
			{
				throw new ArgumentNullException( "destination", "destination can't be null" );
			}

			_destination = destination;

			// cache descriptors.
			T dummy = new T();
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties( dummy );
			_propertyDescriptors = new Dictionary<string, PropertyDescriptor>( properties.Count );
			foreach( PropertyDescriptor property in properties )
			{
				_propertyDescriptors.Add( property.Name, property );
			}
		}


		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="propertyProjectors">List of property projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void IEntityDataProjector.AddProjectionResultToContainer( List<IEntityPropertyProjector> propertyProjectors, object[] rawProjectionResult )
		{
			this.AddProjectionResultToContainer( propertyProjectors, rawProjectionResult );
		}


		/// <summary>
		/// Adds a new projection result to the container contained into this instance. The container has to be set in the constructor.
		/// </summary>
		/// <param name="valueProjectors">List of value projectors used to create the projection result</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		void IGeneralDataProjector.AddProjectionResultToContainer( List<IDataValueProjector> valueProjectors, object[] rawProjectionResult )
		{
			this.AddProjectionResultToContainer( valueProjectors, rawProjectionResult );
		}


		/// <summary>
		/// Performs the actual projection. Override this method if you want to perform your own projections.
		/// </summary>
		/// <param name="projectors">The projectors.</param>
		/// <param name="rawProjectionResult">The raw projection result.</param>
		protected virtual void AddProjectionResultToContainer( IList projectors, object[] rawProjectionResult )
		{
			T newInstance = new T();

			for( int i = 0; i < projectors.Count; i++ )
			{
				PropertyDescriptor property = null;
				if( _propertyDescriptors.TryGetValue( ((IProjector)projectors[i]).ProjectedResultName, out property ) )
				{
					// has such a property, set it.
					object value = rawProjectionResult[i];
					if(( value !=null) && value.Equals( DBNull.Value ) )
					{
						value = null;
					}
					property.SetValue( newInstance, value );
				}
			}

			_destination.Add( newInstance );
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the property descriptors for the type this projector projects to. These descriptors are cached so multi-row projections are fast. 
		/// </summary>
		/// <value>The property descriptors.</value>
		protected Dictionary<string, PropertyDescriptor> PropertyDescriptors
		{
			get { return _propertyDescriptors; }
		}


		/// <summary>
		/// Gets the destination.
		/// </summary>
		/// <value>The destination.</value>
		public List<T> Destination
		{
			get { return _destination; }
		}
		#endregion
	}
}
