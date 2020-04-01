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
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.IO;
#if !CF
using System.Runtime.Serialization;
#endif

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// EntityCollection implementation which is used for backwards compatibility and for design time databinding. This EntityCollectionNonGeneric
	/// is an EntityCollectionBase2(Of EntityBase2)
	/// </summary>
	[Serializable]
#if !CF
	[ToolboxItem(true)]
#endif
	public class EntityCollectionNonGeneric : EntityCollectionBase2<EntityBase2>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="EntityCollectionNonGeneric"/> class.
		/// </summary>
		/// <remarks>En</remarks>
		public EntityCollectionNonGeneric() : base((IEntityFactory2)null)
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="entityFactoryToUse">The entity factory object to use when this collection has to construct new objects.
		/// This is the case when the collection is bound to a grid-like control for example.</param>
		public EntityCollectionNonGeneric( IEntityFactory2 entityFactoryToUse )
			: base( entityFactoryToUse )
		{
		}


		/// <summary>
		/// Protected CTor for deserialization
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected EntityCollectionNonGeneric( SerializationInfo info, StreamingContext context )
			: base( info, context )
		{
		}
	}
}
