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
using System.Diagnostics;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Container class for the static traceswitch objects used by the tracing logic in the ORMSupportclasses.
	/// </summary>
	public class TraceHelper
	{
		#region Static members
		/// <summary>
		/// General switch which is used by general code in the ORM Support classes.
		/// </summary>
		public static TraceSwitch GeneralSwitch; 
		/// <summary>
		/// Switch which is used by state management code in the ORM Support classes.
		/// </summary>
		public static TraceSwitch StateManagementSwitch;
		/// <summary>
		/// Switch which is used by entity / other data persistence logic execution code in the ORM Support classes
		/// </summary>
		public static TraceSwitch PersistenceExecutionSwitch;
		#endregion

		/// <summary>
		/// No instances allowed
		/// </summary>
		private TraceHelper()
		{
		}

		/// <summary>
		/// Static constructor. Is called by the CLR right before the first trace is made. 
		/// </summary>
		static TraceHelper()
		{
			TraceHelper.GeneralSwitch = new TraceSwitch("ORMGeneral", "General Tracer for ORM Support classes library");
			TraceHelper.StateManagementSwitch = new TraceSwitch("ORMStateManagement", "Tracer for state management code in the ORM Support classes library");
			TraceHelper.PersistenceExecutionSwitch = new TraceSwitch("ORMPersistenceExecution", "Tracer for persistence logic execution code in the ORM Support classes library");
		}


		/// <summary>
		/// Writes the value with no category specified to the trace output with a newline, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the value has to be written (true) or not (false)</param>
		/// <param name="value">Value to write to the trace output</param>
		public static void WriteLineIf(bool condition, object value)
		{
			if( condition )
			{
				WriteLineIf( condition, value.ToString(), string.Empty );
			}
		}


		/// <summary>
		/// Writes the message with no category specified to the trace output with a newline, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the message has to be written (true) or not (false)</param>
		/// <param name="message">Message to write to the trace output</param>
		public static void WriteLineIf(bool condition, string message)
		{
			if( condition )
			{
				WriteLineIf( condition, message, string.Empty );
			}
		}


		/// <summary>
		/// Writes the value with the remark of the category specified to the trace output with a newline, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the value has to be written (true) or not (false)</param>
		/// <param name="value">Value to write to the trace output</param>
		/// <param name="category">Category to specify with the value</param>
		public static void WriteLineIf(bool condition, object value, string category)
		{
			if( condition )
			{
				WriteLineIf( condition, value.ToString(), category );
			}
		}


		/// <summary>
		/// Writes the message with the remark of the category specified to the trace output with a newline, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the message has to be written (true) or not (false)</param>
		/// <param name="message">Message to write to the trace output</param>
		/// <param name="category">Category to specify with the message</param>
		public static void WriteLineIf(bool condition, string message, string category)
		{
#if !CF
			if(condition)
			{
				Trace.WriteLine(message, category);
			}
#endif
		}


		/// <summary>
		/// Writes the value with no category specified to the trace output, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the value has to be written (true) or not (false)</param>
		/// <param name="value">Value to write to the trace output</param>
		public static void WriteIf(bool condition, object value)
		{
			if( condition )
			{
				WriteLineIf( condition, value.ToString(), string.Empty );
			}
		}


		/// <summary>
		/// Writes the message with no category specified to the trace output, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the message has to be written (true) or not (false)</param>
		/// <param name="message">Message to write to the trace output</param>
		public static void WriteIf(bool condition, string message)
		{
			if( condition )
			{
				WriteLineIf( condition, message, string.Empty );
			}
		}


		/// <summary>
		/// Writes the value with the remark of the category specified to the trace output, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the value has to be written (true) or not (false)</param>
		/// <param name="value">Value to write to the trace output</param>
		/// <param name="category">Category to specify with the value</param>
		public static void WriteIf(bool condition, object value, string category)
		{
			if( condition )
			{
				WriteLineIf( condition, value.ToString(), category );
			}
		}


		/// <summary>
		/// Writes the message with the remark of the category specified to the trace output, if condition is true.
		/// </summary>
		/// <param name="condition">Condition to test if the message has to be written (true) or not (false)</param>
		/// <param name="message">Message to write to the trace output</param>
		/// <param name="category">Category to specify with the message</param>
		public static void WriteIf(bool condition, string message, string category)
		{
#if !CF
			if(condition)
			{
				Trace.Write(message, category);
			}
#endif
		}
	}
}
