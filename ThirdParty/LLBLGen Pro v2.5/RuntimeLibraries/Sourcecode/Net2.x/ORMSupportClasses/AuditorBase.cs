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
using System.Collections;
using System.Xml;

namespace SD.LLBLGen.Pro.ORMSupportClasses
{
	/// <summary>
	/// Abstract base class for auditors in the LLBLGen Pro system. Use this class to easily create auditors to perform auditing for you.
	/// </summary>
	/// <remarks>If you plan to use binary serialization in your application, be sure to read the recommendations in the manual about
	/// serialization and auditor objects.</remarks>
	[Serializable]
	public abstract class AuditorBase : IAuditor
	{
		/// <summary>
		/// Audits when an entity field's value is succesfully obtained from the passed in entity
		/// </summary>
		/// <param name="entity">The entity a field's value was obtained.</param>
		/// <param name="fieldIndex">Index of the field which value was obtained.</param>
		/// <remarks>Be careful when using this auditing routine, because a lot of calls will be made to this routine when data is for example shown in 
		/// a grid. Another thing to realize is that the audit information is stored inside the auditor which is inside an entity which might not be
		/// persisted/deleted later on. This means that if you use the audit data to produce entities which are then returned by GetAuditEntitiesToSave
		/// are never persisted if the entity this auditor is the auditor of is never persisted/deleted. In that situation, to get reliable journalling, 
		/// use an external service to log the audit data.</remarks>
		public virtual void AuditEntityFieldGet(IEntityCore entity, int fieldIndex)
		{
		}

		/// <summary>
		/// Audits when an entity field is set succesfully to a new value.
		/// </summary>
		/// <param name="entity">The entity a field was set to a new value.</param>
		/// <param name="fieldIndex">Index of the field which got a new value.</param>
		/// <param name="originalValue">The original value of the field with the index passed in before it received a new value.</param>
		public virtual void AuditEntityFieldSet(IEntityCore entity, int fieldIndex, object originalValue)
		{
		}

		/// <summary>
		/// Audits the successful dereference of related entity from the entity passed in.
		/// </summary>
		/// <param name="entity">The entity of which the related entity was dereferenced from.</param>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was dereferenced.</param>
		public virtual void AuditDereferenceOfRelatedEntity(IEntityCore entity, IEntityCore relatedEntity, string mappedFieldName)
		{
		}

		/// <summary>
		/// Audits the successful reference of related entity from the entity passed in.
		/// </summary>
		/// <param name="entity">The entity of which the related entity was dereferenced from.</param>
		/// <param name="relatedEntity">The related entity which was dereferenced from entity</param>
		/// <param name="mappedFieldName">Name of the mapped field onto the relation from entity to related entity for which the related entity was referenced.</param>
		public virtual void AuditReferenceOfRelatedEntity(IEntityCore entity, IEntityCore relatedEntity, string mappedFieldName)
		{
		}

		/// <summary>
		/// Audits the successful insert of a new entity into the database.
		/// </summary>
		/// <param name="entity">The entity saved successfully into the database.</param>
		public virtual void AuditInsertOfNewEntity(IEntityCore entity)
		{
		}

		/// <summary>
		/// Audits the successful update of an existing entity in the database
		/// </summary>
		/// <param name="entity">The entity updated successfully in the database.</param>
		public virtual void AuditUpdateOfExistingEntity(IEntityCore entity)
		{
		}

		/// <summary>
		/// Audits the succesful direct update of entities in the database.
		/// </summary>
		/// <param name="entity">The entity with the changed values which is used to produce the update query.</param>
		/// <param name="filter">The filter to filter out the entities to update. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesUpdated">The number of entities updated.</param>
		public virtual void AuditDirectUpdateOfEntities(IEntityCore entity, IPredicate filter, IRelationCollection relations, int numberOfEntitiesUpdated)
		{
		}

		/// <summary>
		/// Audits the successful delete of an entity from the database
		/// </summary>
		/// <param name="entity">The entity which was deleted.</param>
		/// <remarks>As the entity passed in was deleted succesfully, reading values from the passed in entity is only possible in this routine. After this call, the
		/// state of the entity will be reset to Deleted again and reading the fields will result in an exception. It's also recommended not to reference
		/// the passed in entity in any audit entity you might want to persist as the entity doesn't exist anymore in the database.</remarks>
		public virtual void AuditDeleteOfEntity(IEntityCore entity)
		{
		}

		/// <summary>
		/// Audits the successful load of an entity from the database
		/// </summary>
		/// <param name="entity">The entity which was loaded. All data of the entity which was loaded is inside the entity.</param>
		/// <remarks>Be careful when using this auditing routine, because the audit information is stored inside the auditor which is inside an entity 
		/// which might not be persisted/deleted later on. This means that if you use the audit data to produce entities which are then 
		/// returned by GetAuditEntitiesToSave are never persisted if the entity this auditor is the auditor of is never persisted/deleted. 
		/// In that situation, to get reliable journalling, use an external service to log the audit data.</remarks>
		public virtual void AuditLoadOfEntity(IEntityCore entity)
		{
		}

