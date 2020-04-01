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
	/// Class which implements a function call to a database function and which is used on an EntityField(2) in a query.
	/// </summary>
	[Serializable]
	public class DbFunctionCall : IDbFunctionCall, IExpression
	{
		#region Class Member Declarations
		private string _catalogName, _schemaName, _functionName;
		private object[] _parameters;
		private IFieldPersistenceInfo[] _fieldPersistenceInfos;
		private DbFunctionCallParameterType[] _parameterObjectTypes;

		[NonSerialized]
		private List<IDataParameter> _databaseParameters;
		[NonSerialized]
		private IDbSpecificCreator _creator;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="DbFunctionCall"/> class.
		/// </summary>
		/// <param name="functionName">Name of the function or pre-formatted function call string.</param>
		/// <param name="parameters">The parameters for the function to call. Can be null (which means: no parameters)</param>
		/// <remarks>If the function name is preformatted, schemaname and catalogname are ignored.</remarks>
		public DbFunctionCall(string functionName, object[] parameters)
			: this( string.Empty, string.Empty, functionName, parameters )
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="DbFunctionCall"/> class.
		/// </summary>
		/// <param name="schemaName">Name of the schema.</param>
		/// <param name="functionName">Name of the function or pre-formatted function call string.</param>
		/// <param name="parameters">The parameters for the function to call. Can be null (which means: no parameters)</param>
		/// <remarks>If the function name is preformatted, schemaname and catalogname are ignored.</remarks>
		public DbFunctionCall( string schemaName, string functionName, object[] parameters )
			: this( string.Empty, schemaName, functionName, parameters )
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="DbFunctionCall"/> class.
		/// </summary>
		/// <param name="catalogName">Name of the catalog.</param>
		/// <param name="schemaName">Name of the schema.</param>
		/// <param name="functionName">Name of the function or pre-formatted function call string.</param>
		/// <param name="parameters">The parameters for the function to call. Can be null (which means: no parameters)</param>
		/// <remarks>If the function name is preformatted, schemaname and catalogname are ignored.</remarks>
		public DbFunctionCall(string catalogName, string schemaName, string functionName, object[] parameters)
		{
			if( string.IsNullOrEmpty( functionName ) )
			{
				throw new ArgumentException( "functionName has to have a valid value.", "functionName" );
			}

			if( string.IsNullOrEmpty( schemaName ) && !string.IsNullOrEmpty( catalogName ) )
			{
				throw new ArgumentException( "You have to specify a schema name if you specify a catalog name.", "schemaName" );
			}

			_catalogName = catalogName;
			_schemaName = schemaName;
			_functionName = functionName;

			SetParameters( parameters );
		}


		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		public string ToQueryText( ref int uniqueMarker )
		{
			return ToQueryText( ref uniqueMarker, false );
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		public virtual string ToQueryText( ref int uniqueMarker, bool inHavingClause )
		{
			if( _creator == null )
			{
				throw new NullReferenceException( string.Format( "_creator isn't set so the function call '{0}' can't be converted to text.", _functionName ) );
			}

			_databaseParameters = new List<IDataParameter>();

			StringBuilder queryText = new StringBuilder();
			List<string> parameterFragments = CreateParameterFragments(ref uniqueMarker, inHavingClause);

			if(_functionName.IndexOf("{0}") >= 0)
			{
				// preformatted, ignore catalog/schema, use the string directly as the function call format.
				queryText.AppendFormat(null, _functionName, parameterFragments.ToArray());
			}
			else
			{
				FieldPersistenceInfo functionNameObject = new FieldPersistenceInfo(_catalogName, _schemaName, _functionName, string.Empty, false, 0, 0, 0, 0,
						false, string.Empty, null, null);
				string fullFunctionName = _functionName;
				if(_schemaName.Length > 0)
				{
					fullFunctionName = _creator.CreateObjectName(functionNameObject);
					// replace the function name with the real name, so without the appended [] or " or whatever character, IF the schema was specified. This
					// because CreateObjectName rightfully wraps the functionname within [] or ", but that doesn't work for system calls. 
					fullFunctionName = fullFunctionName.Replace(_creator.CreateValidAlias(_functionName), _functionName);
				}
				queryText.AppendFormat(null, "{0}(", fullFunctionName);
				for(int i = 0; i < parameterFragments.Count; i++)
				{
					if(i > 0)
					{
						queryText.Append(", ");
					}
					queryText.Append(parameterFragments[i]);
				}
				queryText.Append(")");
			}
			return queryText.ToString();
		}


		/// <summary>
		/// Creates the parameters text to embed in the query text.
		/// </summary>
		/// <param name="uniqueMarker">The unique marker.</param>
		/// <param name="inHavingClause">if set to <c>true</c> [in having clause].</param>
		/// <returns>
		/// the set of fragments, one for each function parameter, which is used to build the query text
		/// </returns>
		private List<string> CreateParameterFragments(ref int uniqueMarker, bool inHavingClause)
		{
			List<string> toReturn = new List<string>();

			for(int i = 0; i < _parameters.Length; i++)
			{
				object databaseParameter = _parameters[i];
				switch(_parameterObjectTypes[i])
				{
					case DbFunctionCallParameterType.Expression:
						IExpression parameterAsExpression = (IExpression)databaseParameter;
						parameterAsExpression.DatabaseSpecificCreator = _creator;
						toReturn.Add(parameterAsExpression.ToQueryText(ref uniqueMarker, inHavingClause));
						_databaseParameters.AddRange(parameterAsExpression.Parameters);
						break;
					case DbFunctionCallParameterType.Value:
						// a value, create a db parameter for it
						IDataParameter queryParameter = _creator.CreateParameter("LO" + databaseParameter.GetHashCode().ToString("x"),
							ParameterDirection.Input, databaseParameter);
						_databaseParameters.Add(queryParameter);
						uniqueMarker++;
						queryParameter.Value = databaseParameter;
						queryParameter.ParameterName += uniqueMarker.ToString();
						toReturn.Add(queryParameter.ParameterName);
						break;
					case DbFunctionCallParameterType.Field:
						IEntityFieldCore parameterAsField = (IEntityFieldCore)databaseParameter;
						// a field value. Create a full name for this field, which expands the expression and / or function call / aggregate set on the field. 
						toReturn.Add(_creator.CreateFieldName(parameterAsField, _fieldPersistenceInfos[i], parameterAsField.Name,
								parameterAsField.ObjectAlias, ref uniqueMarker, inHavingClause));
						if(parameterAsField.ExpressionToApply != null)
						{
							_databaseParameters.AddRange(parameterAsField.ExpressionToApply.Parameters);
						}
						break;
				}
			}

			return toReturn;
		}


		/// <summary>
		/// Sets the parameters.
		/// </summary>
		/// <param name="parameters">The parameters.</param>
		private void SetParameters( object[] parameters )
		{
			if(parameters==null)
			{
				_parameters = new object[0];
			}
			else
			{
				_parameters = parameters;
			}
			_fieldPersistenceInfos = new IFieldPersistenceInfo[_parameters.Length];
			_parameterObjectTypes = new DbFunctionCallParameterType[_parameters.Length];

			for( int i = 0; i < _parameters.Length; i++ )
			{
				if(_parameters[i] is IEntityFieldCore)
				{
					IFieldPersistenceInfo fieldInfo = _parameters[i] as IFieldPersistenceInfo;
					if( fieldInfo != null )
					{
						// self servicing field.
						_fieldPersistenceInfos[i] = fieldInfo;

					}
					_parameterObjectTypes[i] = DbFunctionCallParameterType.Field;
					continue;
				}
				if(_parameters[i] is IExpression)
				{
					_parameterObjectTypes[i] = DbFunctionCallParameterType.Expression;
					continue;
				}

				// value
				_parameterObjectTypes[i] = DbFunctionCallParameterType.Value;
			}
		}


		#region IExpression Members
		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		string IExpression.ToQueryText( ref int uniqueMarker )
		{
			return this.ToQueryText( ref uniqueMarker );
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained function call
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the complete query.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>
		/// The contained function call in textual format.
		/// </returns>
		/// <exception cref="System.ApplicationException">When IDbFunctionCall.DatabaseSpecificCreator is not set to a valid value.</exception>
		string IExpression.ToQueryText( ref int uniqueMarker, bool inHavingClause )
		{
			return this.ToQueryText( ref uniqueMarker, inHavingClause );
		}

		/// <summary>
		/// The list of parameters created when the Expression was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		/// <value></value>
		List<IDataParameter> IExpression.Parameters
		{
			get 
			{
				return this.DatabaseParameters;
			}
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
			get { return new ExpressionElement<IDbFunctionCall>(ExpressionElementType.FunctionCall, this); }
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
		/// The list of database parameters created when the DbFunctionCall was translated to text usable in a query. Only valid after a succesful call to ToQueryText
		/// </summary>
		/// <value></value>
		public List<System.Data.IDataParameter> DatabaseParameters
		{
			get { return _databaseParameters; }
		}

		/// <summary>
		/// Object which will be used to create valid parameter objects, field names, including prefix/postfix characters,
		/// and conversion routines, and field names, including prefix/postfix characters.
		/// Uses the strategy pattern so the generic code can work with more than one target database.
		/// </summary>
		/// <value></value>
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
		/// Gets or sets the name of the catalog the function is located in. Can be ignored on databases which don't support catalogs.
		/// </summary>
		/// <value>The name of the catalog.</value>
		/// <remarks>If catalog name isn't supplied, the function has to be present in the active catalog the user is connected with.</remarks>
		public string CatalogName
		{
			get
			{
				return _catalogName;
			}
			set
			{
				_catalogName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the schema the function is located in. Can be ignored on databases which don't support schemas.
		/// </summary>
		/// <value>The name of the schema.</value>
		/// <remarks>If schema name isn't supplied, the function has to be present in the default schema the user has access to in the current catalog.
		/// If you've specified a catalog, always specify the schema. If the function to call is a system function, don't specify schema nor catalog name.
		/// If the function name is preformatted, schemaname and catalogname are ignored.</remarks>
		public string SchemaName
		{
			get
			{
				return _schemaName;
			}
			set
			{
				_schemaName = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the function to call or pre-formatted function call string. This is without catalog or schema name.
		/// </summary>
		public string FunctionName
		{
			get
			{
				return _functionName;
			}
			set
			{
				_functionName = value;
			}
		}

		/// <summary>
		/// Gets the function parameters to pass to the function. You can pass fields and values to the function as parameters. A field can have a function call and/or
		/// expression applied to make nested function calls possible.
		/// </summary>
		/// <value>The function parameters.</value>
		public object[] FunctionParameters
		{
			get { return _parameters; }
			set { SetParameters( value ); }
		}


		/// <summary>
		/// Per field in FunctionParameters, this list contains the fieldPersistenceinfo object. If a parameter in FunctionParameters is not an IEntityFieldCore implementing
		/// object, the value for that parameter is null/Nothing.
		/// </summary>
		/// <value></value>
		public IFieldPersistenceInfo[] FieldPersistenceInfos
		{
			get { return _fieldPersistenceInfos; }
			set { _fieldPersistenceInfos = value; }
		}
		#endregion
	}
}
