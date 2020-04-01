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
using System.Collections;
using System.Text;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General class which defines the projection result and destination of a property of an entity.
	/// </summary>
	[Serializable]
	public class EntityPropertyProjector : IEntityPropertyProjector
	{
		#region Class Member Declarations
		private IEntityFieldCore _defaultValueProducer, _alternativeValueProducer;
		private IPredicate _valueFilter;
		private string _projectedResultName;
		private Type _valueType;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="EntityPropertyProjector"/> class.
		/// </summary>
		/// <param name="defaultValueProvider">The default value provider object.This object produces the value returned by ProjectEntityProperty if ValueFilter isn't set or resolves to true
		/// for the entity passed into ProjectEntityProperty. Can't be null</param>
		/// <param name="projectedResultName">Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// Can't be null / empty string</param>
		public EntityPropertyProjector( IEntityFieldCore defaultValueProvider, string projectedResultName )
			: this(defaultValueProvider, projectedResultName, null, null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="EntityPropertyProjector"/> class.
		/// </summary>
		/// <param name="defaultValueProvider">The default value provider object.This object produces the value returned by ProjectEntityProperty if ValueFilter isn't set or resolves to true
		/// for the entity passed into ProjectEntityProperty. Can't be null</param>
		/// <param name="projectedResultName">Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// Can't be null / empty string</param>
		/// <param name="valueFilter">The value filter which can be used to select between the DefaultValueProducer and the AlternativeValueProducer. If set to null, 
		/// alternativeValueProducer is ignored.</param>
		/// <param name="alternativeValueProducer">The alternative value producer. Only used if ValueFilter is set to a valid filter and that filter resolves to false for the
		/// entity passed into ProjectEntityProperty. Can't be null if valuefilter is specified</param>
		public EntityPropertyProjector( IEntityFieldCore defaultValueProvider, string projectedResultName, IPredicate valueFilter, IEntityFieldCore alternativeValueProducer )
			: this (defaultValueProvider, projectedResultName, valueFilter, alternativeValueProducer, null)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="EntityPropertyProjector"/> class.
		/// </summary>
		/// <param name="defaultValueProvider">The default value provider object.This object produces the value returned by ProjectEntityProperty if ValueFilter isn't set or resolves to true
		/// for the entity passed into ProjectEntityProperty. Can't be null</param>
		/// <param name="projectedResultName">Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// Can't be null / empty string</param>
		/// <param name="valueFilter">The value filter which can be used to select between the DefaultValueProducer and the AlternativeValueProducer. If set to null,
		/// alternativeValueProducer is ignored.</param>
		/// <param name="alternativeValueProducer">The alternative value producer. Only used if ValueFilter is set to a valid filter and that filter resolves to false for the
		/// entity passed into ProjectEntityProperty. Can't be null if valuefilter is specified</param>
		/// <param name="valueType">Type of the value returned by the value producers. This can be different from the actual value produced as you can change
		/// the type in an override of ValuePostProcess. If not set, it is set by ProjectEntityProperty to the type of the value producer selected</param>
		public EntityPropertyProjector( IEntityFieldCore defaultValueProvider, string projectedResultName, IPredicate valueFilter, 
			IEntityFieldCore alternativeValueProducer, Type valueType )
		{
			if( defaultValueProvider == null )
			{
				throw new ArgumentNullException( "defaultValueProvider", "defaultValueProvider can't be null" );
			}
			if( (projectedResultName == null) || ((projectedResultName != null) && (projectedResultName.Length <= 0)) )
			{
				throw new ArgumentNullException( "projectedResultName", "projectedResultName can't be null/empty string" );
			}
			InitClass( defaultValueProvider, alternativeValueProducer, valueFilter, projectedResultName, valueType );
		}


		/// <summary>
		/// Projects the entity through this entity property projector and results into a single value, based on what the DefaultValueProducer is and
		/// what filter is specified (if any)
		/// </summary>
		/// <param name="entity">The entity to project. The DefaultValueProducer, ValueFilter, AlternativeValueProducer and the method to post process
		/// the value will determine what the returned value is</param>
		/// <returns>
		/// Projection result of an entity's property using this entity property descriptor.
		/// </returns>
		public object ProjectEntityProperty( IEntityCore entity )
		{
			IEntityFieldCoreInterpret valueProducer = _defaultValueProducer as IEntityFieldCoreInterpret;
			if( valueProducer == null )
			{
				throw new ORMInterpretationException( "defaultValueProvider doesn't implement IEntityFieldCoreInterpret" );
			}

			if (( _valueFilter != null ) && (_alternativeValueProducer!=null))
			{
				if( !((IPredicateInterpret)_valueFilter).Interpret( entity ) )
				{
					valueProducer = _alternativeValueProducer as IEntityFieldCoreInterpret;
					if( valueProducer == null )
					{
						throw new ORMInterpretationException( "alternativeValueProducer doesn't implement IEntityFieldCoreInterpret" );
					}
				}
			}

			object toReturn = valueProducer.GetValue( entity );
			if( _valueType == null )
			{
				_valueType = ((IEntityFieldCore)valueProducer).DataType;
			}

			return ValuePostProcess( toReturn, entity );
		}


		/// <summary>
		/// Postprocesses the value passed in, which is the value produced by the selected value producer in ProjectEntityProperty.
		/// </summary>
		/// <param name="preliminaryProjectionResult">The preliminary projection result.</param>
		/// <param name="entity">The entity projected</param>
		/// <returns>the projection result processed by this routine. The base class version is empty and returns preliminaryProjectionResult</returns>
		protected virtual object ValuePostProcess(object preliminaryProjectionResult,IEntityCore entity)
		{
			return preliminaryProjectionResult;
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="defaultValueProducer">The default value producer.</param>
		/// <param name="alternativeValueProducer">The alternative value producer.</param>
		/// <param name="valueFilter">The value filter.</param>
		/// <param name="projectedResultName">Name of the projected result.</param>
		/// <param name="valueType">Type of the value.</param>
		private void InitClass( IEntityFieldCore defaultValueProducer, IEntityFieldCore alternativeValueProducer, IPredicate valueFilter, string projectedResultName, 
			Type valueType)
		{
			_defaultValueProducer = defaultValueProducer;
			_alternativeValueProducer = alternativeValueProducer;
			_valueFilter = valueFilter;
			_projectedResultName = projectedResultName;
			_valueType = valueType;
		}

		#region Class property declarations.
		/// <summary>
		/// Gets or sets the default value producer. This object produces the value returned by ProjectEntityProperty if ValueFilter isn't set or resolves to true
		/// for the entity passed into ProjectEntityProperty.
		/// </summary>
		/// <value></value>
		public IEntityFieldCore DefaultValueProducer
		{
			get
			{
				return _defaultValueProducer;
			}
			set
			{
				if( value == null )
				{
					throw new ArgumentNullException( "DefaultValueProvider", "DefaultValueProvider can't be null" );
				}
				_defaultValueProducer = value;
			}
		}

		/// <summary>
		/// Gets or sets the value filter which can be used to select between the DefaultValueProducer and the AlternativeValueProducer. If this filter isn't
		/// set (null) or set to an IPredicate implementing object and at runtime the filter resolves to true for the entity passed into ProjectEntityProperty,
		/// the DefaultValueProducer is used, otherwise the AlternativeValueProducer. If AlternativeValueProducer isn't set, an
		/// ORMInterpretationException is thrown.
		/// </summary>
		/// <value></value>
		public IPredicate ValueFilter
		{
			get
			{
				return _valueFilter;
			}
			set
			{
				_valueFilter = value;
			}
		}

		/// <summary>
		/// Gets or sets the alternative value producer. Only used if ValueFilter is set to a valid filter and that filter resolves to false for the
		/// entity passed into ProjectEntityProperty.
		/// </summary>
		/// <value></value>
		public IEntityFieldCore AlternativeValueProducer
		{
			get
			{
				return _alternativeValueProducer;
			}
			set
			{
				_alternativeValueProducer = value;
			}
		}

		/// <summary>
		/// Name for the projection result. Projection result consumers can use this name to further handle the projection result.
		/// </summary>
		/// <value></value>
		public string ProjectedResultName
		{
			get { return _projectedResultName; }
		}

		/// <summary>
		/// Gets or sets the type of the value returned by the value producers. This can be different from the actual value produced as you can change
		/// the type in an override of ValuePostProcess. If not set, it is set by ProjectEntityProperty to the type of the value producer selected
		/// </summary>
		/// <value>The type of the value.</value>
		public Type ValueType 
		{
			get { return _valueType; }
			set { _valueType = value; }
		}

		#endregion
	}
}
