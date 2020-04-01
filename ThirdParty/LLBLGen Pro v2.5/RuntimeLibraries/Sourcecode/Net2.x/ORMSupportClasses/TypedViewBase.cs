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
//		- Simon Hewitt
//////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
#if !CF
using System.Runtime.Serialization;
using System.Collections.Specialized;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// General base class for typedviews. This class is used to place internal framework oriented code inside a typedview 
	/// </summary>
#if !CF
	[Serializable, System.ComponentModel.DesignerCategory("Code")]
#endif
	public abstract class TypedViewBase : DataTable
#if !CF
		, IOwnedDataSerializable
#endif
	{

		/// <summary>
		/// Empty CTor
		/// </summary>
		public TypedViewBase()
		{
#if !CF
			base.RemotingFormat = SerializationFormat.Binary;
#endif
		}


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="tableName">Name of the table.</param>
		public TypedViewBase(string tableName)
			: base(tableName)
		{
#if !CF
			base.RemotingFormat = SerializationFormat.Binary;
#endif
		}

#if !CF
		/// <summary>
		/// Protected constructor for deserialization.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected TypedViewBase(SerializationInfo info, StreamingContext context):base(info, context)
		{
			if (SerializationHelper.Optimization == SerializationOptimization.None)
			{
				base.RemotingFormat = (SerializationFormat)info.GetValue("_remotingFormat", typeof(SerializationFormat));
			}
			else
			{
				InitClass();
				byte[] serializedData = (byte[]) info.GetValue(SerializationHelper.SerializationKey, typeof(byte[]));
				SerializationReader reader = new SerializationReader(serializedData);
				SerializationHelper.DeserializeSimpleReadOnlyTableData(reader, this);
			}
		}


		/// <summary>
		/// Populates a serialization information object with the data needed to serialize the <see cref="T:System.Data.DataTable"></see>.
		/// </summary>
		/// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> object that holds the serialized data associated with the <see cref="T:System.Data.DataTable"></see>.</param>
		/// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext"></see> object that contains the source and destination of the serialized stream associated with the <see cref="T:System.Data.DataTable"></see>.</param>
		/// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic).</exception>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (SerializationHelper.Optimization == SerializationOptimization.None)
			{
				info.AddValue("_remotingFormat", base.RemotingFormat);
				base.GetObjectData(info, context);
			}
			else
			{
				FastSerializer fastSerializer = new FastSerializer();
				byte[] serializedData = fastSerializer.Serialize(this).ToArray();
				info.AddValue(SerializationHelper.SerializationKey, serializedData);
				info.AddValue("XmlSchema", null);
				info.AddValue("XmlDiffGram", null);
			}
		}


		#region Optimized Serialization related code
		/// <summary>
		/// Serializes the owned data.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="context">The context.</param>
		public virtual void SerializeOwnedData(SerializationWriter writer, object context)
		{
			SerializationHelper.SerializeSimpleReadOnlyTableData(writer, this);
		}

		/// <summary>
		/// Deserializes the owned data.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="context">The context.</param>
		public virtual void DeserializeOwnedData(SerializationReader reader, object context)
		{
			SerializationHelper.DeserializeSimpleReadOnlyTableData(reader, this);
		}
		#endregion Optimized Serialization
#endif

		/// <summary>
		/// Inits the class.
		/// </summary>
		protected virtual void InitClass()
		{

		}


		/// <summary>
		/// Method which is called at the end of the InitClass() method in the generated typedview class. 
		/// </summary>
		protected virtual void OnInitialized()
		{
		}
	}
}
