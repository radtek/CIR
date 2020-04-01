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
using System.Runtime.Serialization;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for all ORM exceptions. 
	/// </summary>
	[Serializable]
	public class ORMException : System.ApplicationException
	{
		#region Class Member Declarations
		private string _runtimeVersion, _runtimeBuild;
		#endregion

		/// <summary>
		/// CTor
		/// </summary>
		public ORMException() : this(string.Empty, null)
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMException(string message) : this(message, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ORMException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		/// <param name="innerException">Inner exception.</param>
		public ORMException(string message, Exception innerException) : base(message, innerException)
		{
			_runtimeVersion = RuntimeLibraryVersion.Version;
			_runtimeBuild = RuntimeLibraryVersion.Build;
		}

#if !CF
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
			_runtimeVersion = info.GetString( "_runtimeVersion" );
			_runtimeBuild = info.GetString( "_runtimeBuild" );
		}

		/// <summary>
		/// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic). </exception>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
		public override void GetObjectData( SerializationInfo info, StreamingContext context )
		{
			info.AddValue( "_runtimeVersion", _runtimeVersion );
			info.AddValue( "_runtimeBuild", _runtimeBuild );
			base.GetObjectData( info, context );
		}

#else
		/// <summary>
		/// Dummy stub
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMException(SerializationInfo info, StreamingContext context)
		{
		}
#endif

		#region Class Property Declarations
		/// <summary>
		/// Gets the runtime version number of the code which threw the exception.
		/// </summary>
		/// <value>The runtime version.</value>
		public string RuntimeVersion
		{
			get { return _runtimeVersion; }
		}

		/// <summary>
		/// Gets the runtime build number of the code which threw the exception.
		/// </summary>
		/// <value>The runtime build.</value>
		public string RuntimeBuild
		{
			get { return _runtimeBuild; }
		}
		#endregion
	}
	

	/// <summary>
	/// timeout exception for TimeOut locks used inside the code. This exception should only pop up when a timed lock timed out, which is to prevent deadlocks.
	/// </summary>
	[Serializable]
	public class ORMLockTimeoutException : ORMException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORMLockTimeoutException"/> class.
		/// </summary>
		public ORMLockTimeoutException()
			: base("Timeout waiting for lock")
		{
		}
	}


	/// <summary>
	/// Exception class which is thrown when a value being optimized does not meet the required criteria for optimization.
	/// </summary>
	public class ORMSerializationOptimizationException : ORMException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSerializationOptimizationException"/> class.
		/// </summary>
		/// <param name="message">Message.</param>
		public ORMSerializationOptimizationException(string message) : base(message) 
		{ 
		}
	}


	/// <summary>
	/// Exception class which is usable for security exceptions thrown by authorizers. 
	/// </summary>
	[Serializable]
	public class ORMSecurityException : ORMException
	{
		#region Class Member Declarations
		private IEntityCore	_affectedEntity;
		private string		_auditAction;
		private Type		_affectedEntityType;
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		public ORMSecurityException() : this(string.Empty, (IEntityCore)null, string.Empty)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public ORMSecurityException(string message)
			: this(message, (IEntityCore)null, string.Empty)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="affectedEntity">The affected entity.</param>
		public ORMSecurityException(string message, IEntityCore affectedEntity)
			: this(message, affectedEntity, string.Empty)
		{
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="affectedEntityType">Type of the affected entity.</param>
		public ORMSecurityException(string message, Type affectedEntityType)
			: this(message, affectedEntityType, string.Empty)
		{ 
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="affectedEntity">The affected entity.</param>
		/// <param name="auditAction">The audit action.</param>
		public ORMSecurityException(string message, IEntityCore affectedEntity, string auditAction)
			: base(message)
		{
			_affectedEntity = affectedEntity;
			_auditAction = auditAction;
			_affectedEntityType = null;
		}


		/// <summary>
		/// Initializes a new instance of the <see cref="ORMSecurityException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="affectedEntityType">Type of the affected entity.</param>
		/// <param name="auditAction">The audit action.</param>
		public ORMSecurityException(string message, Type affectedEntityType, string auditAction)
			: base(message)
		{
			_affectedEntityType = affectedEntityType;
			_affectedEntity = null;
			_auditAction = auditAction;
		}

		
#if !CF		
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMSecurityException(SerializationInfo info, StreamingContext context)
			: base( info, context ) 
		{
			_affectedEntity = (IEntityCore)info.GetValue("_affectedEntity", typeof(IEntityCore));
			_affectedEntityType = (Type)info.GetValue("_affectedEntityType", typeof(Type));
			_auditAction = info.GetString("_auditAction");
		}

		/// <summary>
		/// When overridden in a derived class, sets the <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> with information about the exception.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"></see> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"></see> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">The info parameter is a null reference (Nothing in Visual Basic). </exception>
		/// <PermissionSet><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*"/><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter"/></PermissionSet>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			base.GetObjectData(info, context);
			info.AddValue("_affectedEntity", _affectedEntity);
			info.AddValue("_affectedEntityType", _affectedEntityType);
			info.AddValue("_auditAction", _auditAction);
		}
#endif


		#region Class Property Declarations
		/// <summary>
		/// Gets / sets auditAction
		/// </summary>
		public string AuditAction
		{
			get
			{
				return _auditAction;
			}
			set
			{
				_auditAction = value;
			}
		}

		/// <summary>
		/// Gets / sets affectedEntityType
		/// </summary>
		public Type AffectedEntityType
		{
			get
			{
				return _affectedEntityType;
			}
			set
			{
				_affectedEntityType = value;
			}
		}

		/// <summary>
		/// Gets / sets affectedEntity
		/// </summary>
		public IEntityCore AffectedEntity
		{
			get
			{
				return _affectedEntity;
			}
			set
			{
				_affectedEntity = value;
			}
		}

		#endregion
	}


	/// <summary>
	/// Exception which is thrown when the general operation of the o/r core isnt used correctly, like bad imput has been given and no other 
	/// exception is appropriate.
	/// </summary>
	[Serializable]
	public class ORMGeneralOperationException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		public ORMGeneralOperationException()
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMGeneralOperationException( string message )
			: base( message )
		{
		}

		
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMGeneralOperationException( SerializationInfo info, StreamingContext context )
			: base( info, context ) 
		{
		}
	}


	/// <summary>
	/// Exception which is thrown when a developer reads a field from a new entity which isn't set to a value yet. 
	/// Only thrown when the EntityBase(2).MakeInvalidFieldReadsFatal flag is set to true (default: false). 
	/// </summary>
	[Serializable]
	public class ORMInvalidFieldReadException : ORMException
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ORMInvalidFieldReadException"/> class.
		/// </summary>
		public ORMInvalidFieldReadException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ORMInvalidFieldReadException"/> class.
		/// </summary>
		/// <param name="message">The message.</param>
		public ORMInvalidFieldReadException( string message )
			: base( message )
		{
		}

				
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMInvalidFieldReadException( SerializationInfo info, StreamingContext context )
			: base( info, context ) 
		{
		}
	}


	/// <summary>
	/// General exception which is thrown when an interpretation error occurs during predicate / sortclause interpretation for filtering or sorting in-memory
	/// in an EntityView(2).
	/// </summary>
	[Serializable]
	public class ORMInterpretationException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		public ORMInterpretationException()
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMInterpretationException( string message )
			: base( message )
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMInterpretationException( SerializationInfo info, StreamingContext context )
			: base( info, context ) 
		{
		}
	}


	/// <summary>
	/// General exception which is thrown when an error is determined in the inheritance info during query execution.
	/// </summary>
	[Serializable]
	public class ORMInheritanceInfoException: ORMException
	{
		/// <summary>
		/// CTOr
		/// </summary>
		public ORMInheritanceInfoException()
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMInheritanceInfoException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMInheritanceInfoException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception which is thrown when an error occurs during the construction of the query to execute.
	/// </summary>
	[Serializable]
	public class ORMQueryConstructionException: ORMException
	{
		/// <summary>
		/// CTOr
		/// </summary>
		public ORMQueryConstructionException()
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMQueryConstructionException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMQueryConstructionException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when something is wrong with a relation or with the context
	/// the relation is used in (ToQueryText in RelationCollection for example)
	/// </summary>
	[Serializable]
	public class ORMRelationException: ORMException
	{
		/// <summary>
		/// CTOr
		/// </summary>
		public ORMRelationException()
		{
		}

		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">Exception message</param>
		public ORMRelationException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMRelationException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when a user sets a field which is readonly.
	/// </summary>
	[Serializable]
	public class ORMFieldIsReadonlyException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		public ORMFieldIsReadonlyException(string message):base(message)
		{
		}


		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMFieldIsReadonlyException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when a user tries to get a value from a field which is null.
	/// </summary>
	[Serializable]
	public class ORMFieldIsNullException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		public ORMFieldIsNullException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMFieldIsNullException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when a user tries to get a value from a field of an entity which is
	/// marked as OutOfSync, and needs to be refetched.
	/// </summary>
	[Serializable]
	public class ORMEntityOutOfSyncException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		public ORMEntityOutOfSyncException(string message):base(message)
		{
		}

		
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMEntityOutOfSyncException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when a user tries to get a value from a field of an entity which is
	/// marked as Deleted.
	/// </summary>
	[Serializable]
	public class ORMEntityIsDeletedException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		public ORMEntityIsDeletedException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMEntityIsDeletedException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when an exception was caught during a query execution.
	/// Contains the original exception as inner exception.
	/// </summary>
	[Serializable]
	public class ORMQueryExecutionException : ORMException
	{
		#region Class Member Declarations
		private string			_queryExecuted;
		private Hashtable		_exceptionInfo;			
		private IEntityCore _involvedEntity;

		[NonSerialized]
		private IList						_parameters;
		#endregion

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="message">The message of the query</param>
		/// <param name="queryExecuted">The query string executed</param>
		/// <param name="parameters">the parameters collection of the command object executed</param>
		/// <param name="innerException">The actual exception caught</param>
		/// <param name="exceptionInfo">Exception info.</param>
		public ORMQueryExecutionException(string message, string queryExecuted, IList parameters,
				Exception innerException, Hashtable exceptionInfo):base(message, innerException)
		{
			_queryExecuted = queryExecuted;
			_parameters = parameters;
			_exceptionInfo = exceptionInfo;
		}


		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMQueryExecutionException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
			_queryExecuted = info.GetString("_queryExecuted");
			_exceptionInfo = (Hashtable)info.GetValue("_exceptionInfo", typeof(Hashtable));
			_involvedEntity = (IEntityCore)info.GetValue("_involvedEntity", typeof(IEntityCore));
		}

#if !CF
		/// <summary>
		/// Serialization override
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_queryExecuted", _queryExecuted);
			info.AddValue("_exceptionInfo", _exceptionInfo);
			info.AddValue("_involvedEntity", _involvedEntity);
			base.GetObjectData (info, context);
		}
#endif

		#region Class Property Declarations
		/// <summary>
		/// Gets the query string (formatted) executed which caused the exception.
		/// </summary>
		public string QueryExecuted
		{
			get
			{
				return _queryExecuted;
			}
		}

		/// <summary>
		/// Gets the parameters collection of the command object executed
		/// </summary>
		/// <remarks>Will be null when the class is instantiated by a deserialization process as parameters can't be serialized.</remarks>
		public IList Parameters
		{
			get
			{
				return _parameters;
			}
		}

		
		/// <summary>
		/// Gets or sets the db specific exception info. This is info obtained from the db specific exception caught and wrapped by this exception.
		/// Can be null. Hashtable has ExceptionInfoElement as key type, object as value type.
		/// </summary>
		public Hashtable DbSpecificExceptionInfo
		{
			get { return _exceptionInfo; }
			set { _exceptionInfo = value; }
		}

		/// <summary>
		/// Gets or sets the involved entity. This property is set when the exception was caused by a direct action on an entity and the entity in question
		/// is then the value of this property. Can be null.
		/// </summary>
		public IEntityCore InvolvedEntity
		{
			get { return _involvedEntity; }
			set { _involvedEntity = value; }
		}
		#endregion
	}


	/// <summary>
	/// General exception class which is thrown when a user sets a field to a value which 
	/// doesn't match the type of the field.
	/// </summary>
	[Serializable]
	public class ORMValueTypeMismatchException : ORMException
	{
		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		public ORMValueTypeMismatchException(string message):base(message)
		{
		}

		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMValueTypeMismatchException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
		}
	}


	/// <summary>
	/// General exception class which is thrown when there is a concurrency error during a save action or a delete action.
	/// A concurrency error occurs if the Save action of an entity fails, i.e. when no rows were affected by the save, or 
	/// when an entity is deleted and a delete restriction has been set and no rows were affected by the delete action.
	/// </summary>
	[Serializable]
	public class ORMConcurrencyException : ORMException
	{
		#region Class Member Declarations
		private object _entityWhichFailed;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		/// <param name="entityWhichFailed">The entity object which save action failed.</param>
		public ORMConcurrencyException(string message, object entityWhichFailed):base(message)
		{
			_entityWhichFailed = entityWhichFailed;
		}


		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMConcurrencyException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
			_entityWhichFailed = info.GetValue("_entityWhichFailed", typeof(object));
		}

