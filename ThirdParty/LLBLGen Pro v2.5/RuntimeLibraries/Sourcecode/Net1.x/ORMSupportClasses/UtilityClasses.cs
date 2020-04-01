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
//		- Simon Hewitt
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Text;
#if !CF
using System.Runtime.Serialization;
#endif
using System.Diagnostics;
using System.Threading;
using System.Globalization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Class which is used for specifying fields to exclude or include in a fetch. 
	/// If an instance of this list is passed to a fetch method which accepts an ExcludeIncludeFieldsList, the fields in this list
	/// are either excluded from the query (if ExcludeContainedFields is true (default)), or are used to exclude the rest of the 
	/// fields in the query except the fields in this list. 
	/// </summary>
	[Serializable]
	public class ExcludeIncludeFieldsList : ArrayList
	{
		#region Class Member Declarations
		private bool _excludeContainedFields;
		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="ExcludeIncludeFieldsList"/> class.
		/// </summary>
		public ExcludeIncludeFieldsList() : this(true)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ExcludeIncludeFieldsList"/> class.
		/// </summary>
		/// <param name="excludeContainedFields">if set to <c>true</c> [exclude contained fields].</param>
		public ExcludeIncludeFieldsList(bool excludeContainedFields)
			: base()
		{
			_excludeContainedFields = excludeContainedFields;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ExcludeIncludeFieldsList"/> class.
		/// </summary>
		/// <param name="fields">The fields to be added to this list.</param>
		public ExcludeIncludeFieldsList(ICollection fields)
			: this(true, fields)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ExcludeIncludeFieldsList"/> class.
		/// </summary>
		/// <param name="excludeContainedFields">if set to <c>true</c> [exclude contained fields].</param>
		/// <param name="fields">The fields.</param>
		public ExcludeIncludeFieldsList(bool excludeContainedFields, ICollection fields)
			: base (fields)
		{
			_excludeContainedFields = excludeContainedFields;
		}


		/// <summary>
		/// Builds the fields to exclude list to start with from the fields passed in combined with the fields contained in this collection based on
		/// the ExcludeContainedFields setting
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <returns>list of fields to exclude from the passed in set of fields. This list isn't checked for illegal excluded fields, so has to be
		/// filtered after this call.</returns>
		internal IList BuildFieldsToExcludeList(IEntityFields2 fields)
		{
			ArrayList fieldsToWorkWith = new ArrayList();
			foreach(IEntityField2 field in fields)
			{
				fieldsToWorkWith.Add(field);
			}

			return BuildFieldsToExcludeList(fieldsToWorkWith);
		}


		/// <summary>
		/// Builds the fields to exclude list to start with from the fields passed in combined with the fields contained in this collection based on
		/// the ExcludeContainedFields setting
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <returns>list of fields to exclude from the passed in set of fields. This list isn't checked for illegal excluded fields, so has to be
		/// filtered after this call.</returns>
		internal IList BuildFieldsToExcludeList(IEntityFields fields)
		{
			ArrayList fieldsToWorkWith = new ArrayList();
			foreach(IEntityField field in fields)
			{
				fieldsToWorkWith.Add(field);
			}

			return BuildFieldsToExcludeList(fieldsToWorkWith);
		}


		/// <summary>
		/// Builds the fields to exclude list to start with from the fields passed in combined with the fields contained in this collection based on
		/// the ExcludeContainedFields setting
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <returns>list of fields to exclude from the passed in set of fields. This list isn't checked for illegal excluded fields, so has to be
		/// filtered after this call.</returns>
		internal IList BuildFieldsToExcludeList(ArrayList fields)
		{
			ArrayList toReturn = new ArrayList();
			if(_excludeContainedFields)
			{
				// simply add the contents of this object to the list to return
				toReturn.AddRange(this);
			}
			else
			{
				// add all fields passed in to the list to return and filter out fields in this object.
				foreach(IEntityFieldCore field in fields)
				{
					// check if this field is in this object. If so, skip it (as we're building a list of fields to exclude) otherwise use it.
					bool excludeField = true;
					foreach(IEntityFieldCore toCheck in this)
					{
						if((toCheck.ContainingObjectName == field.ContainingObjectName) && (toCheck.Name == field.Name))
						{
							// contained in this object, skip it.
							excludeField = false;
							break;
						}

					}
					if(excludeField)
					{
						toReturn.Add(field);
					}
				}
			}

			return toReturn;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets the flag ExcludeContainedFields, which should be set to true if the fields in this list should be excluded
		/// and which should be false if the fields should be used as the fields to fetch and exclude the rest. <br/>
		/// Default is true.
		/// </summary>
		public bool ExcludeContainedFields
		{
			get
			{
				return _excludeContainedFields;
			}
			set
			{
				_excludeContainedFields = value;
			}
		}
		#endregion
	}


#if !CF
	/// <summary>
	/// This class is by Ian Griffiths, see: http://www.interact-sw.co.uk/iangblog/2004/04/26/yetmoretimedlocking
	/// 
	/// [FB]Comment below is by Ian as well. Class is left as-is with very minor changes in comments and code placement.
	/// 
	/// Thanks to Eric Gunnerson for recommending this be a struct rather
	/// than a class - avoids a heap allocation.
	/// Thanks to Change Gillespie and Jocelyn Coulmance for pointing out
	/// the bugs that then crept in when I changed it to use struct...
	/// Thanks to John Sands for providing the necessary incentive to make
	/// me invent a way of using a struct in both release and debug builds
	/// without losing the debug leak tracking.
	/// </summary>
	public struct TimedLock : IDisposable
	{
		#region Class Member Declarations
		private object _target;
		private const int DEFAULTTIMEOUT = 10;		// in seconds
#if DEBUG
		private Sentinel _leakDetector;
#endif
		#endregion

		/// <summary>
		/// Locks the specified o.
		/// </summary>
		/// <param name="o">The o.</param>
		/// <returns></returns>
		public static TimedLock Lock(object o)
		{
			return Lock(o, TimeSpan.FromSeconds(DEFAULTTIMEOUT));
		}

		/// <summary>
		/// Locks the specified o.
		/// </summary>
		/// <param name="o">The o.</param>
		/// <param name="timeout">The timeout.</param>
		/// <returns></returns>
		public static TimedLock Lock(object o, TimeSpan timeout)
		{
			TimedLock tl = new TimedLock(o);
			if(!Monitor.TryEnter(o, timeout))
			{
#if DEBUG
				System.GC.SuppressFinalize(tl._leakDetector);
#endif
				throw new ORMLockTimeoutException();
			}

			return tl;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TimedLock"/> class.
		/// </summary>
		/// <param name="o">The o.</param>
		private TimedLock(object o)
		{
			_target = o;
#if DEBUG
			_leakDetector = new Sentinel();
#endif
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or
		/// resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Monitor.Exit(_target);

			// It's a bad error if someone forgets to call Dispose,
			// so in Debug builds, we put a finalizer in to detect
			// the error. If Dispose is called, we suppress the
			// finalizer.
#if DEBUG
			GC.SuppressFinalize(_leakDetector);
#endif
		}

#if DEBUG
		// (In Debug mode, we make it a class so that we can add a finalizer
		// in order to detect when the object is not freed.)
		private class Sentinel
		{
			~Sentinel()
			{
				// If this finalizer runs, someone somewhere failed to
				// call Dispose, which means we've failed to leave
				// a monitor!
				System.Diagnostics.Debug.Fail("Undisposed lock");
			}
		}
#endif
	}
#endif


	/// <summary>
	/// Small class which helps with versioning in binary normal serialization code. It allows swallowing of exceptions which occur when 
	/// incompatible binary data is deserialized with newer code which expects members to be there.
	/// </summary>
	public class SerializationUtils
	{
		/// <summary>
		/// Private CTor
		/// </summary>
		private SerializationUtils()
		{
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, an empty string is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be string field</param>
		/// <returns>the value read from info, otherwise an empty string</returns>
		public static string InfoGetString(SerializationInfo info, string fieldName)
		{
			return InfoGetString(info, fieldName, string.Empty);
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, an empty string is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be string field</param>
		/// <param name="defaultValue">the default value to return, if the value to deserialize isn't found</param>
		/// <returns>the value read from info, otherwise an empty string</returns>
		public static string InfoGetString(SerializationInfo info, string fieldName, string defaultValue)
		{
			string toReturn = defaultValue;
			try
			{
				toReturn = info.GetString(fieldName);
			}
			catch(SerializationException)
			{
				// swallow
			}
			return toReturn;
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, false is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be boolean field</param>
		/// <returns>the value read from info, otherwise false</returns>
		public static bool InfoGetBoolean(SerializationInfo info, string fieldName)
		{
			bool toReturn = false;
			try
			{
				toReturn = info.GetBoolean(fieldName);
			}
			catch(SerializationException)
			{
				// swallow. the field wasn't there.
			}
			return toReturn;
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, 0 is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be boolean field</param>
		/// <returns>the value read from info, otherwise false</returns>
		public static int InfoGetInt32(SerializationInfo info, string fieldName)
		{
			return InfoGetInt32(info, fieldName, 0);
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, 0 is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be boolean field</param>
		/// <param name="defaultValue">the value to return if the value to deserialize isn't found</param>
		/// <returns>the value read from info, otherwise false</returns>
		public static int InfoGetInt32(SerializationInfo info, string fieldName, int defaultValue)
		{
			int toReturn = defaultValue;
			try
			{
				toReturn = info.GetInt32(fieldName);
			}
			catch(SerializationException)
			{
				// swallow. the field wasn't there.
			}
			return toReturn;
		}

		/// <summary>
		/// Will try to read the value for the field named as the name specified in fieldName.
		/// If the field doesn't exist, null is returned.
		/// </summary>
		/// <param name="info">info structure which values.</param>
		/// <param name="fieldName">name of field to read. Must be boolean field</param>
		/// <param name="typeOfValue">type of the value to read</param>
		/// <returns>the value read from info, otherwise false</returns>
		public static object InfoGetValue(SerializationInfo info, string fieldName, Type typeOfValue)
		{
			object toReturn = null;
			try
			{
				toReturn = info.GetValue(fieldName, typeOfValue);
			}
			catch(SerializationException)
			{
				// swallow. the field wasn't there.
			}
			catch(InvalidCastException)
			{
				// swallow, object changed type
			}
			return toReturn;
		}
	}

	/// <summary>
	/// Class which contains utility methods used for data projection.
	/// </summary>
	internal class ProjectionUtils
	{
		/// <summary>
		/// Creates the hash value for an array of values, and uses all values in the array to produce the hashvalue.
		/// </summary>
		/// <param name="projectors">The projectors.</param>
		/// <param name="values">The values.</param>
		/// <returns>Hashvalue which represents the passed in array of values.</returns>
		internal static int CreateHashValueFromValues( IList projectors, object[] values )
		{
			int hashValue = 0;
			for( int i = 0; i < values.Length; i++ )
			{
				if(( values[i] == null )||(values[i]==DBNull.Value))
				{
					hashValue = DBNull.Value.GetHashCode();
					continue;
				}
				if( ((IProjector)projectors[i]).ValueType.IsArray )
				{
					Array valueAsArray = values[i] as Array;
					int tmpHashValue = 0;
					for( int j = 0; j < valueAsArray.Length; j++ )
					{
						tmpHashValue ^= valueAsArray.GetValue( j ).GetHashCode();
					}
					hashValue ^= tmpHashValue;
				}
				else
				{
					hashValue ^= values[i].GetHashCode();
				}
			}
			return hashValue;
		}


		/// <summary>
		/// creates a projection from the passed in reader, using the client side specifications provided.
		/// </summary>
		/// <param name="valueProjectors">The value projectors.</param>
		/// <param name="projector">The projector.</param>
		/// <param name="datasource">The datareader to read from</param>
		/// <param name="maxNumberOfItemsToReturn">The max number of items to return.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="clientSideLimitation">if set to <c>true</c> [client side limitation].</param>
		/// <param name="clientSideDistinctFiltering">if set to <c>true</c> [client side distinct filtering].</param>
		/// <param name="clientSidePaging">if set to <c>true</c> [client side paging].</param>
		internal static void FetchProjectionFromReader( ArrayList valueProjectors, IGeneralDataProjector projector, IDataReader datasource,
			int maxNumberOfItemsToReturn, int pageNumber, int pageSize, bool clientSideLimitation, bool clientSideDistinctFiltering, bool clientSidePaging )
		{
			object[] values = new object[datasource.FieldCount];
			object[] projectionResult = null;
			Hashtable distinctHashes = new Hashtable( 1024 );		// we can't pre-allocate now, as we don't know the rowcount.

			bool rowLimitSet = (clientSidePaging || clientSideLimitation);
			int rowsToSkip = 0;
			int rowCounter = 0;
			int rowsToRead = 0;
			if( rowLimitSet )
			{
				if( clientSidePaging )
				{
					rowsToRead = pageSize;
					rowsToSkip = pageSize * (pageNumber - 1);
				}
				else
				{
					rowsToRead = maxNumberOfItemsToReturn;
				}
			}

			while( datasource.Read() )
			{
				rowCounter++;

				if( rowLimitSet )
				{
					// check if we've read enough rows.
					if( rowCounter <= rowsToSkip )
					{
						continue;
					}
					if( rowCounter > (rowsToRead + rowsToSkip) )
					{
						// done
						break;
					}
				}

				datasource.GetValues( values );
				projectionResult = new object[valueProjectors.Count];

				for( int i = 0; i < valueProjectors.Count; i++ )
				{
					projectionResult[i] = ((IDataValueProjector)valueProjectors[i]).ProjectValue( values );
				}

				bool acceptResults = true;
				if( clientSideDistinctFiltering )
				{
					// perform distinct filtering using hashes. If it fails, simply continue. calculate hash of current row.
					int hashValue = ProjectionUtils.CreateHashValueFromValues( valueProjectors, projectionResult );

					ArrayList projectionResults = (ArrayList)distinctHashes[hashValue];
					// check the hash in the table. If hash exists, check value-by-value with all the stored rows with that same hashvalue
					if( projectionResults==null )
					{
						// possible duplicate, check per value
						foreach( object[] previousResult in projectionResults )
						{
							bool areEqual = true;
							for( int j = 0; j < projectionResult.Length; j++ )
							{
								areEqual &= FieldUtilities.ValuesAreEqual( previousResult[j], projectionResult[j] );
								if( !areEqual )
								{
									// already not equal, check next.
									break;
								}
							}
							if( areEqual )
							{
								// row is dupe of previous result, don't accept row
								acceptResults = false;
								break;
							}
						}
						if( acceptResults )
						{
							// row isn't a dupe of a previous row, add it to the list of rows for this hash.
							projectionResults.Add( projectionResult );
						}
					}
					else
					{
						projectionResults = new ArrayList();
						distinctHashes.Add( hashValue, projectionResults );
					}
					// if row is accepted, add it to the projectionresults.
					if( acceptResults )
					{
						projectionResults.Add( projectionResult );
					}
					else
					{
						// continue with next row in resultset.
						continue;
					}
				}

				// valid raw projection result, add it to the projector
				projector.AddProjectionResultToContainer( valueProjectors, projectionResult );
			}
		}
	}


	/// <summary>
	/// Various field related routines
	/// </summary>
	public class FieldUtilities
	{
		/// <summary>
		/// Determines if the field should be set to the value passed in.
		/// </summary>
		/// <param name="fieldToSet">Field to set.</param>
		/// <param name="entityIsNew"><see langword="true"/> if [entity is new]; otherwise, <see langword="false"/>.</param>
		/// <param name="value">Value.</param>
		/// <returns>true if the field should be set with the value, false otherwise</returns>
		internal static bool DetermineIfFieldShouldBeSet(IEntityFieldCore fieldToSet, bool entityIsNew, object value)
		{
			// field value has to be updated in the following situations:
			// - when the entity is new and:
			//		- the field hasn't been changed
			//		- the field has been changed but the value is different, only if the current value is not null
			// - when the entity is not new and:
			//		- the field is already changed and value is different
			//		- the field's DbValue is null and value is not null
			//		- the field's DbValue is not null and the field's CurrentValue is different than the new value and not null
			//		- the field's CurrentValue is null and value isn't null
			return(
				(
					entityIsNew && 
					( 
						!fieldToSet.IsChanged 
						||
						(
							fieldToSet.IsChanged 
							&& 
							(
								(
									(fieldToSet.CurrentValue!=null) 
									&& 
									!ValuesAreEqual(fieldToSet.CurrentValue, value)
								)
								||
								(fieldToSet.CurrentValue==null) 
							)
						)
					)
				)
				||
				(
					!entityIsNew 
					&& 
					(
						(
							fieldToSet.IsChanged
							&&
							!ValuesAreEqual(fieldToSet.CurrentValue, value)
						) 
						||
						(
							(fieldToSet.DbValue==null) 
							&& 
							(value != null)
						) 
						||
						(
							(fieldToSet.CurrentValue == null)
							&&
							(value != null)
						)
						||
						(
							(fieldToSet.DbValue!=null) 
							&& 
							(fieldToSet.CurrentValue!=null) 
							&& 
							!ValuesAreEqual(fieldToSet.CurrentValue, value)
						)
					)
				)
			);
		}


		/// <summary>
		/// Compares the two values passed in and checks if they're value-wise the same. This extends 'Equals' in the sense that if the values are
		/// arrays it considers them the same if the values of the arrays are the same as well and the length is the same. 
		/// </summary>
		/// <remarks>It assumes the types of value1 and value2 are the same</remarks>
		/// <param name="value1"></param>
		/// <param name="value2"></param>
		/// <returns>true if the values should be considered equal. If value1 or value2 are null and the other isn't false is returned. If both are null,
		/// true is returned.</returns>
		public static bool ValuesAreEqual(object value1, object value2)
		{
			if( ((value1==null) && (value2!=null))||((value1!=null) && (value2==null)))
			{
				return false;
			}
			if((value1==null) && (value2==null))
			{
				return true;
			}

			// not null, proceed with checks on values.
			Type value1Type = value1.GetType();
			Type value2Type = value2.GetType();

			if(value1Type!=value2Type)
			{
				return false;
			}

			if(value1Type.IsArray)
			{
				return CheckArraysAreEqual((Array)value1, (Array)value2);
			}
			else
			{
				return value1.Equals(value2);
			}
		}


		/// <summary>
		/// Performs a per-value compare on the arrays passed in and returns true if the arrays are of the same length and contain the same values.
		/// </summary>
		/// <param name="arr1"></param>
		/// <param name="arr2"></param>
		/// <returns>true if the arrays contain the same values and are of the same length</returns>
		public static bool CheckArraysAreEqual(Array arr1, Array arr2)
		{
			if( ((arr1==null)&&(arr2!=null))||((arr1!=null) && (arr2==null)))
			{
				return false;
			}

			if((arr1==null)&&(arr2==null))
			{
				return true;
			}

			// non-null arrays.
			if(arr1.Length!=arr2.Length)
			{
				return false;
			}

			bool areEqual = true;
			for (int i = 0; i < arr1.Length; i++)
			{
				areEqual &= arr1.GetValue(i).Equals(arr2.GetValue(i));
				if(!areEqual)
				{
					break;
				}
			}

			return areEqual;
		}


		/// <summary>
		/// Creates a full type name, of the format: Type.Fullname, assembly name. 
		/// If the assembly is signed, the full assembly name is added, otherwise just the assembly name, not the version, public key token or culture.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns>fulltype name. </returns>
		internal static string CreateFullTypeName( Type type )
		{
			byte[] publicToken = type.Assembly.GetName().GetPublicKeyToken();
			if( (publicToken==null) || (publicToken.Length <= 0 ))
			{
				return string.Format( "{0}, {1}", type.FullName, type.Assembly.GetName().Name );
			}
			else
			{
				// Signed assembly, get the full name, including version and public key token.
#if CF
				return string.Format("{0}, {1}", type.FullName, type.Assembly.GetName().Name);
#else
				return type.AssemblyQualifiedName;
#endif
			}
		}


		/// <summary>
		/// Checks the precision of the value passed in as string. Assumes value is numeric.
		/// </summary>
		/// <param name="valueAsString">The value as string.</param>
		/// <param name="precision">The precision.</param>
		/// <param name="exceptionMessage">The exception message.</param>
		/// <returns></returns>
		public static bool CheckPrecision(string valueAsString, int precision, ref string exceptionMessage)
		{
			bool toReturn = true;
			exceptionMessage = string.Empty;
			if(valueAsString.StartsWith(CultureInfo.CurrentCulture.NumberFormat.NegativeSign.ToString()))
			{
				toReturn = ((valueAsString.Length - 1) <= precision);
			}
			else
			{
				toReturn = (valueAsString.Length <= precision);
			}
			if(!toReturn)
			{
				exceptionMessage = string.Format("The value '{0}' is larger than the precision of the field: '{1}' and will cause an overflow in the database.", valueAsString, precision);
			}
			return toReturn;
		}


		/// <summary>
		/// Checks the precision and scale of the value passed in as string. Assumes value is numeric.
		/// </summary>
		/// <param name="valueAsString">The value as string.</param>
		/// <param name="value">The value. Will be altered if a scale overflow is detected and the scaleOverflowCorrectionActionToUse
		/// value dictates that the value has to be altered to make it fit the scale.</param>
		/// <param name="scaleOverflowCorrectionActionToUse">The scale overflow correction action to use.</param>
		/// <param name="precision">The precision.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="precisionViolation">if set to <c>true</c> [precision violation].</param>
		/// <param name="scaleViolation">if set to <c>true</c> [scale violation].</param>
		/// <param name="exceptionMessage">The exception message.</param>
		public static void CheckPrecisionAndScale(string valueAsString, ref object value, ScaleOverflowCorrectionAction scaleOverflowCorrectionActionToUse,
			int precision, int scale, out bool precisionViolation, out bool scaleViolation, ref string exceptionMessage)
		{
			string valueAsStringToUse = valueAsString;
			string[] fragments = valueAsString.Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0]);
			precisionViolation = false;
			scaleViolation = false;
			exceptionMessage = string.Empty;
			int totalLength = fragments[0].Length;
			if(fragments.Length > 1)
			{
				scaleViolation = (fragments[1].Length > scale);
				totalLength += fragments[1].Length;
			}
			precisionViolation = (totalLength > precision);

			bool scaleCorrected = false;
			if(scaleViolation)
			{
				switch(scaleOverflowCorrectionActionToUse)
				{
					case ScaleOverflowCorrectionAction.None:
						exceptionMessage = string.Format("The scale of value '{0}' is larger than the scale of the field: '{1}' and will cause an overflow in the database. ", valueAsStringToUse, scale);
						break;
					case ScaleOverflowCorrectionAction.Truncate:
					case ScaleOverflowCorrectionAction.Round:
						scaleViolation = false;
						value = CorrectScale(value, scale, scaleOverflowCorrectionActionToUse);
						scaleCorrected = true;
						break;
				}
			}
			if(precisionViolation && scaleCorrected)
			{
				// recheck the precision, as the scale has been corrected.
				valueAsStringToUse = value.ToString();
				fragments = valueAsStringToUse.Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0]);
				totalLength = fragments[0].Length;
				if(fragments.Length > 1)
				{
					totalLength += fragments[1].Length;
				}
				precisionViolation = (totalLength > precision);
			}

			if(precisionViolation)
			{
				exceptionMessage += string.Format("The precision of value '{0}' is larger than the precision of the field: '{1}' and will cause an overflow in the database.", valueAsStringToUse, precision);
			}
		}


		/// <summary>
		/// Determines the number of pk fields for the set of PK fields passed in. Normally this is the # of entries in the PK field collection, however in the case of
		/// a subtype of a targetperentity, all PK fields of the supertypes are also present in this collection and therefore this routine has to determine how
		/// many of these fields are really there.
		/// </summary>
		/// <param name="pkFields">The pk fields.</param>
		/// <returns>the # of pk fields</returns>
		public static int DetermineNumberOfPkFields(ArrayList pkFields)
		{
			if(pkFields.Count <= 1)
			{
				return pkFields.Count;
			}

			string previousName = ((IEntityFieldCore)pkFields[0]).ContainingObjectName;
			int amount = 0;
			for(int i = 0; i < pkFields.Count; i++)
			{
				if(previousName == ((IEntityFieldCore)pkFields[i]).ContainingObjectName)
				{
					amount++;
					continue;
				}
				else
				{
					// done;
					break;
				}
			}

			return amount;
		}


		/// <summary>
		/// Creates the artificial object alias for a field which is in the entity with the name specified.
		/// THe alias is used to make it possible to join a supertype multiple times if fields from different subtypes are in the resultset.
		/// The alias has the format LPAA_actualContainingObjectName. Example: LPAA_CustomerEntity
		/// </summary>
		/// <param name="actualContainingObjectName">Name of the actual containing object.</param>
		/// <returns> the artificial object alias to use for the field calling this method</returns>
		internal static string CreateArtificialObjectAlias(string actualContainingObjectName)
		{
			return string.Format("LPAA_{0}", actualContainingObjectName);
		}


		/// <summary>
		/// Corrects the scale of the value passed in (can be decimal, single or double) and returns the new value with the scale corrected according to
		/// the scale passed in and the action specified.
		/// </summary>
		/// <param name="valueToCorrect">The value to correct.</param>
		/// <param name="scale">The scale.</param>
		/// <param name="action">The action.</param>
		/// <returns>returns the new value with the scale corrected according to the scale passed in and the action specified.</returns>
		private static object CorrectScale(object valueToCorrect, int scale, ScaleOverflowCorrectionAction action)
		{
			if(action == ScaleOverflowCorrectionAction.None)
			{
				return valueToCorrect;
			}

			if(!((valueToCorrect is Decimal) || (valueToCorrect is Single) || (valueToCorrect is double)))
			{
				throw new ArgumentException("valueToCorrect isn't of type decimal, single or double");
			}

			string[] fragments = valueToCorrect.ToString().Split(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0]);
			if(fragments.Length <= 1)
			{
				return valueToCorrect;
			}

			if(fragments[1].Length <= scale)
			{
				return valueToCorrect;
			}

			object toReturn = null;
			if(scale == 0)
			{
				// always truncate
				fragments[1] = string.Empty;
			}
			else
			{
				switch(action)
				{
					case ScaleOverflowCorrectionAction.Truncate:
						fragments[1] = fragments[1].Substring(0, scale);
						break;
					case ScaleOverflowCorrectionAction.Round:
					switch(Type.GetTypeCode(valueToCorrect.GetType()))
					{
						case TypeCode.Decimal:
							toReturn = Math.Round((decimal)valueToCorrect, scale);
							break;
						case TypeCode.Double:
							toReturn = Math.Round((double)valueToCorrect, scale);
							break;
						case TypeCode.Single:
							toReturn = (Single)Math.Round((double)valueToCorrect, scale);
							break;
					}
						break;
				}
			}

			if(toReturn == null)
			{
				// put back together the value to return from the fragments
				string valueToReturnAsString = string.Empty;
				if(fragments.Length > 1)
				{
					valueToReturnAsString = fragments[0] + CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator.ToString()[0] + fragments[1];
				}
				else
				{
					valueToReturnAsString = fragments[1];
				}

				switch(Type.GetTypeCode(valueToCorrect.GetType()))
				{
					case TypeCode.Decimal:
						toReturn = Convert.ToDecimal(valueToReturnAsString);
						break;
					case TypeCode.Double:
						toReturn = Convert.ToDouble(valueToReturnAsString);
						break;
					case TypeCode.Single:
						toReturn = Convert.ToSingle(valueToReturnAsString);
						break;
				}
			}
			return toReturn;
		}

		

		/// <summary>
		/// Removes the excluded fields persistence infos, which are actually null in the passed in array and returns a new array without these values
		/// this means that the array is shrinked. So if index 3 was excluded (== null), it means that in the array returned, the persistenceinfo 
		/// object originally at index 4 is now at index 3 etc. 
		/// </summary>
		/// <param name="persistenceInfosForRowReader">The persistence infos for row reader.</param>
		/// <returns>new array, smaller or equal in size which contains only real persistence info objects, all null values have been stripped out</returns>
		internal static IFieldPersistenceInfo[] RemoveExcludedFieldsPersistenceInfos(IFieldPersistenceInfo[] persistenceInfosForRowReader)
		{
			ArrayList container = new ArrayList();
			for(int i = 0; i < persistenceInfosForRowReader.Length; i++)
			{
				if(persistenceInfosForRowReader[i] != null)
				{
					container.Add(persistenceInfosForRowReader[i]);
				}
			}

			return (IFieldPersistenceInfo[])container.ToArray(typeof(IFieldPersistenceInfo));
		}
		

		/// <summary>
		/// Marks the saved fields object as fetched. This means: set the state and copy over CurrentValue into DbValue for all fields.
		/// </summary>
		/// <param name="fields">The fields.</param>
		internal static void MarkSavedFieldsObjectAsFetched(IEntityFields fields)
		{
			fields.State = EntityState.Fetched;
			CopyCurrentValuesIntoDbValues(fields);
		}


		/// <summary>
		/// Marks the saved fields object as fetched. This means: set the state and copy over CurrentValue into DbValue for all fields.
		/// </summary>
		/// <param name="fields">The fields.</param>
		internal static void MarkSavedFieldsObjectAsFetched(IEntityFields2 fields)
		{
			fields.State = EntityState.Fetched;
			CopyCurrentValuesIntoDbValues(fields);
		}


		/// <summary>
		/// Copies the CurrentValue values of all fields into their DbValue properties
		/// </summary>
		/// <param name="fields">The fields.</param>
		private static void CopyCurrentValuesIntoDbValues(IEnumerable fields)
		{
			foreach(IEntityFieldCore field in fields)
			{
				field.ForcedCurrentValueWrite(field.CurrentValue, field.CurrentValue);
			}
		}
	}
	

	/// <summary>
	/// Specialized Hashtable which allows merging with a passed-in hashtable. 
	/// </summary>
	public class MergeableHashtable : Hashtable
	{
		/// <summary>
		/// Creates a new <see cref="MergeableHashtable"/> instance.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		public MergeableHashtable(int capacity):base(capacity)
		{
		}

		/// <summary>
		/// Creates a new <see cref="MergeableHashtable"/> instance.
		/// </summary>
		public MergeableHashtable():base()
		{
		}

		/// <summary>
		/// Creates a new <see cref="MergeableHashtable"/> instance.
		/// </summary>
		/// <param name="d">D.</param>
		public MergeableHashtable(IDictionary d):base(d)
		{
		}


		/// <summary>
		/// Merges the hashtable passed in with this MergeableHashtable. All keys in toMerge which are already in this MergeableHashtable are skipped.
		/// </summary>
		/// <param name="toMerge">To merge.</param>
		public void MergeHashtable(Hashtable toMerge)
		{
			foreach(DictionaryEntry entry in toMerge)
			{
				if(this.ContainsKey(entry.Key))
				{
					continue;
				}
				this.Add(entry.Key, entry.Value);
			}
		}

		/// <summary>
		/// Adds the specified value with the specified key. If key is already present, it will overwrite the value already stored with key.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		public override void Add(object key, object value)
		{
			if(this.ContainsKey(key))
			{
				this[key]=value;
			}
			else
			{
				base.Add (key, value);
			}
		}
	}



	/// <summary>
	/// Some utility functions to process graphs
	/// </summary>
	public class ObjectGraphUtils
	{
		#region Adapter Specific
		/// <summary>
		/// Produces the collections per type from the graph specified
		/// </summary>
		/// <param name="collection">The collection of entities which form the start of the graph.</param>
		/// <returns>A dictionary with per type a new non-generic entity collection with all the entities of that type found in the graph</returns>
		public Hashtable ProduceCollectionsPerTypeFromGraph(IEntityCollection2 collection)
		{
			Hashtable toReturn = new Hashtable();
			Hashtable adjacencyLists = new Hashtable();
			Hashtable recursed = new Hashtable();

			foreach(IEntity2 entity in collection)
			{
				if(!recursed.ContainsKey(entity.ObjectID))
				{
					ProduceAdjacencyLists(entity, adjacencyLists, recursed);
				}
			}

			// recursed contains all entities in the graph. Walk it and per type, create a new entity collection, nongeneric. 
			foreach(DictionaryEntry pair in recursed)
			{
				IEntityCollection2 newCollection = (IEntityCollection2)toReturn[pair.Value.GetType()];
				if(newCollection==null)
				{
					newCollection = new EntityCollectionForFetch(((IEntity2)pair.Value).GetEntityFactory());
					toReturn.Add(pair.Value.GetType(), newCollection);
				}
				newCollection.Add((IEntity2)pair.Value);
			}

			return toReturn;
		}


		/// <summary>
		/// Produces the topology ordered list for the graph rooted by the entity passed in. Uses topological sort of a directed graph.
		/// </summary>
		/// <param name="entityToExamine">Entity to examine.</param>
		/// <returns>
		/// Arraylist which represents the complete graph of entities which are reachable from entityToExamine, and sorted in the right order,
		/// so every entity which depends on another entity is placed after the entity/entities it depends on.
		/// </returns>
		public ArrayList ProduceTopologyOrderedList(IEntity2 entityToExamine)
		{
			Hashtable adjacencyLists = new Hashtable();
			Hashtable recursed = new Hashtable();
			ProduceAdjacencyLists(entityToExamine, adjacencyLists, recursed);
			Hashtable visited = new Hashtable();
			ArrayList orderedList = new	 ArrayList();
			foreach(IEntity2 toSort in recursed.Values)
			{
				if(!visited.ContainsKey(toSort.ObjectID))
				{
					PerformTopologySort(toSort, adjacencyLists, visited, orderedList);
				}
			}

			// orderedList now contains the complete graph sorted in the right order. 
			return orderedList;
		}

		/// <summary>
		/// Performs the topology sort for the adjacencylists and the entity given. Adds the entity to the ArrayList passed in which represents the right ordered queue.
		/// </summary>
		/// <param name="toSort">To sort.</param>
		/// <param name="adjacencyLists">Adjacency lists.</param>
		/// <param name="visited">Visited.</param>
		/// <param name="orderedList">Ordered list.</param>
		public void PerformTopologySort(IEntity2 toSort, Hashtable adjacencyLists, Hashtable visited, ArrayList orderedList)
		{
			visited.Add(toSort.ObjectID, null);
			Hashtable adjacencyList = (Hashtable)adjacencyLists[toSort.ObjectID];
			foreach(IEntity2 entity in adjacencyList.Values)
			{
				if(visited.ContainsKey(entity.ObjectID))
				{
					continue;
				}
				PerformTopologySort(entity, adjacencyLists, visited, orderedList);
			}
			orderedList.Add(toSort);
		}


		/// <summary>
		/// Produces adjancency lists for the entities in the complete graph reachable from the entity passed in. This routine figures out
		/// the graph to process by walking it, using a hashtable (recursed) to take note which nodes are already processed. 
		/// When it finds an entity A and an entity B having a relation in the graph (have 'an edge'), and A is depending on B, we add B to the 
		/// adjacency list of A, though we don't add A to the adjacency list of B.
		/// </summary>
		/// <param name="entityToExamine">Entity to examine</param>
		/// <param name="adjacencyLists">The hashtable with per seen entity (objectid, key) the adjancency list (Hashtable of entities, key is objectid, value is entity)</param>
		/// <param name="recursed">The hashtable with objectids of the entities already processed to build the adjacency lists.</param>
		public void ProduceAdjacencyLists(IEntity2 entityToExamine, Hashtable adjacencyLists, Hashtable recursed)
		{
			IEntityCollection2 containedDependingEntities = entityToExamine.GetDependingRelatedEntities();
			IEntityCollection2 containedDependentEntities = entityToExamine.GetDependentRelatedEntities();
			ArrayList containedMemberCollections = entityToExamine.GetMemberEntityCollections();

			recursed.Add(entityToExamine.ObjectID, entityToExamine);

			Hashtable adjacencyListOfExaminedEntity = GetOrCreateAdjacencyList(entityToExamine.ObjectID, adjacencyLists	);
			ArrayList toRecurse = new ArrayList();
			foreach(IEntity2 dependentEntity in containedDependentEntities)
			{
				toRecurse.Add(dependentEntity);
				// entityToExamine is depending on dependentEntity, so an edge is defined from entityToExamine to dependententity. Add dependententity
				// to adjacencylist of entityToExamine, IF not yet present.
				AddToAdjacencyList(dependentEntity, entityToExamine, adjacencyLists);
			}
			foreach(IEntity2 dependingEntity in containedDependingEntities)
			{
				toRecurse.Add(dependingEntity);
				// dependingentity is depending on entityToExamine so an edge is defined from dependingentity to entityToExamine. Add entityToExamine
				// to adjacencylist of dependingentity, IF not yet present.
				AddToAdjacencyList(entityToExamine, dependingEntity, adjacencyLists);
			}
			foreach(IEntityCollection2 dependingCollection in containedMemberCollections)
			{
				foreach(IEntity2 dependingEntity in dependingCollection)
				{
					toRecurse.Add(dependingEntity);
					// dependingentity is depending on entityToExamine so an edge is defined from dependingentity to entityToExamine. Add entityToExamine
					// to adjacencylist of dependingentity, IF not yet present.
					AddToAdjacencyList(entityToExamine, dependingEntity, adjacencyLists);
				}
			}

			foreach(IEntity2 entity in toRecurse)
			{
				if(recursed.ContainsKey(entity.ObjectID))
				{
					continue;
				}
				ProduceAdjacencyLists(entity, adjacencyLists, recursed);
			}
		}


		/// <summary>
		/// Adds one entity to the adjacency list of another entity
		/// </summary>
		/// <param name="toAdd">Entity to add to the adjacency list of adjacencyListOwner.</param>
		/// <param name="adjacencyListOwner">Adjacency list owner of the adjacencylist to add to</param>
		/// <param name="adjacencyLists">Adjacency lists currently known</param>
		/// <remarks>if toAdd is already present, this routine is a no-op</remarks>
		private void AddToAdjacencyList(IEntity2 toAdd, IEntity2 adjacencyListOwner, Hashtable adjacencyLists)
		{
			Hashtable adjacencyList = GetOrCreateAdjacencyList(adjacencyListOwner.ObjectID, adjacencyLists);
			if(!adjacencyList.ContainsKey(toAdd.ObjectID))
			{
				adjacencyList.Add(toAdd.ObjectID, toAdd);
			}
		}


		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		/// <param name="refetchAfterAction">flag to set in the new actionobjects if the entity to save has to be refetched after the action</param>
		public void DetermineActionQueues(IEntity2 entityToSave, ref ArrayList insertQueue, ref ArrayList updateQueue, bool refetchAfterAction)
		{
			DetermineActionQueues(entityToSave, null, ref insertQueue, ref updateQueue, refetchAfterAction);
		}

		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="updateRestriction">Update restriction to use for entityToSave</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		/// <param name="refetchAfterAction">flag to set in the new actionobjects if the entity to save has to be refetched after the action</param>
		public void DetermineActionQueues(IEntity2 entityToSave, IPredicateExpression updateRestriction, ref ArrayList insertQueue, ref ArrayList updateQueue, bool refetchAfterAction)
		{
			Hashtable inQueue = new Hashtable(512);
			Hashtable entitiesInGraph = null;
			DetermineActionQueues(entityToSave, updateRestriction, ref insertQueue, ref updateQueue, ref inQueue, refetchAfterAction, out entitiesInGraph);
		}


		/// <summary>
		/// Determines the action queues for the entity collection passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityCollectionToSave">Entity collection to save.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		/// <param name="refetchAfterAction">flag to set in the new actionobjects if the entity to save has to be refetched after the action</param>
		public void DetermineActionQueues(IEntityCollection2 entityCollectionToSave, ref ArrayList insertQueue, ref ArrayList updateQueue, bool refetchAfterAction)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DetermineActionQueues(4)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityCollectionBase2)entityCollectionToSave).GetEntityCollectionDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Collection Description");

			Hashtable inQueue = new Hashtable(512);
			MergeableHashtable alreadyProcessed = new MergeableHashtable(512);

			foreach(IEntity2 entityToSave in entityCollectionToSave)
			{
				if(alreadyProcessed.ContainsKey(entityToSave.ObjectID))
				{
					// already processed. It's in a graph which is already been processed. continue;
					continue;
				}
				Hashtable entitiesInGraph = new Hashtable();
				DetermineActionQueues(entityToSave, null, ref insertQueue, ref updateQueue, ref inQueue, refetchAfterAction, out entitiesInGraph);
				// merge entitiesInGraph with alreadyProcessed. 
				alreadyProcessed.MergeHashtable(entitiesInGraph);
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DetermineActionQueues(4)", "Method Exit");
		}


		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="updateRestriction">Update restriction to use with entityToSave</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		/// <param name="inQueue">In queue.</param>
		/// <param name="refetchAfterAction"><see langword="true"/> if [refetch after action]; otherwise, <see langword="false"/>.</param>
		/// <param name="entitiesInGraph">Entities in graph.</param>
		internal void DetermineActionQueues(IEntity2 entityToSave, IPredicateExpression updateRestriction, ref ArrayList insertQueue, ref ArrayList updateQueue, 
			ref Hashtable inQueue, bool refetchAfterAction, out Hashtable entitiesInGraph)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DetermineActionQueues(7)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)entityToSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave), "Active Entity Description");

			entitiesInGraph = new Hashtable(512);

			if(inQueue.ContainsKey(entityToSave.ObjectID))
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DetermineActionQueues(7)", "Method Exit");
				return;
			}

			ArrayList sortedGraphList = this.ProduceTopologyOrderedList(entityToSave);

			// now traverse the list from front to back and add any dirty entities to their right queue
			foreach(IEntity2 toSave in sortedGraphList)
			{
				if(!entitiesInGraph.ContainsKey(toSave.ObjectID))
				{
					entitiesInGraph.Add(toSave.ObjectID, null);
				}
				// if an entity is dirty, or if an entity has pending FK syncs (which can make it dirty during the save action), or
				// if the entity isn't dirty but new and is in a hierarchy of type TargetPerEntityHierarchy (as it then has a 'hidden' dirty field, the
				// discriminator column) the entity should be added to the save queues.
				if(	(toSave.IsDirty || 
					((EntityBase2)toSave).CheckIfEntityHasPendingFkSyncs(inQueue) ||
					(!toSave.IsDirty && toSave.IsNew && (((EntityBase2)toSave).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy))) 
					&& !inQueue.ContainsKey(toSave.ObjectID))
				{
					if(toSave.IsNew)
					{
						insertQueue.Add(new ActionQueueElement(toSave, null, refetchAfterAction));
						TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)toSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toSave), "Entity added to insert queue");
					}
					else
					{
						if((toSave==entityToSave)&&(updateRestriction!=null))
						{
							updateQueue.Add(new ActionQueueElement(toSave, updateRestriction, refetchAfterAction));
						}
						else
						{
							updateQueue.Add(new ActionQueueElement(toSave, toSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), refetchAfterAction));
						}
						TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase2)toSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toSave), "Entity added to update queue");
					}

					inQueue.Add(toSave.ObjectID, null);
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "DataAccessAdapterBase.DetermineActionQueues(7)", "Method Exit");
		}
		#endregion

		#region SelfServicing Specific
		/// <summary>
		/// Produces the collections per type from the graph specified
		/// </summary>
		/// <param name="collection">The collection of entities which form the start of the graph.</param>
		/// <returns>A dictionary with per type a new non-generic entity collection with all the entities of that type found in the graph</returns>
		public Hashtable ProduceCollectionsPerTypeFromGraph(IEntityCollection collection)
		{
			Hashtable toReturn = new Hashtable();

			Hashtable adjacencyLists = new Hashtable();
			Hashtable recursed = new Hashtable();

			foreach(IEntity entity in collection)
			{
				if(!recursed.ContainsKey(entity.ObjectID))
				{
					ProduceAdjacencyLists(entity, adjacencyLists, recursed);
				}
			}

			// recursed contains all entities in the graph. Walk it and per type, create a new entity collection, nongeneric. 
			foreach(DictionaryEntry pair in recursed)
			{
				IEntityCollection newCollection = (IEntityCollection)toReturn[pair.Value.GetType()];
				if(newCollection==null)
				{
					newCollection = ((IEntity)pair.Value).GetEntityFactory().CreateEntityCollection();
					toReturn.Add(pair.Value.GetType(), newCollection);
				}
				newCollection.Add((IEntity)pair.Value);
			}

			return toReturn;
		}
		/// <summary>
		/// Produces the topology ordered list for the graph rooted by the entity passed in. Uses topological sort of a directed graph.
		/// </summary>
		/// <param name="entityToExamine">Entity to examine.</param>
		/// <returns>
		/// Arraylist which represents the complete graph of entities which are reachable from entityToExamine, and sorted in the right order,
		/// so every entity which depends on another entity is placed after the entity/entities it depends on.
		/// </returns>
		public ArrayList ProduceTopologyOrderedList(IEntity entityToExamine)
		{
			Hashtable adjacencyLists = new Hashtable();
			Hashtable recursed = new Hashtable();
			ProduceAdjacencyLists(entityToExamine, adjacencyLists, recursed);
			Hashtable visited = new Hashtable();
			ArrayList orderedList = new	 ArrayList();
			foreach(IEntity toSort in recursed.Values)
			{
				if(!visited.ContainsKey(toSort.ObjectID))
				{
					PerformTopologySort(toSort, adjacencyLists, visited, orderedList);
				}
			}

			// orderedList now contains the complete graph sorted in the right order. 
			return orderedList;
		}


		/// <summary>
		/// Performs the topology sort for the adjacencylists and the entity given. Adds the entity to the ArrayList passed in which represents the right ordered queue.
		/// </summary>
		/// <param name="toSort">To sort.</param>
		/// <param name="adjacencyLists">Adjacency lists.</param>
		/// <param name="visited">Visited.</param>
		/// <param name="orderedList">Ordered list.</param>
		public void PerformTopologySort(IEntity toSort, Hashtable adjacencyLists, Hashtable visited, ArrayList orderedList)
		{
			visited.Add(toSort.ObjectID, null);
			Hashtable adjacencyList = (Hashtable)adjacencyLists[toSort.ObjectID];
			foreach(IEntity entity in adjacencyList.Values)
			{
				if(visited.ContainsKey(entity.ObjectID))
				{
					continue;
				}
				PerformTopologySort(entity, adjacencyLists, visited, orderedList);
			}
			orderedList.Add(toSort);
		}


		/// <summary>
		/// Produces adjancency lists for the entities in the complete graph reachable from the entity passed in. This routine figures out
		/// the graph to process by walking it, using a hashtable (recursed) to take note which nodes are already processed. 
		/// When it finds an entity A and an entity B having a relation in the graph (have 'an edge'), and A is depending on B, we add B to the 
		/// adjacency list of A, though we don't add A to the adjacency list of B.
		/// </summary>
		/// <param name="entityToExamine">Entity to examine</param>
		/// <param name="adjacencyLists">The hashtable with per seen entity (objectid, key) the adjancency list (Hashtable of entities, key is objectid, value is entity)</param>
		/// <param name="recursed">The hashtable with objectids of the entities already processed to build the adjacency lists.</param>
		public void ProduceAdjacencyLists(IEntity entityToExamine, Hashtable adjacencyLists, Hashtable recursed)
		{
			ArrayList containedDependingEntities = entityToExamine.GetDependingRelatedEntities();
			ArrayList containedDependentEntities = entityToExamine.GetDependentRelatedEntities();
			ArrayList containedMemberCollections = entityToExamine.GetMemberEntityCollections();

			recursed.Add(entityToExamine.ObjectID, entityToExamine);

			Hashtable adjacencyListOfExaminedEntity = GetOrCreateAdjacencyList(entityToExamine.ObjectID, adjacencyLists	);
			ArrayList toRecurse = new ArrayList();
			foreach(IEntity dependentEntity in containedDependentEntities)
			{
				toRecurse.Add(dependentEntity);
				// entityToExamine is depending on dependentEntity, so an edge is defined from entityToExamine to dependententity. Add dependententity
				// to adjacencylist of entityToExamine, IF not yet present.
				AddToAdjacencyList(dependentEntity, entityToExamine, adjacencyLists);
			}
			foreach(IEntity dependingEntity in containedDependingEntities)
			{
				toRecurse.Add(dependingEntity);
				// dependingentity is depending on entityToExamine so an edge is defined from dependingentity to entityToExamine. Add entityToExamine
				// to adjacencylist of dependingentity, IF not yet present.
				AddToAdjacencyList(entityToExamine, dependingEntity, adjacencyLists);
			}
			foreach(IEntityCollection dependingCollection in containedMemberCollections)
			{
				foreach(IEntity dependingEntity in dependingCollection)
				{
					toRecurse.Add(dependingEntity);
					// dependingentity is depending on entityToExamine so an edge is defined from dependingentity to entityToExamine. Add entityToExamine
					// to adjacencylist of dependingentity, IF not yet present.
					AddToAdjacencyList(entityToExamine, dependingEntity, adjacencyLists);
				}
			}

			foreach(IEntity entity in toRecurse)
			{
				if(recursed.ContainsKey(entity.ObjectID))
				{
					continue;
				}
				ProduceAdjacencyLists(entity, adjacencyLists, recursed);
			}
		}


		/// <summary>
		/// Adds one entity to the adjacency list of another entity
		/// </summary>
		/// <param name="toAdd">Entity to add to the adjacency list of adjacencyListOwner.</param>
		/// <param name="adjacencyListOwner">Adjacency list owner of the adjacencylist to add to</param>
		/// <param name="adjacencyLists">Adjacency lists currently known</param>
		/// <remarks>if toAdd is already present, this routine is a no-op</remarks>
		private void AddToAdjacencyList(IEntity toAdd, IEntity adjacencyListOwner, Hashtable adjacencyLists)
		{
			Hashtable adjacencyList = GetOrCreateAdjacencyList(adjacencyListOwner.ObjectID, adjacencyLists);
			if(!adjacencyList.ContainsKey(toAdd.ObjectID))
			{
				adjacencyList.Add(toAdd.ObjectID, toAdd);
			}
		}


		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		public void DetermineActionQueues(IEntity entityToSave, ref ArrayList insertQueue, ref ArrayList updateQueue)
		{
			DetermineActionQueues(entityToSave, null, ref insertQueue, ref updateQueue);
		}


		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="updateRestriction">Update restriction to use with entityToSave.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		public void DetermineActionQueues(IEntity entityToSave, IPredicate updateRestriction, ref ArrayList insertQueue, ref ArrayList updateQueue)
		{
			Hashtable inQueue = new Hashtable(512);
			Hashtable entitiesInGraph = null;
			DetermineActionQueues(entityToSave, updateRestriction, ref insertQueue, ref updateQueue, ref inQueue, out entitiesInGraph);
		}


		/// <summary>
		/// Determines the action queues for the entity collection passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityCollectionToSave">Entity collection to save.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		public void DetermineActionQueues(IEntityCollection entityCollectionToSave, ref ArrayList insertQueue, ref ArrayList updateQueue)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "ObjectGraphUtils.DetermineActionQueues(4)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityCollectionBase)entityCollectionToSave).GetEntityCollectionDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose), "Active Entity Collection Description");

			Hashtable inQueue = new Hashtable(512);
			MergeableHashtable alreadyProcessed = new MergeableHashtable(512);
			foreach(IEntity entityToSave in entityCollectionToSave)
			{
				if(alreadyProcessed.ContainsKey(entityToSave.ObjectID))
				{
					// already processed. It's in a graph which is already been processed. continue;
					continue;
				}
				Hashtable entitiesInGraph = new Hashtable();
				DetermineActionQueues(entityToSave, null, ref insertQueue, ref updateQueue, ref inQueue, out entitiesInGraph);
				// merge entitiesInGraph with alreadyProcessed. 
				alreadyProcessed.MergeHashtable(entitiesInGraph);
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "ObjectGraphUtils.DetermineActionQueues(4)", "Method Exit");
		}


		/// <summary>
		/// Determines the action queues for the entity passed in. The action queues contain the entities to process in the right order.
		/// </summary>
		/// <param name="entityToSave">Entity to save.</param>
		/// <param name="updateRestriction">Update restriction.</param>
		/// <param name="insertQueue">Insert queue.</param>
		/// <param name="updateQueue">Update queue.</param>
		/// <param name="inQueue">In queue.</param>
		/// <param name="entitiesInGraph">Entities in graph.</param>
		internal void DetermineActionQueues(IEntity entityToSave, IPredicate updateRestriction, ref ArrayList insertQueue, 
			ref ArrayList updateQueue, ref Hashtable inQueue, out Hashtable entitiesInGraph)
		{
			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "ObjectGraphUtils.DetermineActionQueues(6)", "Method Enter");
			TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase)entityToSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, entityToSave), "Active Entity Description");

			entitiesInGraph = new Hashtable(512);

			if(inQueue.ContainsKey(entityToSave.ObjectID))
			{
				TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "ObjectGraphUtils.DetermineActionQueues(6)", "Method Exit");
				return;
			}
			ArrayList sortedGraphList = this.ProduceTopologyOrderedList(entityToSave);
			// now traverse the list from front to back and add any dirty entities to their right queue. 
			foreach(IEntity toSave in sortedGraphList)
			{
				if(!entitiesInGraph.ContainsKey(toSave.ObjectID))
				{
					entitiesInGraph.Add(toSave.ObjectID, null);
				}
				// if an entity is dirty, or if an entity has pending FK syncs (which can make it dirty during the save action), or
				// if the entity isn't dirty but new and is in a hierarchy of type TargetPerEntityHierarchy (as it then has a 'hidden' dirty field, the
				// discriminator column) the entity should be added to the save queues.
				if(	(toSave.IsDirty || 
					((EntityBase)toSave).CheckIfEntityHasPendingFkSyncs(inQueue) ||
					(!toSave.IsDirty && toSave.IsNew && (((EntityBase)toSave).GetInheritanceHierarchyType()==InheritanceHierarchyType.TargetPerEntityHierarchy))) 
					&& !inQueue.ContainsKey(toSave.ObjectID))
				{
					if(toSave.IsNew)
					{
						insertQueue.Add(new ActionQueueElement(toSave, null, false));
						TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase)toSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toSave), "Entity added to insert queue");
					}
					else
					{
						if((toSave==entityToSave)&&(updateRestriction!=null))
						{
							updateQueue.Add(new ActionQueueElement(toSave, new PredicateExpression(updateRestriction), false));
						}
						else
						{
							updateQueue.Add(new ActionQueueElement(toSave, toSave.GetConcurrencyPredicate(ConcurrencyPredicateType.Save), false));
						}
						TraceHelper.WriteIf(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, ((EntityBase)toSave).GetEntityDescription(TraceHelper.PersistenceExecutionSwitch.TraceVerbose, toSave), "Entity added to update queue");
					}

					inQueue.Add(toSave.ObjectID, null);
				}
			}

			TraceHelper.WriteLineIf(TraceHelper.PersistenceExecutionSwitch.TraceInfo, "ObjectGraphUtils.DetermineActionQueues(6)", "Method Exit");
		}
		#endregion

		
		/// <summary>
		/// Gets the adjacency list for the objectid passed in. If no adjacencylist is available for that id, a new one is created and added to the
		/// adjacencylist hashtable passed in
		/// </summary>
		/// <param name="objectId">Object id.</param>
		/// <param name="adjacencyLists">Adjacency lists.</param>
		/// <returns>AdjacencyList of id passed in</returns>
		private Hashtable GetOrCreateAdjacencyList(Guid objectId, Hashtable adjacencyLists)
		{
			Hashtable toReturn = (Hashtable)adjacencyLists[objectId];
			if(toReturn==null)
			{
				toReturn = new Hashtable();
				adjacencyLists.Add(objectId, toReturn);
			}

			return toReturn;
		}	
	}

	
	/// <summary>
	/// Internal class to store entities in an action queue (insertqueue or update queue)
	/// </summary>
	public class ActionQueueElement
	{
		#region Class Member Declarations
		private IEntityCore				_entity;
		private IPredicateExpression	_additionalUpdateFilter;
		private bool					_refetchAfterAction;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ActionQueueElement"/> class.
		/// </summary>
		/// <param name="entity">Entity.</param>
		/// <param name="additionalUpdateFilter">Additional update filter.</param>
		/// <param name="refetchAfterAction"><see langword="true"/> if [refetch after action]; otherwise, <see langword="false"/>.</param>
		internal ActionQueueElement(IEntityCore entity, IPredicateExpression additionalUpdateFilter, bool refetchAfterAction)
		{
			_entity = entity;
			_additionalUpdateFilter = additionalUpdateFilter;
			_refetchAfterAction = refetchAfterAction;
		}

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets refetchAfterAction
		/// </summary>
		public bool RefetchAfterAction
		{
			get
			{
				return _refetchAfterAction;
			}
			set
			{
				_refetchAfterAction = value;
			}
		}

		/// <summary>
		/// Gets / sets entity
		/// </summary>
		public IEntityCore Entity
		{
			get
			{
				return _entity;
			}
			set
			{
				_entity = value;
			}
		}

		/// <summary>
		/// Gets / sets additionalUpdateFilter
		/// </summary>
		public IPredicateExpression AdditionalUpdateFilter
		{
			get
			{
				return _additionalUpdateFilter;
			}
			set
			{
				_additionalUpdateFilter = value;
			}
		}
		#endregion

	}


	/// <summary>
	/// Utility class which fills the passed in datatable using the passed in open reader and the persistence info. 
	/// It performs conversion along the way. It creates new columns if no columns are defined in the datatable, otherwise
	/// re-uses the columns. 
	/// </summary>
	public class DataTableFiller
	{
		/// <summary>
		/// Fills the specified datatable with the data from the datareader.
		/// </summary>
		/// <param name="dataSource">Data source. Is assumed the reader is at the first record, so Read() has been called.</param>
		/// <param name="toFill">To fill.</param>
		/// <param name="fieldsPersistenceInfo">Fields persistence info.</param>
		/// <param name="queryExecuted">Query executed.</param>
		public static void Fill(IDataReader dataSource, DataTable toFill, IFieldPersistenceInfo[] fieldsPersistenceInfo, IRetrievalQuery queryExecuted)
		{
			// use the minimum of the count of fieldsPersistenceInfo or the fieldcount of the datasource.
			int fieldCountMax = Math.Min(fieldsPersistenceInfo.Length, dataSource.FieldCount);
			bool setTypes = false;

			if(toFill.Columns.Count<=0)
			{
				// setup columns
				for (int i = 0; i < dataSource.FieldCount; i++)
				{
					toFill.Columns.Add(dataSource.GetName(i));
				}
				setTypes = true;
			}

			bool rowLimitSet=(queryExecuted.RequiresClientSidePaging || queryExecuted.RequiresClientSideLimitation);
			int rowsToSkip = 0;
			int rowCounter = 0;
			int rowsToRead = 0;
			if(rowLimitSet)
			{
				if(queryExecuted.RequiresClientSidePaging)
				{
					rowsToRead = queryExecuted.ManualPageSize;
					rowsToSkip = queryExecuted.ManualPageSize * (queryExecuted.ManualPageNumber-1);
				}
				else
				{
					// client side limitation
					rowsToRead = (int)queryExecuted.MaxNumberOfItemsToReturnClientSide;
				}
			}
			Hashtable ordinalToTypeConverter = new Hashtable(fieldsPersistenceInfo.Length);
			object[] values = new object[dataSource.FieldCount];

			for (int i = 0; i < fieldCountMax; i++)
			{
#if !CF
				if(fieldsPersistenceInfo[i].TypeConverterToUse!=null)
				{
					ordinalToTypeConverter.Add(i, fieldsPersistenceInfo[i].TypeConverterToUse);
				}
#endif
			}

			object[] newRowValues = new object[fieldCountMax];
			while(dataSource.Read())
			{
				rowCounter++;

				if(rowLimitSet)
				{
					// check if we've read enough rows.
					if(rowCounter<=rowsToSkip)
					{
						continue;
					}
					if(rowCounter>(rowsToRead+rowsToSkip))
					{
						// done
						break;
					}
				}

				dataSource.GetValues(values);

				if(setTypes)
				{
					DataTable schemaTable = dataSource.GetSchemaTable();
					for (int i = 0; i < fieldCountMax; i++)
					{
						Type typeOfColumn = (Type)schemaTable.Rows[i]["DataType"];
#if !CF
						if(fieldsPersistenceInfo[i].TypeConverterToUse!=null)
						{
							typeOfColumn = fieldsPersistenceInfo[i].TypeConverterToUse.CreateInstance(null, null).GetType();
						}
#endif
						toFill.Columns[i].DataType=typeOfColumn;
					}
					setTypes = false;
				}

#if !CF
				foreach(DictionaryEntry entry in ordinalToTypeConverter)
				{
					values[(int)entry.Key] = ((TypeConverter)entry.Value).ConvertFrom(values[(int)entry.Key]);
				}
#endif
				Array.Copy(values, 0, newRowValues, 0, fieldCountMax);
				toFill.Rows.Add(newRowValues);
			}
		}
	}

	/// <summary>
	/// ArrayList which contains solely unique values. 
	/// </summary>
	[Serializable]
	public class UniqueValueList : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="UniqueValueList"/> instance.
		/// </summary>
		public UniqueValueList():base()
		{
		}

		/// <summary>
		/// Creates a new <see cref="UniqueValueList"/> instance.
		/// </summary>
		/// <param name="c">Collection of objects to add to this collection. It will use the </param>
		public UniqueValueList(ICollection c)
		{
			foreach(object o in c)
			{
				this.Add(o);
			}
		}

		/// <summary>
		/// Adds the range specified
		/// </summary>
		/// <param name="c">Collection with new objects to add</param>
		public override void AddRange(ICollection c)
		{
			UniqueValueList toAdd = c as UniqueValueList;
			if(toAdd==null)
			{
				toAdd = new UniqueValueList(c);
			}

			foreach(object o in toAdd)
			{
				this.Add(o);
			}
		}


		/// <summary>
		/// Inserts the value at the specified index if it's not already present in the list, otherwise it's a no-op
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="value">Value.</param>
		public override void Insert(int index, object value)
		{
			if(!this.Contains(value))
			{
				base.Insert (index, value);
			}
		}


		/// <summary>
		/// Adds the specified value if it's not already in the list.
		/// </summary>
		/// <param name="value">Value.</param>
		/// <returns>index of the value if it's added or the first index it appears on</returns>
		public override int Add(object value)
		{
			int index = this.IndexOf(value);
			if(index<0)
			{
				return base.Add(value);
			}
			else
			{
				return index;
			}
		}

		/// <summary>
		/// Inserts the range.
		/// </summary>
		/// <param name="index">Index.</param>
		/// <param name="c">C.</param>
		public override void InsertRange(int index, ICollection c)
		{
			UniqueValueList toAdd = c as UniqueValueList;
			if(toAdd==null)
			{
				toAdd = new UniqueValueList(c);
			}
			base.InsertRange (index, toAdd);
		}


		/// <summary>
		/// Gets or sets the <see cref="Object"/> at the specified index.
		/// If the value is already in the list, this operation is a no-op
		/// </summary>
		/// <value></value>
		public override object this[int index]
		{
			get
			{
				return base[index];
			}
			set
			{
				if(!this.Contains(value))
				{
					base[index] = value;
				}
			}
		}
	}


	/// <summary>
	/// Specialized hashtable which can store multiple values for a given key. All values are stored in an UniqueValueList as value. When the
	/// value is requested, the UniqueValueList is returned, not the actual value. 
	/// </summary>
	[Serializable]
	public class MultiValueHashtable:Hashtable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultiValueHashtable"/> class.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		public MultiValueHashtable(int capacity):base(capacity)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MultiValueHashtable"/> class.
		/// </summary>
		public MultiValueHashtable():base()
		{
		}