		/// <summary>
		/// Audits the successful direct delete of entities in the database
		/// </summary>
		/// <param name="typeOfEntity">The type of entity of which entities were deleted.</param>
		/// <param name="filter">The filter to filter out the entities to delete. Can be null and can be an IPredicateExpression.</param>
		/// <param name="relations">The relations to use with the filter. Can be null.</param>
		/// <param name="numberOfEntitiesDeleted">The number of entities deleted.</param>
		public virtual void AuditDirectDeleteOfEntities(Type typeOfEntity, IPredicate filter, IRelationCollection relations, int numberOfEntitiesDeleted)
		{
		}

		/// <summary>
		/// Gets the audit entities to save. Audit entities contain the audit information stored inside this auditor.
		/// </summary>
		/// <returns>
		/// The list of audit entities to save, or null if there are no audit entities to save
		/// </returns>
		/// <remarks>Do not remove the audit entities and audit information from this auditor when this method is called, as the transaction in which
		/// the save takes place can fail and retried which will result in another call to this method</remarks>
		public virtual IList GetAuditEntitiesToSave()
		{
			return null;
		}

		/// <summary>
		/// The transaction with which the audit entities requested from GetAuditEntitiesToSave were saved.
		/// Use this method to clear any audit data in this auditor as all audit information is persisted successfully.
		/// </summary>
		public virtual void TransactionCommitted()
		{
		}


		/// <summary>
		/// Method which returns true if this auditor expects to have audit entities to persist and therefore needs a transaction.
		/// This method is called in the situation when there's no transaction going on though one should be started right before the single-statement action
		/// in the case if the auditor has entities to save afterwards. It's recommended to return true if the auditor might have audit entities
		/// to persist after an entity save/delete/direct update/direct delete of entities. Default: true
		/// </summary>
		/// <param name="actionToStart">The single statement action which is about to be started.</param>
		/// <returns>
		/// true if a transaction should be started prior to the action to perform (entity save/delete/direct update/direct delete of entities)
		/// false otherwise.
		/// </returns>
		/// <remarks>If false is returned and GetAuditEntitiesToSave returns 1 or more entities, a new transaction is started to save these audit entities
		/// which means that this transaction isn't re-tryable if this transaction might fail.</remarks>
		public virtual bool RequiresTransactionForAuditEntities(SingleStatementQueryAction actionToStart)
		{
			return true;
		}


		/// <summary>
		/// Method to serialze audit data to XML. Use the aspects passed in to determine various aspects of the XML format.
		/// If the audit data consists of entity instances, be sure to pass the passed in processedObjectIDs object to the WriteXml routine of IEntity2, so 
		/// use the overload of IEntity2.WriteXml() which accepts a reader and the processedObjectIDs. Though it's recommended not to serialize entity objects
		/// in audit data, keep audit data as clean as possible from entity references.
		/// The start element 'Auditor' has already been written, the end element /Auditor will be written for you after this routine.
		/// </summary>
		/// <param name="writer">The writer.</param>
		/// <param name="aspects">The aspects.</param>
		/// <param name="processedObjectIDs">The objectIDs of entities already serialized.</param>
		/// <remarks>Adapter specific.</remarks>
		public virtual void WriteXml(XmlWriter writer, XmlFormatAspect aspects, Dictionary<Guid, IEntity2> processedObjectIDs)
		{
			// nothing
		}


		/// <summary>
		/// Reads the auditor data XML.
		/// </summary>
		/// <param name="auditorNode">The auditor node, which is the node of the Auditor element. The elements serialized by WriteXml are the children of
		/// this node.</param>
		/// <remarks>Adapter specific. Used in Verbose/Compact scenarios. For Compact25 format, use the XmlReader consuming overload.</remarks>
		public virtual void ReadXml(XmlNode auditorNode)
		{
			// nothing
		}


		/// <summary>
		/// Reads the auditor data XML.
		/// </summary>
		/// <param name="reader">The xml reader to read the xml from. The reader is positioned on the Auditor element. 
		/// The elements serialized by WriteXml are the children of this element. Read all xml till the reader is positioned on the end element of the Auditor
		/// element</param>
		/// <remarks>Adapter specific, Compact25 specific. For Verbose/Compact scenario's use the XmlNode consuming overload</remarks>
		public virtual void ReadXml(XmlReader reader)
		{
			// nothing
		}


		/// <summary>
		/// Gets the EntityType value as integer for the entity type passed in
		/// </summary>
		/// <param name="typeOfEntity">The type of entity.</param>
		/// <returns>the EntityType value as integer for the entity type passed in</returns>
		protected int GetEntityTypeValueForType(Type typeOfEntity)
		{
			object instance = Activator.CreateInstance(typeOfEntity);
			IEntityCore entity = instance as IEntityCore;
			if(entity == null)
			{
				return 0;
			}
			return entity.LLBLGenProEntityTypeValue;
		}


		#region Class Property Declarations
		/// <summary>
		/// Gets if the auditor object has data which should be Xml serialized. If this property returns false, no serialization (and thus no deserialization) 
		/// will take place of the data to XML.
		/// </summary>
		/// <remarks>Used in Adapter</remarks>
		public virtual bool HasDataToXmlSerialize 
		{
			get { return false; }
		}
		#endregion
	}
}
