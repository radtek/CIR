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
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Implementation of a LIKE predicate expression, using the following formats:
	/// IEntityField(Core) LIKE Parameter (f.e. Foo LIKE @Foo )
	/// A specified pattern will be set as the parameters value.
	/// </summary>
	[Serializable]
	public class FieldLikePredicate : Predicate
	{
		#region Class Member Declarations
		private IEntityFieldCore		_field;
		private IFieldPersistenceInfo	_persistenceInfo;
		private string					_pattern, _objectAlias;
		private bool					_caseSensitiveCollation, _patternIsRegEx;

		[NonSerialized]
		private Regex					_patternRegEx;		// used for in-memory filtering.
		#endregion

		
		/// <summary>
		/// CTor
		/// </summary>
		public FieldLikePredicate()
		{
			InitClass(null, null, string.Empty, false, true, string.Empty, false);
		}


		#region SelfServicing Constructors
		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		public FieldLikePredicate(IEntityField field, string pattern)
		{
			InitClass(field, field, pattern, false, true, string.Empty, false);
		}


		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		public FieldLikePredicate(IEntityField field, string objectAlias, string pattern)
		{
			InitClass(field, field, pattern, false, true, objectAlias, false);
		}


		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldLikePredicate(IEntityField field, string pattern, bool negate)
		{
			InitClass(field, field, pattern, negate, true, string.Empty, false);
		}

		
		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldLikePredicate(IEntityField field, string objectAlias, string pattern, bool negate)
		{
			InitClass(field, field, pattern, negate, true, objectAlias, false);
		}
		#endregion


		#region Adapter Constructors
		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		public FieldLikePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string pattern)
		{
			InitClass(field, persistenceInfo, pattern, false, false, string.Empty, false);
		}


		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		public FieldLikePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string objectAlias, string pattern)
		{
			InitClass(field, persistenceInfo, pattern, false, false, objectAlias, false);
		}

		
		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldLikePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string pattern, bool negate)
		{
			InitClass(field, persistenceInfo, pattern, negate, false, string.Empty, false);
		}

		
		/// <summary>
		/// CTor for Field LIKE Pattern. 
		/// </summary>
		/// <param name="field">Field to compare with the LIKE operator</param>
		/// <param name="persistenceInfo">The persistence info object for the field</param>
		/// <param name="objectAlias">Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used). In that case, use another overload.</param>
		/// <param name="pattern">Pattern to use in the LIKE expression</param>
		/// <param name="negate">Flag to make this expression add NOT to itself</param>
		public FieldLikePredicate(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string objectAlias, string pattern, bool negate)
		{
			InitClass(field, persistenceInfo, pattern, negate, false, objectAlias, false);
		}
		#endregion


		/// <summary>
		/// Implements the IPredicate ToQueryText method. Retrieves a ready to use text representation of the contained Predicate.
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public override string ToQueryText(ref int uniqueMarker)
		{
			return ToQueryText(ref uniqueMarker, false);
		}

		/// <summary>
		/// Retrieves a ready to use text representation of the contained Predicate. 
		/// </summary>
		/// <param name="uniqueMarker">int counter which is appended to every parameter. The refcounter is increased by every parameter creation,
		/// making sure the parameter is unique in the predicate and also in the predicate expression(s) containing the predicate.</param>
		/// <param name="inHavingClause">if set to true, it will allow aggregate functions to be applied to fields.</param>
		/// <returns>The contained Predicate in textual format.</returns>
		/// <exception cref="System.ApplicationException">When IPredicate.DatabaseSpecificCreator is not set to a valid value.</exception>
		public override string ToQueryText(ref int uniqueMarker, bool inHavingClause)
		{
			if(_field==null)
			{
				return "";
			}

			if(base.DatabaseSpecificCreator==null)
			{
				throw new System.ApplicationException("DatabaseSpecificCreator object not set. Cannot create query part.");
			}

			base.Parameters.Clear();

			StringBuilder queryText = new StringBuilder(64);
			
			if(base.Negate)
			{
				queryText.Append("NOT ");
			}

			// create parameter 
			uniqueMarker++;
			IDataParameter parameter = base.DatabaseSpecificCreator.CreateLikeParameter(String.Format("{0}{1}", _field.Name, uniqueMarker), _pattern, _persistenceInfo.SourceColumnDbType);

			if(_caseSensitiveCollation)
			{
				queryText.AppendFormat(null, "{0}({1}) LIKE {2}", 
					base.DatabaseSpecificCreator.ToUpperFunctionName(),
					base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause), 
					parameter.ParameterName);
			}
			else
			{
				queryText.AppendFormat(null, "{0} LIKE {1}", 
					base.DatabaseSpecificCreator.CreateFieldName(_field, _persistenceInfo, _field.Name, _objectAlias, ref uniqueMarker, inHavingClause), 
					parameter.ParameterName);
			}

			// First the field's expression parameters
			if(_field.ExpressionToApply!=null)
			{
				for (int i = 0; i < _field.ExpressionToApply.Parameters.Count; i++)
				{
					base.Parameters.Add(_field.ExpressionToApply.Parameters[i]);
				}
			}

			// then the pattern parameter.
			base.Parameters.Add(parameter);
			return queryText.ToString();
		}


		/// <summary>
		/// Interprets this predicate on the passed in entity
		/// </summary>
		/// <param name="entity">The entity to interpret this predicate on</param>
		/// <returns>
		/// true if the predicate interpretation resolves to true, otherwise false.
		/// </returns>
		protected override bool InterpretPredicate( IEntityCore entity )
		{
			if( _field == null )
			{
				return false;
			}

			object fieldValue = ((IEntityFieldCoreInterpret)_field).GetValue( entity );
			if(( fieldValue == null ) || (fieldValue==DBNull.Value))
			{
				return false;
			}

			if( fieldValue.GetType() != typeof( string ) )
			{
				throw new ORMInterpretationException( string.Format( "The field '{0}' isn't of type string.", _field.Alias ) );
			}

			if( _pattern.Length <= 0 )
			{
				return true;
			}

			// now convert the pattern to a regular expression: every '%' should be replaced with '.*'. 
			string value = (string)fieldValue;
			if( _patternRegEx == null )
			{
				// create regex
				string regExPattern = string.Empty;
				if( _patternIsRegEx )
				{
					regExPattern = _pattern;
				}
				else
				{
					// check if there is a wildcard at the front / back. If not, specify that the regex we're creating has to match with the first char/
					// last char.

					// replace all regex chars to escapes. 
					StringBuilder patternCreator = new StringBuilder( _pattern );
					patternCreator = patternCreator.Replace( @"\", @"\\" );
					patternCreator = patternCreator.Replace( ".", @"\." );
					patternCreator = patternCreator.Replace( "$", @"\$" );
					patternCreator = patternCreator.Replace( "^", @"\^" );
					patternCreator = patternCreator.Replace( "{", @"\{" );
					patternCreator = patternCreator.Replace( "[", @"\[" );
					patternCreator = patternCreator.Replace( "(", @"\(" );
					patternCreator = patternCreator.Replace( "|", @"\|" );
					patternCreator = patternCreator.Replace( ")", @"\)" );
					patternCreator = patternCreator.Replace( "*", @"\*" );
					patternCreator = patternCreator.Replace( "+", @"\+" );
					patternCreator = patternCreator.Replace( "?", @"\?" );
					string patternToUse = patternCreator.ToString();

					if( patternToUse.IndexOf( "%" ) >=0 )
					{
						// wildcard specified. If it's specified at the start, append an assertion that it should match with the end of the string.
						// if it's specified at the end, specify an assertion that it should match with teh start of the string. 
						// if it's specified at both ends, don't append an assertion. If it's specified at no end (though in the middle), only add
						// an assertion for matching with the first character. 
						bool wildCardAtStart = patternToUse.StartsWith( "%" );
						bool wildCardAtEnd = patternToUse.EndsWith( "%" );
						if( wildCardAtStart && wildCardAtEnd )
						{
							// do nothing, match with every part of the string
							regExPattern = patternToUse;
						}
						if( wildCardAtStart && !wildCardAtEnd)
						{
							// make sure the match is at the end of the string
							regExPattern = patternToUse + "$";
						}
						if( !wildCardAtStart)
						{
							// make sure the match is at the start of the string
							regExPattern = @"^" + patternToUse;
						}

						// replace with regex wildcard
						regExPattern = regExPattern.Replace( "%", ".*" );
					}
					else
					{
						// match with start of string. 
						regExPattern = @"^" + patternToUse;
					}
				}
				if( _caseSensitiveCollation )
				{
					_patternRegEx = new Regex( regExPattern, RegexOptions.CultureInvariant );
				}
				else
				{
					_patternRegEx = new Regex( regExPattern, RegexOptions.CultureInvariant | RegexOptions.IgnoreCase );
				}
			}
			if( _caseSensitiveCollation )
			{
				value = value.ToUpper( CultureInfo.InvariantCulture );
			}

			MatchCollection matches = _patternRegEx.Matches( value );
			return ((matches.Count>0)^base.Negate);
		}


		/// <summary>
		/// Initializes the class
		/// </summary>
		/// <param name="field"></param>
		/// <param name="persistenceInfo"></param>
		/// <param name="pattern"></param>
		/// <param name="negate"></param>
		/// <param name="selfServicing"></param>
		/// <param name="objectAlias"></param>
		/// <param name="caseSensitiveCollation"></param>
		private void InitClass(IEntityFieldCore field, IFieldPersistenceInfo persistenceInfo, string pattern, bool negate, bool selfServicing, string objectAlias, bool caseSensitiveCollation)
		{
			_field = field;
			_persistenceInfo = persistenceInfo;
			_pattern = pattern;
			base.Negate=negate;
			base.SelfServicing = selfServicing;
			base.InstanceType = (int)PredicateType.FieldLikePredicate;
			_objectAlias = objectAlias;
			_caseSensitiveCollation = caseSensitiveCollation;
			_patternRegEx = null;
			_patternIsRegEx = false;
		}


		#region Class Property Declarations
		/// <summary>
		/// Field used in the comparison expression (SelfServicing).
		/// </summary>
		/// <exception cref="InvalidOperationException">if this object was constructed using a non-selfservicing constructor.</exception>
		public virtual IEntityField Field
		{
			get 
			{ 
				if(!base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a non-selfservicing constructor. Can't retrieve an IEntityField after that.");
				}
				return (IEntityField)_field; 
			}
		}

		/// <summary>
		/// Field used in the comparison expression (IEntityFieldCore).
		/// </summary>
		public virtual IEntityFieldCore FieldCore
		{
			get 
			{ 
				return _field; 
			}
		}

		/// <summary>
		/// Gets / sets persistenceInfo for field
		/// </summary>
		/// <exception cref="InvalidOperationException">When a value is set for this property and this object was created using a selfservicing constructor.</exception>
		public IFieldPersistenceInfo PersistenceInfo
		{
			get
			{
				return _persistenceInfo;
			}
			set
			{
				if(base.SelfServicing)
				{
					// not applicable
					throw new InvalidOperationException("This object was constructed using a selfservicing constructor. Can't set persistence info after that.");
				}
				_persistenceInfo = value;
			}
		}
		
		/// <summary>
		/// Gets / sets the pattern to use in a Field LIKE Pattern clause. 
		/// </summary>
		/// <remarks>if this predicate is used in in-memory filtering, this pattern can also be a regular expression, though in that case, don't use
		/// % characters but normal regular expression characters. If this pattern is a regular expression, set the flag PatternIsRegEx to true. 
		/// If PatternRegEx is false, the value of Pattern is considered a normal string with the standard LIKE syntaxis (i.e. with % as wildcard). 
		/// </remarks>
		public virtual string Pattern
		{
			get { return _pattern; }
			set 
			{ 
				_pattern = value;
				_patternRegEx = null;
			}
		}


		/// <summary>
		/// Gets or sets a value indicating whether the string specified in Pattern is a regular expression (true) or not (false). Only used for
		/// in-memory filtering, ignored when predicate is used in database filters. 
		/// </summary>
		public bool PatternIsRegEx
		{
			get { return _patternIsRegEx; }
			set { _patternIsRegEx = value; }
		}
		

		/// <summary>
		/// Alias for the object the field belongs to. Used to identify which entity to use when the entity
		/// is present multiple times in a relation collection. Alias has to match an alias specified in the relation collection or should be
		/// left empty if no alias is specified (or no relation collection is used).
		/// </summary>
		public string ObjectAlias
		{
			get
			{
				return _objectAlias;
			}
			set
			{
				_objectAlias = value;
			}
		}

		/// <summary>
		/// Gets / sets caseSensitiveCollation flag. If set to true, the UPPER() function (or db specific equivalent) is applied to the field. Default: false
		/// </summary>
		public bool CaseSensitiveCollation
		{
			get
			{
				return _caseSensitiveCollation;
			}
			set
			{
				_caseSensitiveCollation = value;
			}
		}

		#endregion
		
	}
}
