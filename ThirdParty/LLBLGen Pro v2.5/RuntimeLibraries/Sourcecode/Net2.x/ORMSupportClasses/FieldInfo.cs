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

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General container class for static field information which is readonly at runtime and which is equal for all instances of a 
	/// given field. This information is shared among all instances of an entity, and therefore saves a lot of memory at runtime.
	/// </summary>
	[Serializable]
	public class FieldInfo : IFieldInfo
	{
		#region Class Member Declarations
		private string	_name, _containingObjectName, _actualContainingObjectName;
		private Type	_dataType;
		private bool	_isPrimaryKey, _isForeignKey, _isReadOnly, _isNullable, _isInMultiTargetEntity;
		private int		_fieldIndex, _maxLength;
		private byte	_scale, _precision;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="FieldInfo"/> class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="containingObjectName">Name of the containing object.</param>
		/// <param name="dataType">Type of the data.</param>
		/// <param name="isPrimaryKey">if set to <c>true</c> [is primary key].</param>
		/// <param name="isForeignKey">if set to <c>true</c> [is foreign key].</param>
		/// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
		/// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
		/// <param name="fieldIndex">Index of the field.</param>
		/// <param name="maxLength">Length of the max.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="precision">The precision.</param>
		public FieldInfo( string name, string containingObjectName, Type dataType, bool isPrimaryKey, bool isForeignKey, bool isReadOnly, bool isNullable,
			int fieldIndex, int maxLength, byte scale, byte precision )
		{
			InitClass(name, containingObjectName, dataType, isPrimaryKey, isForeignKey, isReadOnly, isNullable, fieldIndex, maxLength, scale, 
						precision);
		}


		/// <summary>
		/// Creates a clone of this FieldInfo object and adds 2 new elements: actualContainingObjectName and isInMultiTargetEntity
		/// </summary>
		/// <param name="actualContainingObjectName">Name of the actual containing object.</param>
		/// <param name="isInMultiTargetEntity">if set to <c>true</c> [is in multi target entity].</param>
		/// <returns>deep copy clone of this entity wit 2 new info elements</returns>
		internal FieldInfo CreateClone(string actualContainingObjectName, bool isInMultiTargetEntity)
		{
			FieldInfo toReturn = new FieldInfo(_name, _containingObjectName, _dataType, _isPrimaryKey, _isForeignKey, _isReadOnly, _isNullable, _fieldIndex, 
									_maxLength, _scale,	_precision);
			toReturn.SetActualContainingObjectName(actualContainingObjectName);
			toReturn.SetIsInMultiTargetEntity(isInMultiTargetEntity);
			return toReturn;
		}


		/// <summary>
		/// Sets the name of the actual containing object.
		/// </summary>
		/// <param name="actualContainingObjectName">Name of the actual containing object.</param>
		internal void SetActualContainingObjectName(string actualContainingObjectName)
		{
			_actualContainingObjectName = actualContainingObjectName;
		}


		/// <summary>
		/// Sets the is in multi target entity.
		/// </summary>
		/// <param name="isInMultiTargetEntity">if set to <c>true</c> [is in multi target entity].</param>
		internal void SetIsInMultiTargetEntity(bool isInMultiTargetEntity)
		{
			_isInMultiTargetEntity = isInMultiTargetEntity;
		}


		/// <summary>
		/// Inits the class.
		/// </summary>
		/// <param name="name">The name.</param>
		/// <param name="containingObjectName">Name of the containing object.</param>
		/// <param name="dataType">Type of the data.</param>
		/// <param name="isPrimaryKey">if set to <c>true</c> [is primary key].</param>
		/// <param name="isForeignKey">if set to <c>true</c> [is foreign key].</param>
		/// <param name="isReadOnly">if set to <c>true</c> [is read only].</param>
		/// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
		/// <param name="fieldIndex">Index of the field.</param>
		/// <param name="maxLength">Length of the max.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="precision">The precision.</param>
		private void InitClass(string name, string containingObjectName, Type dataType, bool isPrimaryKey, bool isForeignKey, bool isReadOnly, 
									bool isNullable, int fieldIndex, int maxLength, byte scale, byte precision)
		{
			_name = name;
			_containingObjectName = containingObjectName;
			_dataType = dataType;
			_isPrimaryKey = isPrimaryKey;
			_isForeignKey = isForeignKey;
			_isReadOnly = isReadOnly;
			_isNullable = isNullable;
			_fieldIndex = fieldIndex;
			_maxLength = maxLength;
			_scale = scale;
			_precision = precision;
			_actualContainingObjectName = string.Empty;
			_isInMultiTargetEntity = false;
		}


		#region Class Property Declarations
		/// <summary>
		/// The name of the field. Name cannot be of zero length nor can they consist of solely spaces. Leading and trailing spaces are trimmed.
		/// </summary>
		/// <value></value>
		/// <exception cref="ArgumentException">The value specified for Name is invalid.</exception>
		public string Name
		{
			get
			{
				return _name;
			}
		}

		/// <summary>
		/// The <see cref="System.Type"/> of the values of this field.
		/// </summary>
		/// <value></value>
		public Type DataType
		{
			get { return _dataType; }
		}

		/// <summary>
		/// If set to true, in the constructor, this field will end up in the PrimaryKey field list of the containing IEntityFields object.
		/// </summary>
		/// <value></value>
		public bool IsPrimaryKey
		{
			get { return _isPrimaryKey; }
		}

		/// <summary>
		/// Will be true if this field can be set to NULL in the database, false otherwise. The Field Validation logic in an entity will use this
		/// flag to check if the field indeed can be set to NULL or not. Set by constructor.
		/// </summary>
		/// <value></value>
		public bool IsNullable
		{
			get { return _isNullable; }
		}

		/// <summary>
		/// Gets the field index related to this IEntityField, so the field can be used to retrieve the field index.
		/// </summary>
		/// <value></value>
		public int FieldIndex
		{
			get { return _fieldIndex; }
		}

		/// <summary>
		/// Name of the containing object this field belongs to (entity or typed view). This name is required to retrieve persistence information in Adapter
		/// Set via constructor. This name is also used by EntityRelation to determine alias - table connection.
		/// </summary>
		/// <value></value>
		public string ContainingObjectName
		{
			get { return _containingObjectName; }
		}

		/// <summary>
		/// If set to true, in the constructor, this field is part of a foreign key. This field is not used in LLBLGen Pro's code, however
		/// can be useful in user code.
		/// </summary>
		/// <value></value>
		public bool IsForeignKey
		{
			get { return _isForeignKey; }
		}

		/// <summary>
		/// If set to true, in the constructor, no changes can be made to this field.
		/// </summary>
		/// <value></value>
		public bool IsReadOnly
		{
			get { return _isReadOnly; }
		}

		/// <summary>
		/// The maximum length of the value of the entityfield (string/binary data). Is ignored for entityfields which hold non-string and non-binary values.
		/// Value initially set for this field is the length of the database column this field is mapped on.
		/// </summary>
		/// <value></value>
		public int MaxLength
		{
			get
			{
				return _maxLength;
			}
		}

		/// <summary>
		/// The scale of the value for this field.
		/// Value initially set for this field is the scale of the database column this field is mapped on.
		/// </summary>
		/// <value></value>
		public byte Scale
		{
			get
			{
				return _scale;
			}
		}

		/// <summary>
		/// The precision of the value for this field.
		/// Value initially set for this field is the precision of the database column this field is mapped on.
		/// </summary>
		/// <value></value>
		public byte Precision
		{
			get
			{
				return _precision;
			}
		}

		/// <summary>
		/// The name of the object this field is currently in. Differs only from ContainingObjectName if the field instance is in a subtype while it is
		/// originally defined in a supertype. 
		/// </summary>
		/// <example>EmployeeEntity.Name and a subtype, ClerkEntity, inherits this field. For ClerkEntity.Name ContainingObjectName is still 'EmployeeEntity'
		/// however ActualContainingObjectName is 'ClerkEntity'.</example>
		public string ActualContainingObjectName
		{
			get 
			{
				if(_actualContainingObjectName.Length <= 0)
				{
					return _containingObjectName;
				}
				else
				{
					return _actualContainingObjectName;
				}
			}
		}


		/// <summary>
		/// Flag to signal if the field is in a multi-target entity. Used for alias production during query building in scenario's with inheritance.
		/// </summary>
		public bool IsInMultiTargetEntity 
		{
			get { return _isInMultiTargetEntity; }
		}

		#endregion
	}
}
