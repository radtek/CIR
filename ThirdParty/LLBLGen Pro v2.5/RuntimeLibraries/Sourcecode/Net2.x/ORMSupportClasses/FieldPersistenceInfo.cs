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
using System.ComponentModel;
using System.Runtime.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Generic class which holds the generic information for entity field persistence of an entity field. Instances of this interface
	/// are passed to logic with an instance of the IEntityFieldCore interface. SelfServicing implements both interfaces in one interface: IEntityField.
	/// Generic
	/// </summary>
	[Serializable]
	public class FieldPersistenceInfo: IFieldPersistenceInfo, ISerializable
	{
		#region Class Member Declarations
		private	string			_sourceColumnName, _sourceObjectName, _sourceSchemaName, _identityValueSequenceName, _sourceCatalogName;
		private bool			_isSourceColumnNullable, _isIdentity;
		private int				_sourceColumnMaxLength, _sourceColumnDbType;
		private byte			_sourceColumnScale, _sourceColumnPrecision;
		private Type			_actualDotNetType;

		[NonSerialized]
		private TypeConverter	_typeConverterToUse;
		#endregion
		

		/// <summary>
		/// CTor. Necessary for serialization. Do not use this CTor in code.
		/// </summary>
		public FieldPersistenceInfo()
		{
			_sourceColumnName = String.Empty;
			_sourceObjectName = String.Empty;
			_sourceSchemaName = String.Empty;
			_sourceCatalogName = String.Empty;
			_identityValueSequenceName = String.Empty;
			_typeConverterToUse = null;
			_actualDotNetType = null;
		}

		
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="sourceSchemaName">The name of the schema which holds SourceObjectName. Schema is used to generate SQL on the fly.
		/// A common schema name in SqlServer is f.e. 'dbo'.</param>
		/// <param name="sourceObjectName">The name of the source object which holds SourceColumnName. Can be a view or a table.
		/// Used to generate SQL on the fly.</param>
		/// <param name="sourceColumnName">The name of the corresponding column in a view or table for the corresponding entity/view field. This name is used
		/// to map a column in a resultset onto the entity field.</param>
		/// <param name="isSourceColumnNullable">Flag if the Column mapped is nullable or not.</param>
		/// <param name="sourceColumnDbType">The type of the Column. The value stored here is the integer representation of the enum value of the type, f.e.
		/// SqlDbType.Int or OracleType.Int16</param>
		/// <param name="sourceColumnMaxLength">The maximum length of the value for this column (string/binary data).
		/// Is ignored for columns which hold non-string and non-binary values.</param>
		/// <param name="sourceColumnScale">The scale of the Column mapped onto the entityfield.</param>
		/// <param name="sourceColumnPrecision">The precision of the Column mapped onto the entityfield.</param>
		/// <param name="isIdentity">If set to true, the Dynamic Query Engine (DQE) will assume the field is an Identity field and will act
		/// accordingly (i.e.: as the target database handles Identity fields: SqlServer will generate a new value itself, Oracle wants to have a
		/// sequence input.</param>
		/// <param name="identityValueSequenceName">If isIdentity is set to true, this property has to be set to the name of the sequence which
		/// supplies the value for the column. On SqlServer this is @@IDENTITY or SCOPE_IDENTITY() and only used when the row is succesfully
		/// inserted, however on Oracle f.e. this value is used to specify a new value and to retrieve the new value. Is undefined when
		/// isIdentity is set to false.</param>
		/// <param name="typeConverterToUse">Type converter set when a conversion is required from the .NET type returned by the ADO.NET provider and the defined .NET type for this field.</param>
		/// <param name="actualDotNetType">The .NET type of the field in the DB. This value is used to convert a currentvalue back to this type using TypeConverterToUse. </param>
		public FieldPersistenceInfo(string sourceSchemaName, string sourceObjectName, string sourceColumnName, 
			bool isSourceColumnNullable, int sourceColumnDbType, int sourceColumnMaxLength, byte sourceColumnScale, byte sourceColumnPrecision, 
			bool isIdentity, string identityValueSequenceName, TypeConverter typeConverterToUse, Type actualDotNetType)
		{
			InitClass(String.Empty, sourceSchemaName, sourceObjectName, sourceColumnName, isSourceColumnNullable, 
				sourceColumnDbType, sourceColumnMaxLength, sourceColumnScale, sourceColumnPrecision, isIdentity, identityValueSequenceName, typeConverterToUse, actualDotNetType);
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="sourceCatalogName">The name of the catalog the sourceSchemaName is in.</param>
		/// <param name="sourceSchemaName">The name of the schema which holds SourceObjectName. Schema is used to generate SQL on the fly.
		/// A common schema name in SqlServer is f.e. 'dbo'.</param>
		/// <param name="sourceObjectName">The name of the source object which holds SourceColumnName. Can be a view or a table. 
		/// Used to generate SQL on the fly.</param>
		/// <param name="sourceColumnName">The name of the corresponding column in a view or table for the corresponding entity/view field. This name is used 
		/// to map a column in a resultset onto the entity field.</param>
		/// <param name="isSourceColumnNullable">Flag if the Column mapped is nullable or not. </param>
		/// <param name="sourceColumnDbType">The type of the Column. The value stored here is the integer representation of the enum value of the type, f.e.
		/// SqlDbType.Int or OracleType.Int16</param>
		/// <param name="sourceColumnMaxLength">The maximum length of the value for this column (string/binary data). 
		/// Is ignored for columns which hold non-string and non-binary values.</param>
		/// <param name="sourceColumnScale">The scale of the Column mapped onto the entityfield.</param>
		/// <param name="sourceColumnPrecision">The precision of the Column mapped onto the entityfield.</param>
		/// <param name="isIdentity">If set to true, the Dynamic Query Engine (DQE) will assume the field is an Identity field and will act 
		/// accordingly (i.e.: as the target database handles Identity fields: SqlServer will generate a new value itself, Oracle wants to have a 
		/// sequence input.</param>
		/// <param name="identityValueSequenceName">If isIdentity is set to true, this property has to be set to the name of the sequence which 
		/// supplies the value for the column. On SqlServer this is @@IDENTITY or SCOPE_IDENTITY() and only used when the row is succesfully 
		/// inserted, however on Oracle f.e. this value is used to specify a new value and to retrieve the new value. Is undefined when 
		/// isIdentity is set to false.</param>
		/// <param name="typeConverterToUse">Type converter set when a conversion is required from the .NET type returned by the ADO.NET provider and the defined .NET type for this field.</param>
		/// <param name="actualDotNetType">The .NET type of the field in the DB. This value is used to convert a currentvalue back to this type using TypeConverterToUse. </param>
		public FieldPersistenceInfo(string sourceCatalogName, string sourceSchemaName, string sourceObjectName, string sourceColumnName, 
			bool isSourceColumnNullable, int sourceColumnDbType, int sourceColumnMaxLength, byte sourceColumnScale, byte sourceColumnPrecision, 
			bool isIdentity, string identityValueSequenceName, TypeConverter typeConverterToUse, Type actualDotNetType)
		{
			InitClass(sourceCatalogName, sourceSchemaName, sourceObjectName, sourceColumnName, isSourceColumnNullable, 
				sourceColumnDbType, sourceColumnMaxLength, sourceColumnScale, sourceColumnPrecision, isIdentity, identityValueSequenceName, typeConverterToUse, actualDotNetType);
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="FieldPersistenceInfo"/> class.
		/// </summary>
		/// <param name="info">The info.</param>
		/// <param name="context">The context.</param>
		protected FieldPersistenceInfo(SerializationInfo info, StreamingContext context)
		{
			_sourceColumnName = info.GetString("_sourceColumnName");
			_sourceObjectName = info.GetString("_sourceObjectName");
			_sourceSchemaName = info.GetString("_sourceSchemaName");
			_identityValueSequenceName = info.GetString("_identityValueSequenceName");
			_sourceCatalogName = info.GetString("_sourceCatalogName");
			_isSourceColumnNullable = info.GetBoolean("_isSourceColumnNullable");
			_isIdentity = info.GetBoolean("_isIdentity");
			_sourceColumnMaxLength = info.GetInt32("_sourceColumnMaxLength");
			_sourceColumnDbType = info.GetInt32("_sourceColumnDbType");
			_sourceColumnScale = info.GetByte("_sourceColumnScale");
			_sourceColumnPrecision = info.GetByte("_sourceColumnPrecision");
			_actualDotNetType = (Type)info.GetValue("_actualDotNetType", typeof(Type));
			object value = info.GetValue("_typeConverterToUse", typeof(Type));
			if(value != null)
			{
				try
				{
					_typeConverterToUse = (TypeConverter)Activator.CreateInstance((Type)value);
				}
				catch
				{
					// apparently type isn't available, swallow, as we can't do a thing about it. 
				}
			}
		}

		
		/// <summary>
		/// ISerializable member. Does custom serialization so event handlers do not get serialized.
		/// </summary>
		/// <param name="info">See ISerializable</param>
		/// <param name="context">See ISerialilzable</param>
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_sourceColumnName", _sourceColumnName);
			info.AddValue("_sourceObjectName", _sourceObjectName);
			info.AddValue("_sourceSchemaName", _sourceSchemaName);
			info.AddValue("_identityValueSequenceName", _identityValueSequenceName);
			info.AddValue("_sourceCatalogName", _sourceCatalogName);
			info.AddValue("_isSourceColumnNullable", _isSourceColumnNullable);
			info.AddValue("_isIdentity", _isIdentity);
			info.AddValue("_sourceColumnMaxLength", _sourceColumnMaxLength);
			info.AddValue("_sourceColumnDbType", _sourceColumnDbType);
			info.AddValue("_sourceColumnScale", _sourceColumnScale);
			info.AddValue("_sourceColumnPrecision", _sourceColumnPrecision);
			info.AddValue("_actualDotNetType", _actualDotNetType);
			if(_typeConverterToUse == null)
			{
				info.AddValue("_typeConverterToUse", null);
			}
			else
			{
				info.AddValue("_typeConverterToUse", _typeConverterToUse.GetType());
			}
		}


		/// <summary>
		/// Initializes the class' member variables. for parameter descriptions, see the constructor(s).
		/// </summary>
		/// <param name="sourceCatalogName">Name of the source catalog.</param>
		/// <param name="sourceSchemaName">Name of the source schema.</param>
		/// <param name="sourceObjectName">Name of the source object.</param>
		/// <param name="sourceColumnName">Name of the source column.</param>
		/// <param name="isSourceColumnNullable"><see langword="true"/> if [is source column nullable]; otherwise, <see langword="false"/>.</param>
		/// <param name="sourceColumnDbType">Type of the source column db.</param>
		/// <param name="sourceColumnMaxLength">Length of the source column max.</param>
		/// <param name="sourceColumnScale">Source column scale.</param>
		/// <param name="sourceColumnPrecision">Source column precision.</param>
		/// <param name="isIdentity"><see langword="true"/> if [is identity]; otherwise, <see langword="false"/>.</param>
		/// <param name="identityValueSequenceName">Name of the identity value sequence.</param>
		/// <param name="typeConverterToUse">Type converter to use.</param>
		/// <param name="actualDotNetType">Type of the actual dot net.</param>
		private void InitClass(string sourceCatalogName, string sourceSchemaName, string sourceObjectName, string sourceColumnName, bool isSourceColumnNullable, 
			int sourceColumnDbType, int sourceColumnMaxLength, byte sourceColumnScale, 
			byte sourceColumnPrecision, bool isIdentity, string identityValueSequenceName, TypeConverter typeConverterToUse, Type actualDotNetType)
		{
			_sourceCatalogName = sourceCatalogName;
			_sourceSchemaName = sourceSchemaName;
			_sourceObjectName = sourceObjectName;
			_sourceColumnName = sourceColumnName;
			_isSourceColumnNullable = isSourceColumnNullable;
			_sourceColumnDbType = sourceColumnDbType;
			_sourceColumnMaxLength = sourceColumnMaxLength;
			_sourceColumnPrecision = sourceColumnPrecision;
			_sourceColumnScale = sourceColumnScale;
			_isIdentity = isIdentity;
			_identityValueSequenceName = identityValueSequenceName;
			_typeConverterToUse = typeConverterToUse;
			_actualDotNetType = actualDotNetType;
		}


		#region Class Property Declarations
		/// <summary>
		/// The .NET type of the field in the DB. This value is used to convert a currentvalue back to this type using TypeConverterToUse. 
		/// </summary>
		public Type ActualDotNetType 
		{ 
			get { return _actualDotNetType; }
		}

		/// <summary>
		/// The name of the catalog the SourceSchemaName is located in. 
		/// </summary>
		public string SourceCatalogName
		{
			get
			{
				return _sourceCatalogName;
			}
		}

		
		/// <summary>
		/// The name of the schema which holds <see cref="SourceObjectName"/>. Schema is used to generate SQL on the fly. 
		/// A common schema name in SqlServer is f.e. 'dbo'.
		/// </summary>
		public string SourceSchemaName 
		{
			get { return _sourceSchemaName; }
		}
			
		/// <summary>
		/// The name of the source object which holds <see cref="SourceColumnName"/>. Can be a view or a table. Used to generate SQL on the fly.
		/// </summary>
		public string SourceObjectName 
		{
			get { return _sourceObjectName; }
		}
			

		/// <summary>
		/// The name of the corresponding column in a view or table for this entityfield. This name is used to map a column in a resultset onto the entity field.
		/// Used for update/insert operations on the column
		/// </summary>
		public string SourceColumnName 
		{
			get { return _sourceColumnName; }
		}
		
		/// <summary>
		/// The maximum length of the value of this entityfield (string/binary data). Is ignored for entityfields which hold non-string and non-binary values.
		/// ColumnMaxLength
		/// Used for update/insert operations on the column
		/// </summary>
		public int SourceColumnMaxLength
		{
			get { return _sourceColumnMaxLength; }
		}
		
		/// <summary>
		/// The type of the Column mapped onto the EntityField. The value stored here is the integer representation of the enum value of the type, f.e.
		/// SqlDbType.Int or OracleType.Int16
		/// Used for update/insert operations on the column
		/// </summary>
		public int SourceColumnDbType
		{
			get { return _sourceColumnDbType; }
		}
		
		/// <summary>
		/// Flag if the Column mapped onto the entityfield is nullable or not. 
		/// Used for update/insert operations on the column
		/// </summary>
		public bool SourceColumnIsNullable
		{
			get { return _isSourceColumnNullable; }
		}
		
		/// <summary>
		/// The scale of the Column mapped onto the entityfield.
		/// Used for update/insert operations on the column
		/// </summary>
		public byte SourceColumnScale
		{
			get { return _sourceColumnScale; }
		}
		
		/// <summary>
		/// The precision of the Column mapped onto the entityfield.
		/// Used for update/insert operations on the column
		/// </summary>
		public byte SourceColumnPrecision
		{
			get { return _sourceColumnPrecision; }
		}

		
		/// <summary>
		/// If set to true, the Dynamic Query Engine (DQE) will assume the field is an Identity field and will act accordingly (i.e.: as the target database
		/// handles Identity fields: SqlServer will generate a new value itself, Oracle wants to have a sequence input.
		/// </summary>
		public bool IsIdentity 
		{
			get { return _isIdentity; }
		}

		/// <summary>
		/// If <see cref="IsIdentity"/> is set to true, this property has to be set to the name of the sequence which supplies the value for the EntityField's
		/// corresponding table field. On SqlServer this is @@IDENTITY or SCOPE_IDENTITY() and only used when the row is succesfully inserted, however on Oracle
		/// f.e. this value is used to specify a new value and to retrieve the new value. Is undefined when <see cref="IsIdentity"/> is set to false.
		/// </summary>
		public string IdentityValueSequenceName 
		{
			get { return _identityValueSequenceName; } 
		}

		/// <summary>
		/// Gets the type converter to use. Only set through constructor and when a conversion is required from the .NET type returned by the 
		/// ADO.NET provider and the defined .NET type for this field.
		/// </summary>
		public TypeConverter TypeConverterToUse 
		{ 
			get { return _typeConverterToUse;}
		}
		#endregion

	}
}