#if !CF
		/// <summary>
		/// Serialization override
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_entityWhichFailed", _entityWhichFailed);
			base.GetObjectData (info, context);
		}
#endif

		#region Class Property Declarations
		/// <summary>
		/// Gets / sets entityWhichFailed
		/// </summary>
		public object EntityWhichFailed
		{
			get
			{
				return _entityWhichFailed;
			}
			set
			{
				_entityWhichFailed = value;
			}
		}
		#endregion

	}


	/// <summary>
	/// General exception class which is thrown by IEntityValidator.Validate()
	/// </summary>
	[Serializable]
	public class ORMEntityValidationException : System.ApplicationException
	{
		#region Class Member Declarations
		private object _entityValidated;
		#endregion


		/// <summary>
		/// CTor
		/// </summary>
		/// <param name="message">The message of the exception</param>
		/// <param name="entityValidated">the entity object validated. Offered as object to share exception objects between adapter/selfservicing.</param>
		public ORMEntityValidationException(string message, object entityValidated):base(message)
		{
			_entityValidated = entityValidated;
		}


#if !CF
		/// <summary>
		/// Constructor for deserialization as the base class already implements ISerializable.
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected ORMEntityValidationException(SerializationInfo info, StreamingContext context):base(info, context) 
		{
			_entityValidated = info.GetValue("_entityValidated", typeof(object));
		}

		/// <summary>
		/// Serialization override
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("_entityValidated", _entityValidated);
			base.GetObjectData (info, context);
		}
#endif

		#region Class Property Declarations
		/// <summary>
		/// Gets EntityValidated
		/// </summary>
		public object EntityValidated
		{
			get
			{
				return _entityValidated;
			}
		}

		#endregion
	}


	/// <summary>
	/// Class which retrieves information from a passed in exception which is specific to a DB type, and returns it to the caller.
	/// </summary>
	[Serializable]
	public abstract class ExceptionInfoRetrieverBase
	{
		/// <summary>
		/// Gets the exception info which is included in the passed in db specific exception. This retrieval has to be done in this class as not all .NET
		/// providers derive their exception classes from DbException.
		/// </summary>
		/// <param name="dbSpecificException">The db specific exception object.</param>
		/// <returns>A hashtable with per exception info element the value retrieved from the db specific exception </returns>
		/// <remarks>Returned hashtable has as keytype ExceptionInfoElement and as valuetype object.</remarks>
		public abstract Hashtable GetExceptionInfo(Exception dbSpecificException);
	}
}