#if !CF
		/// <summary>
		/// Deserialization CTor
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected MultiValueHashtable(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
#endif
		/// <summary>
		/// Creates a new <see cref="MultiValueHashtable"/> instance.
		/// </summary>
		/// <param name="d">D.</param>
		public MultiValueHashtable(IDictionary d):base(d)
		{
		}


		/// <summary>
		/// Adds an element with the specified key and value into the <see cref="T:System.Collections.Hashtable"/>.
		/// </summary>
		/// <param name="key">The key of the element to add.</param>
		/// <param name="value">The value of the element to add. If the key is already existing, the value is added to the existing list of values
		/// for that key, unless the value also already exists.</param>
		public override void Add(object key, object value)
		{
			UniqueValueList valuesStored = null;
			if(base.ContainsKey(key))
			{
				// already there.
				valuesStored = (UniqueValueList)base[key];
			}
			else
			{
				// new
				valuesStored = new UniqueValueList();
				base.Add(key, valuesStored);
			}
			valuesStored.Add(value);
		}


		/// <summary>
		/// Adds the objects as values for the specified key.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="values">Values.</param>
		public void Add(object key, ICollection values)
		{
			UniqueValueList valuesStored = null;
			if(base.ContainsKey(key))
			{
				// already there.
				valuesStored = (UniqueValueList)base[key];
			}
			else
			{
				// new
				valuesStored = new UniqueValueList();
				base.Add(key, valuesStored);
			}
			valuesStored.AddRange(values);
		}

		/// <summary>
		/// Determines whether the multivaluehashtable contains the key, and if so, if the list of values stored under the key contains the value specified.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <param name="value">Value.</param>
		/// <returns>true if the key exists and the list of values contains the specified value</returns>
		public virtual bool Contains(object key, object value)
		{
			if(!base.ContainsKey(key))
			{
				return false;
			}

			return ((UniqueValueList)this[key]).Contains(value);
		}


		/// <summary>
		/// Gets / sets a value for the given key. Hides original indexer
		/// </summary>
		/// <remarks>returns null if not found</remarks>
		public new UniqueValueList this[object key]
		{
			get
			{
				if(!base.ContainsKey(key))
				{
					return null;
				}
				return (UniqueValueList)base[key];
			}
			set
			{
				this.Add(key, value);
			}
		}
	}


	/// <summary>
	/// Special ArrayList which gets at construction time an entityfields array and an fieldpersistenceinfo array and splits it
	/// per target into a separate entry: a TargetFieldPersistenceInfoBucket, which contains 2 arrays with
	/// the information for that target. 
	/// It normally contains the same information as it gets at construction time, though in scenarios where inheritance is used and a target-per-
	/// entity hierarchy, this class is useful in update/insert/delete query building.
	/// </summary>
	public class EntityFieldPersistenceInfoList : ArrayList
	{
		/// <summary>
		/// Creates a new <see cref="EntityFieldPersistenceInfoList"/> instance.
		/// </summary>
		public EntityFieldPersistenceInfoList():base()
		{
		}

		
		/// <summary>
		/// Creates a new <see cref="EntityFieldPersistenceInfoList"/> instance. and splits the passed in fields/fieldpersistence info per target.
		/// The order in which the targets appear in fieldsPersistenceInfo is the order in which the TargetEntityFieldPersistenceInfoBucket objects
		/// are stored in this list.
		/// </summary>
		/// <param name="fields">Fields object to process. Can be null (in actions on db directly)</param>
		/// <param name="fieldsPersistenceInfo">persistence info objects to process</param>
		public EntityFieldPersistenceInfoList(IEntityFieldCore[] fields, IFieldPersistenceInfo[] fieldsPersistenceInfo):base()
		{
			int startIndex = 0;
			string previousTargetName = string.Empty;
			string currentTargetName = string.Empty;
			for (int i = 0; i < fieldsPersistenceInfo.Length; i++)
			{
				IFieldPersistenceInfo persistenceInfo = fieldsPersistenceInfo[i];
				previousTargetName = currentTargetName;
				currentTargetName = persistenceInfo.SourceCatalogName + "." + persistenceInfo.SourceSchemaName + "." + persistenceInfo.SourceObjectName;
				if(previousTargetName!=currentTargetName)
				{
					if(i!=0)
					{
						// found a new target, copy previous target fields into new TargetEntityFieldPersistenceInfoBucket object.
						TargetEntityFieldPersistenceInfoBucket bucket = new TargetEntityFieldPersistenceInfoBucket();
						bucket.Fields = new IEntityFieldCore[i-startIndex];
						bucket.FieldsPersistenceInfo = new IFieldPersistenceInfo[i-startIndex];
						if(fields!=null)
						{
							// always a field.
							Array.Copy(fields, startIndex, bucket.Fields, 0, (i-startIndex));
							bucket.ForEntityName = bucket.Fields[0].ContainingObjectName;
						}
						Array.Copy(fieldsPersistenceInfo, startIndex, bucket.FieldsPersistenceInfo, 0, (i-startIndex));
						this.Add(bucket);
					}
					startIndex=i;
				}
			}
			if(startIndex< fieldsPersistenceInfo.Length)
			{
				TargetEntityFieldPersistenceInfoBucket bucket = new TargetEntityFieldPersistenceInfoBucket();
				int rangeLength = fieldsPersistenceInfo.Length-startIndex;
				bucket.Fields = new IEntityFieldCore[rangeLength];
				bucket.FieldsPersistenceInfo = new IFieldPersistenceInfo[rangeLength];
				if(fields!=null)
				{
					Array.Copy(fields, startIndex, bucket.Fields, 0, rangeLength);
				}
				Array.Copy(fieldsPersistenceInfo, startIndex, bucket.FieldsPersistenceInfo, 0, rangeLength);
				this.Add(bucket);
			}
		}
	}


	/// <summary>
	/// Helperclass for the value instances of <see cref="EntityFieldPersistenceInfoList"/>
	/// Used in conjunction with EntityFieldPersistenceInfoHashtable by DQE's in Insert/Delete/Update query building
	/// </summary>
	public class TargetEntityFieldPersistenceInfoBucket
	{
		/// <summary>
		/// Array of references to entityfield objects
		/// </summary>
		public IEntityFieldCore[] Fields;
		/// <summary>
		/// Array of references to fieldpersistenceinfo objects
		/// </summary>
		public IFieldPersistenceInfo[] FieldsPersistenceInfo;
		/// <summary>
		/// For this entity name.
		/// </summary>
		public string ForEntityName;
	}


	/// <summary>
	/// Specialized Hashtable which contains name-value pairs for name overwriting for catalog names names in adapter 
	/// on some databases (db2, sqlserver)
	/// </summary>
	/// <remarks>Stores the overwrites in a from-to way, so the key is the from name and the name it should be come is in the value.
	/// You can use a wildcard in the form (key) part: * to define a name for all catalog names in the persistence info.</remarks>
	public class CatalogNameOverwriteHashtable : Hashtable
	{
		#region Class Member Declarations
		private CatalogNameUsage	_catalogNameUsageSetting;
		#endregion

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		public CatalogNameOverwriteHashtable(int capacity):base(capacity)
		{
			_catalogNameUsageSetting = CatalogNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		public CatalogNameOverwriteHashtable():base()
		{
			_catalogNameUsageSetting = CatalogNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="d">Dictionary</param>
		public CatalogNameOverwriteHashtable(IDictionary d):base(d)
		{
			_catalogNameUsageSetting = CatalogNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		/// <param name="catalogNameUsageSetting">the setting to use for name overwriting</param>
		public CatalogNameOverwriteHashtable(int capacity, CatalogNameUsage catalogNameUsageSetting):base(capacity)
		{
			_catalogNameUsageSetting = catalogNameUsageSetting;
		}

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="catalogNameUsageSetting">the setting to use for name overwriting</param>
		public CatalogNameOverwriteHashtable(CatalogNameUsage catalogNameUsageSetting):base()
		{
			_catalogNameUsageSetting = catalogNameUsageSetting;
		}

		/// <summary>
		/// Creates a new <see cref="CatalogNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="d">Dictionary</param>
		/// <param name="catalogNameUsageSetting">the setting to use for name overwriting</param>
		public CatalogNameOverwriteHashtable(IDictionary d, CatalogNameUsage catalogNameUsageSetting):base(d)
		{
			_catalogNameUsageSetting = catalogNameUsageSetting;
		}

		/// <summary>
		/// Gets / sets catalogNameUsageSetting
		/// </summary>
		public CatalogNameUsage CatalogNameUsageSetting
		{
			get
			{
				return _catalogNameUsageSetting;
			}
			set
			{
				_catalogNameUsageSetting = value;
			}
		}
	}

	/// <summary>
	/// Specialized Hashtable which contains name-value pairs for name overwriting for schema names names in adapter 
	/// on some databases (db2, sqlserver and oracle)
	/// </summary>
	/// <remarks>Stores the overwrites in a from-to way, so the key is the from name and the name it should be come is in the value.
	/// You can use a wildcard in the form (key) part: * to define a name for all schema names in the persistence info.</remarks>
	public class SchemaNameOverwriteHashtable : Hashtable
	{
		#region Class Member Declarations
		private SchemaNameUsage	_schemaNameUsageSetting;
		#endregion

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		public SchemaNameOverwriteHashtable(int capacity):base(capacity)
		{
			_schemaNameUsageSetting = SchemaNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		public SchemaNameOverwriteHashtable():base()
		{
			_schemaNameUsageSetting = SchemaNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="d">Dictionary</param>
		public SchemaNameOverwriteHashtable(IDictionary d):base(d)
		{
			_schemaNameUsageSetting = SchemaNameUsage.Default;
		}

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="capacity">Capacity.</param>
		/// <param name="schemaNameUsageSetting">the setting to use for name overwriting</param>
		public SchemaNameOverwriteHashtable(int capacity, SchemaNameUsage schemaNameUsageSetting):base(capacity)
		{
			_schemaNameUsageSetting = schemaNameUsageSetting;
		}

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="schemaNameUsageSetting">the setting to use for name overwriting</param>
		public SchemaNameOverwriteHashtable(SchemaNameUsage schemaNameUsageSetting):base()
		{
			_schemaNameUsageSetting = schemaNameUsageSetting;
		}

		/// <summary>
		/// Creates a new <see cref="SchemaNameOverwriteHashtable"/> instance.
		/// </summary>
		/// <param name="d">Dictionary</param>
		/// <param name="schemaNameUsageSetting">the setting to use for name overwriting</param>
		public SchemaNameOverwriteHashtable(IDictionary d, SchemaNameUsage schemaNameUsageSetting):base(d)
		{
			_schemaNameUsageSetting = schemaNameUsageSetting;
		}

		/// <summary>
		/// Gets / sets schemaNameUsageSetting
		/// </summary>
		public SchemaNameUsage SchemaNameUsageSetting
		{
			get
			{
				return _schemaNameUsageSetting;
			}
			set
			{
				_schemaNameUsageSetting = value;
			}
		}
	}



	/// <summary>
	/// Utility class which operates on numeric values and which applies arithmetic operations.  
	/// </summary>
	public class NumericValueOperatorExecutor
	{
		/// <summary>
		/// No public instances
		/// </summary>
		private NumericValueOperatorExecutor()
		{
		}

		/// <summary>
		/// Start method for the arithmetic operation interpreters. From here the type specific versions are called.
		/// </summary>
		/// <param name="leftOperandValue">The left operand value.</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">The right operand value.</param>
		/// <returns></returns>
		public static object PerformArithmethicOperation(object leftOperandValue, ExOp operatorToUse, object rightOperandValue)
		{
			switch(Type.GetTypeCode(leftOperandValue.GetType()))
			{
				case TypeCode.Byte:
					return PerformArithmethicOperation((byte)leftOperandValue, operatorToUse, (byte)rightOperandValue);
				case TypeCode.SByte:
					return PerformArithmethicOperation((sbyte)leftOperandValue, operatorToUse, (sbyte)rightOperandValue);
				case TypeCode.Int16:
					return PerformArithmethicOperation((short)leftOperandValue, operatorToUse, (short)rightOperandValue);
				case TypeCode.UInt16:
					return PerformArithmethicOperation((ushort)leftOperandValue, operatorToUse, (ushort)rightOperandValue);
				case TypeCode.Int32:
					return PerformArithmethicOperation((int)leftOperandValue, operatorToUse, (int)rightOperandValue);
				case TypeCode.UInt32:
					return PerformArithmethicOperation((uint)leftOperandValue, operatorToUse, (uint)rightOperandValue);
				case TypeCode.Int64:
					return PerformArithmethicOperation((long)leftOperandValue, operatorToUse, (long)rightOperandValue);
				case TypeCode.UInt64:
					return PerformArithmethicOperation((ulong)leftOperandValue, operatorToUse, (ulong)rightOperandValue);
				case TypeCode.Single:
					return PerformArithmethicOperation((float)leftOperandValue, operatorToUse, (float)rightOperandValue);
				case TypeCode.Double:
					return PerformArithmethicOperation((double)leftOperandValue, operatorToUse, (double)rightOperandValue);
				case TypeCode.Decimal:
					return PerformArithmethicOperation((decimal)leftOperandValue, operatorToUse, (decimal)rightOperandValue);
				case TypeCode.Object:
					if(leftOperandValue is string)
					{
						return PerformArithmethicOperation((string)leftOperandValue, operatorToUse, (string)rightOperandValue);
					}
					break;
			}

			// else the type is not supported

			return DBNull.Value;
		}

		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(int leftOperandValue, ExOp operatorToUse, int rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = leftOperandValue | rightOperandValue;
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}

		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(byte leftOperandValue, ExOp operatorToUse, byte rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = leftOperandValue | rightOperandValue;
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}

		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(sbyte leftOperandValue, ExOp operatorToUse, sbyte rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = (sbyte)((byte)leftOperandValue | (byte)rightOperandValue);
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(short leftOperandValue, ExOp operatorToUse, short rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = (short)((ushort)leftOperandValue | (ushort)rightOperandValue);
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(ushort leftOperandValue, ExOp operatorToUse, ushort rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = leftOperandValue | rightOperandValue;
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(long leftOperandValue, ExOp operatorToUse, long rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = leftOperandValue | rightOperandValue;
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(ulong leftOperandValue, ExOp operatorToUse, ulong rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
				case ExOp.BitwiseAnd:
					toReturn = leftOperandValue & rightOperandValue;
					break;
				case ExOp.BitwiseOr:
					toReturn = leftOperandValue | rightOperandValue;
					break;
				case ExOp.BitwiseXor:
					toReturn = leftOperandValue ^ rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(float leftOperandValue, ExOp operatorToUse, float rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(double leftOperandValue, ExOp operatorToUse, double rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
			}

			return toReturn;
		}


		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		private static object PerformArithmethicOperation(decimal leftOperandValue, ExOp operatorToUse, decimal rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Div:
					toReturn = leftOperandValue / rightOperandValue;
					break;
				case ExOp.Mod:
					toReturn = leftOperandValue % rightOperandValue;
					break;
				case ExOp.Mul:
					toReturn = leftOperandValue * rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue - rightOperandValue;
					break;
			}

			return toReturn;
		}



		/// <summary>
		/// Performs an arithmetic operation on the operands passed in. The operator executed is the operator of this expression.
		/// </summary>
		/// <param name="leftOperandValue">left operand</param>
		/// <param name="operatorToUse">The operator to use.</param>
		/// <param name="rightOperandValue">right operand</param>
		/// <returns>result of the arithmetic operation</returns>
		/// <remarks>This routine only handles + and -. + concatenates the strings, - removes right operand from left operand.</remarks>
		private static object PerformArithmethicOperation(string leftOperandValue, ExOp operatorToUse, string rightOperandValue)
		{
			object toReturn = null;

			switch(operatorToUse)
			{
				case ExOp.Add:
					toReturn = leftOperandValue + rightOperandValue;
					break;
				case ExOp.Sub:
					toReturn = leftOperandValue.Replace(rightOperandValue, string.Empty);
					break;
			}

			return toReturn;
		}
	}


	/// <summary>
	/// Simple struct which is used for pairs of int values. It's mutable, though should be used for simple pairing 2 values together,
	/// like ordinal/fieldindex.
	/// </summary>
	public struct IntValuePair
	{
		/// <summary>
		/// First value of the pair
		/// </summary>
		public int Value1;
		/// <summary>
		/// Second value of the pair.
		/// </summary>
		public int Value2;

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="value1">The first value</param>
		/// <param name="value2">the second value</param>
		public IntValuePair(int  value1, int value2)
		{
			Value1 = value1;
			Value2 = value2;
		}
	}


	/// <summary>
	/// Class which crawls over a predicate, expression etc. and finds all containingentitynames and actualentitynames of the fields found.
	/// </summary>
	internal class EntityNameFinder
	{
		#region Class Member Declarations
		private MultiValueHashtable	_aliasesPerContainingObjectName, _aliasesPerActualContainingObjectName;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="EntityNameFinder"/> class.
		/// </summary>
		internal EntityNameFinder()
		{
			_aliasesPerContainingObjectName = new MultiValueHashtable();
			_aliasesPerActualContainingObjectName = new MultiValueHashtable();
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		internal void FindNames(object objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}
			if(objectToTraverse is IPredicate)
			{
				FindNames((IPredicate)objectToTraverse);
			}
			else
			{
				if(objectToTraverse is RelationCollection)
				{
					FindNames((RelationCollection)objectToTraverse);
				}
				else
				{
					if(objectToTraverse is IExpression)
					{
						FindNames((IExpression)objectToTraverse);
					}
					else
					{
						if(objectToTraverse is SortExpression)
						{
							FindNames((SortExpression)objectToTraverse);
						}
						else
						{
							if(objectToTraverse is GroupByCollection)
							{
								FindNames((GroupByCollection)objectToTraverse);
							}
							else
							{
								if(objectToTraverse is IEntityFieldCore)
								{
									FindNames((IEntityFieldCore)objectToTraverse);
								}
								else
								{
									if(objectToTraverse is IEnumerable)
									{
										foreach(object value in ((IEnumerable)objectToTraverse))
										{
											FindNames(value);
										}
									}
								}
							}
						}
					}
				}
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="field">The field.</param>
		private void FindNames(IEntityFieldCore field)
		{
			FindNames(field, field.ObjectAlias);
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="field">The field.</param>
		/// <param name="objectAlias">The object alias.</param>
		private void FindNames(IEntityFieldCore field, string objectAlias)
		{
			if(field == null)
			{
				return;
			}
			string aliasToUse = field.ObjectAlias;
			if((objectAlias!=null) && (objectAlias.Length > 0))
			{
				aliasToUse = objectAlias;
			}
			_aliasesPerContainingObjectName.Add(field.ContainingObjectName, aliasToUse);
			_aliasesPerActualContainingObjectName.Add(field.ActualContainingObjectName, aliasToUse);
			FindNames(field.ExpressionToApply);
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IPredicate objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}
			if(objectToTraverse is IPredicateExpression)
			{
				IPredicateExpression predicateExpression = objectToTraverse as IPredicateExpression;
				foreach(IPredicateExpressionElement element in predicateExpression)
				{
					if((element.Type == PredicateExpressionElementType.Operator) || (element.Type == PredicateExpressionElementType.Empty))
					{
						continue;
					}
					FindNames((IPredicate)element.Contents);
				}
			}
			else
			{
				FindNamesInPredicate(objectToTraverse);
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNamesInPredicate(IPredicate objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			switch((PredicateType)objectToTraverse.InstanceType)
			{
				case PredicateType.FieldBetweenPredicate:
					FieldBetweenPredicate betweenPredicate = (FieldBetweenPredicate)objectToTraverse;
					FindNames(betweenPredicate.FieldCore);
					if(betweenPredicate.BeginIsField)
					{
						FindNames(betweenPredicate.FieldBeginCore, betweenPredicate.ObjectAlias);
					}
					if(betweenPredicate.EndIsField)
					{
						FindNames(betweenPredicate.FieldEndCore, betweenPredicate.ObjectAlias);
					}
					break;
				case PredicateType.FieldCompareNullPredicate:
					FieldCompareNullPredicate compareNullPredicate = (FieldCompareNullPredicate)objectToTraverse;
					FindNames(compareNullPredicate.FieldCore, compareNullPredicate.ObjectAlias);
					break;
				case PredicateType.FieldCompareValuePredicate:
					FieldCompareValuePredicate compareValuePredicate = (FieldCompareValuePredicate)objectToTraverse;
					FindNames(compareValuePredicate.FieldCore, compareValuePredicate.ObjectAlias);
					break;
				case PredicateType.FieldLikePredicate:
					FieldLikePredicate likePredicate = (FieldLikePredicate)objectToTraverse;
					FindNames(likePredicate.FieldCore, likePredicate.ObjectAlias);
					break;
				case PredicateType.FieldCompareRangePredicate:
					FieldCompareRangePredicate compareRangePredicate = (FieldCompareRangePredicate)objectToTraverse;
					FindNames(compareRangePredicate.FieldCore, compareRangePredicate.ObjectAlias);
					break;
				case PredicateType.FieldCompareExpressionPredicate:
					FieldCompareExpressionPredicate expressionPredicate = (FieldCompareExpressionPredicate)objectToTraverse;
					FindNames(expressionPredicate.FieldCore, expressionPredicate.ObjectAlias);
					FindNames(expressionPredicate.ExpressionToCompareWith);
					break;
				case PredicateType.FieldFullTextSearchPredicate:
					FieldFullTextSearchPredicate fullTextSearchPredicate = (FieldFullTextSearchPredicate)objectToTraverse;
					if(fullTextSearchPredicate.TargetIsFieldList)
					{
						foreach(IEntityFieldCore field in fullTextSearchPredicate.FieldsList)
						{
							FindNames(field, fullTextSearchPredicate.ObjectAlias);
						}
					}
					else
					{
						FindNames(fullTextSearchPredicate.FieldCore, fullTextSearchPredicate.ObjectAlias);
					}
					break;
				case PredicateType.FieldCompareSetPredicate:
					FieldCompareSetPredicate compareSetPredicate = (FieldCompareSetPredicate)objectToTraverse;
					FindNames(compareSetPredicate.FieldCore, compareSetPredicate.ObjectAlias);
					FindNames(compareSetPredicate.SetFieldCore);
					FindNames(compareSetPredicate.GroupByClause);
					FindNames(compareSetPredicate.SetFilter);
					FindNames(compareSetPredicate.SetRelations);
					FindNames(compareSetPredicate.SetSorter);
					break;
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IRelationCollection objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			for(int i = 0; i < objectToTraverse.Count; i++)
			{
				IEntityRelation entityRelation = objectToTraverse[i];
				string aliasPkSide = string.Empty;
				string aliasFkSide = string.Empty;
				if(entityRelation.StartEntityIsPkSide)
				{
					aliasFkSide = entityRelation.AliasEndEntity;
					aliasPkSide = entityRelation.AliasStartEntity;
				}
				else
				{
					aliasPkSide = entityRelation.AliasEndEntity;
					aliasFkSide = entityRelation.AliasStartEntity;
				}
				for(int j = 0; j < entityRelation.AmountFields; j++)
				{
					FindNames(entityRelation.GetPKEntityFieldCore(j), aliasFkSide);
					FindNames(entityRelation.GetFKEntityFieldCore(j), aliasPkSide);
					FindNames(entityRelation.CustomFilter);
				}

				if(entityRelation.InheritanceInfoPkSideEntity != null)
				{
					FindNames(entityRelation.InheritanceInfoPkSideEntity.RelationsToHierarchyRoot);
				}
				if(entityRelation.InheritanceInfoFkSideEntity != null)
				{
					FindNames(entityRelation.InheritanceInfoFkSideEntity.RelationsToHierarchyRoot);
				}
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IExpression objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			if(objectToTraverse.LeftOperand == null)
			{
				// none set
				return;
			}

			// left operand isn't null, set it if required
			switch(objectToTraverse.LeftOperand.Type)
			{
				case ExpressionElementType.Expression:
					FindNames((IExpression)objectToTraverse.LeftOperand.Contents);
					break;
				case ExpressionElementType.Field:
					IExpressionFieldElement fieldElement = (IExpressionFieldElement)objectToTraverse.LeftOperand;
					FindNames((IEntityFieldCore)fieldElement.Contents);
					break;
				case ExpressionElementType.FunctionCall:
					FindNames((IDbFunctionCall)objectToTraverse.LeftOperand.Contents);
					break;
				case ExpressionElementType.ScalarQuery:
					FindNames((IScalarQueryExpression)objectToTraverse.LeftOperand.Contents);
					break;
			}

			if(objectToTraverse.RightOperand != null)
			{
				switch(objectToTraverse.RightOperand.Type)
				{
					case ExpressionElementType.Expression:
						FindNames((IExpression)objectToTraverse.RightOperand.Contents);
						break;
					case ExpressionElementType.Field:
						IExpressionFieldElement fieldElement = (IExpressionFieldElement)objectToTraverse.RightOperand;
						FindNames((IEntityFieldCore)fieldElement.Contents);
						break;
					case ExpressionElementType.FunctionCall:
						FindNames((IDbFunctionCall)objectToTraverse.LeftOperand.Contents);
						break;
					case ExpressionElementType.ScalarQuery:
						FindNames((IScalarQueryExpression)objectToTraverse.LeftOperand.Contents);
						break;
				}
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IScalarQueryExpression objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			FindNames(objectToTraverse.SelectField);
			FindNames(objectToTraverse.FilterToUse);
			FindNames(objectToTraverse.RelationsToUse);
			FindNames(objectToTraverse.SorterToUse);
			FindNames(objectToTraverse.GroupByClause);
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IDbFunctionCall objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			for(int i = 0; i < objectToTraverse.FunctionParameters.Length; i++)
			{
				IExpression parameterAsExpression = objectToTraverse.FunctionParameters[i] as IExpression;
				if(parameterAsExpression != null)
				{
					FindNames(parameterAsExpression);
				}
				else
				{
					IEntityFieldCore parameterAsField = objectToTraverse.FunctionParameters[i] as IEntityFieldCore;
					if(parameterAsField != null)
					{
						FindNames(parameterAsField);
					}
				}
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(ISortExpression objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			for(int i = 0; i < objectToTraverse.Count; i++)
			{
				FindNames(objectToTraverse[i].FieldToSortCore);
			}
		}


		/// <summary>
		/// Finds all containingObjectNames and ActualContainingObjectNames of all fields in the object passed in and enclosed fields in enclosed objects.
		/// </summary>
		/// <param name="objectToTraverse">The object to traverse.</param>
		private void FindNames(IGroupByCollection objectToTraverse)
		{
			if(objectToTraverse == null)
			{
				return;
			}

			for(int i = 0; i < objectToTraverse.Count; i++)
			{
				FindNames(objectToTraverse[i]);
			}
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets the found containing object names and all the aliases they're stored under.
		/// </summary>
		internal MultiValueHashtable AliasesPerContainingObjectName
		{
			get { return _aliasesPerContainingObjectName; }
		}


		/// <summary>
		/// Gets the found actual containing object names and all the aliases they're stored under.
		/// </summary>
		internal MultiValueHashtable AliasesPerActualContainingObjectName
		{
			get { return _aliasesPerActualContainingObjectName; }
		}
		#endregion
	}
	

	/// <summary>
	/// Class which is used to store core methods used in various parts of the persistence pipeline, and which are shared among selfservicing and adapter.
	/// </summary>
	internal class PersistenceCore
	{
		/// <summary>
		/// Determines the inheritance relations which are necessary to add to the query defined by fields, relations and filter.
		/// </summary>
		/// <param name="fields">The fields.</param>
		/// <param name="relations">The relations.</param>
		/// <param name="filter">The filter.</param>
		/// <param name="inheritanceProvider">The inheritance provider.</param>
		/// <returns>RelationsCollection filled with the hierarchy relations required to fulfill the query, or an empty collection if none are needed.</returns>
		internal static RelationCollection DetermineInheritanceRelations(IEnumerable fields, IRelationCollection relations, IPredicate filter, 
			IInheritanceInfoProvider inheritanceProvider)
		{
			RelationCollection toReturn = new RelationCollection();
			EntityNameFinder finder = new EntityNameFinder();
			// find all containingobjectnames in fields, relations and filter. We need the containing names as those are the ones which are important
			// for hierarchy relations.
			// first obtain the names in the relations. These are the names we'll use to obtain leaf paths for. All names found 
			// in fields and filter which are on such a leaf path should be used to obtain additional hierarchy relations. Otherwise, it's not necessary, as
			// the name in the relations found already takes care of it (due to the relation present).
			finder.FindNames(relations);
			// get all names with all the aliases they're used with.
			MultiValueHashtable namesAliasesFoundInRelations = finder.AliasesPerContainingObjectName;
			UniqueValueList subtypesFound = new UniqueValueList();
			// get all subtypes of all names found in the relations. 
			foreach(DictionaryEntry pair in namesAliasesFoundInRelations)
			{
				IInheritanceInfo inheritanceInfo = inheritanceProvider.GetInheritanceInfo((string)pair.Key, false);
				if((inheritanceInfo == null) || (inheritanceInfo.HierarchyType != InheritanceHierarchyType.TargetPerEntity))
				{
					// ignore, as it's not a type in a hierarchy of type TargetPerEntity
					continue;
				}
				// all subtype names can be found in the inheritance info. 
				if(inheritanceInfo.EntityNamesOfPathsToLeafs.Count > 0)
				{
					foreach(string subType in inheritanceInfo.EntityNamesOfPathsToLeafs)
					{
						// if a subtype is already in the list of names found in the relations, skip it, as it's already covered.
						if(namesAliasesFoundInRelations.ContainsKey(subType))
						{
							continue;
						}
						subtypesFound.Add(subType);
					}
				}
			}

			// now create a new finder and obtain all names from fields and filter.
			finder = new EntityNameFinder();
			finder.FindNames(fields);
			finder.FindNames(filter);
			MultiValueHashtable namesAliasesFromFieldsFilter = finder.AliasesPerContainingObjectName;

			MultiValueHashtable namesToObtainHierarchyRelationsFor = new MultiValueHashtable();
			// now traverse the names found in fields/filter. If they match a name in the list of subtypes, they're thus not covered by the relations in the 
			// relation collection. If there are no relations, we have to consider every name
			foreach(DictionaryEntry pair in namesAliasesFromFieldsFilter)
			{
				if((relations==null) || (relations.Count<=0) || subtypesFound.Contains((string)pair.Key))
				{
					namesToObtainHierarchyRelationsFor.Add((string)pair.Key, (UniqueValueList)pair.Value);
				}
			}

			// we've now a list of names for which we have to obtain the hierarchy relations for. 
			foreach(DictionaryEntry pair in namesToObtainHierarchyRelationsFor)
			{
				// key is name, value is list of aliases this name is used in and under those aliases the relations are added one by one.
				IInheritanceInfo info = inheritanceProvider.GetInheritanceInfo((string)pair.Key, true);
				if(info == null)
				{
					continue;
				}
				// get hierarchy relations of path from entity to root.
				RelationCollection hierarchyRelations = info.RelationsToHierarchyRoot;
				if(hierarchyRelations != null)
				{
					// now add for each alias found every relation to this list.
					foreach(string alias in (UniqueValueList)pair.Value)
					{
						foreach(IEntityRelation toAdd in hierarchyRelations)
						{
							// specify LEFT as it might be some entities might not be at the same inheritance path, so inner joins would result in 0 rows
							// and as there's a field on the path in the fieldslist specified, the null values won't matter. 
							toReturn.Add(toAdd, alias, alias, JoinHint.Left);
						}
					}
				}
			}
			
			return toReturn;

		}
	}
}
