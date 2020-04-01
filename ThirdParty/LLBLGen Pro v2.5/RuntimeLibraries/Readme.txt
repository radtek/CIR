LLBLGen Pro - Runtime Libraries 2.5
========================================================================
Release date: 19-jun-2008

Contained runtime libraries:
- ORM Support classes
- SqlServer Dynamic Query Engine (DQE)
- SqlServerCE Desktop Dynamic Query Engine (DQE)
- Oracle Dynamic Query Engine (DQE)
- Oracle 10g Dynamic Query Engine (DQE) build against v10.2 and v10.1 of ODP.NET 10g
- Firebird Dynamic Query Engine (DQE)
- Access Dynamic Query Engine (DQE)
- DB2 Dynamic Query Engine (DQE) build against v9.0.0.2 and v8.1.2.1 of IBM DB2 client
- Oracle MS Dynamic Query Engine (DQE)
- PostgreSql Dynamic Query Engine (DQE)
- MySql Corelab Dynamic Query Engine (DQE) build against v4 and v355 of MySqlDirect
- Sybase iAnywhere (Sybase ASA) Dynamic Query Engine (DQE)
- Sybase Adaptive Server Enterprise (Sybase ASE) Dynamic Query Engine (DQE)
- SqlServerCE Compact Framework Dynamic Query Engine (DQE)
- ORM Support classes for CF.NET 

Installation:
-------------
Copy the DotNet* folders contained in this archive and their contents into the RuntimeLibraries folder which is a 
subdirectory of the LLBLGen Pro root folder, overwriting existing files.

IMPORTANT: MySQL users who use v3.x of the MySqlDirect provider first have to upgrade to
v3.55 of the MySqlDirect provider from Corelab. After that, reference the DQE DLL from the 
MySqlDirectv355 folder inside the DotNETxy folder of choice in this archive. The MySql DQE dlls in the
DotNet* folders are compiled against v4 of the MySqlDirect provider.

IMPORTANT: Oracle ODP.NET 10g users who use v10.1.0.4 of the ODP.NET 10g provider either have to
upgrade to v10.2 of the Oracle 10g provider, or have to compile their generated code with the
Oracle 10g DQE found in the Oracle10gv10104 folder inside the DotNETxy folder of choice in this
archive. The Oracle 10g ODP.NET DQEs in the DotNet* folders are compiled against v10.2 of ODP.NET

IMPORTANT: IBM DB2 users who use v8.1.2.1 of the IBM DB2 provider either have to
upgrade to v9.0.0.2  of the IBM DB2 provider, or have to compile their generated code with the
IBM DB2 DQE found in the IBMDB2v8121 folder inside the DotNETxy folder of choice in this
archive. The IBM DB2 DQEs in the DotNet* folders are compiled against v9.0.0.2 of the IBM DB2 client.

IMPORTANT: VS.NET 2008 users should use the DebugVisualizers dll in the DebugVisualizers\VS.NET 2008 folder. 

A debug build (optimized) with debug symbols of the ORMSupportClasses dll is located in the
ORMSupportClassesDebugBuild folder.

Changelog: 
-----------
18-jun-2008: (Runtime Libraries, 2.5.06182008):
* FIX : .NET 2.0: FieldPersistenceInfo, an object inside SelfServicing's EntityField, didn't serialize a set typeconverter (as type converters aren't serializable), however in webbased scenario's, a predicate could be serialized into the viewstate, which resulted in a loss of the type converter when the page was deserialized, causing problems when the filter was used. 

04-jun-2008: (Runtime Libraries, 2.5.06042008):
* FIX : When an entity field of a non-new entity was set to the same value twice, the second time the entity still raised changed events as it set the field as if the value was different. 

02-jun-2008: (Runtime Libraries, 2.5.06022008):
* FIX : DbValue was set to the same value as CurrentValue in EntityField2 instances after a deserialization from XML in Compact25 formats (webservices/wcf), even if DbValue was actually null. It's now set to null if required (IsNull ==true)

30-mei-2008: (Runtime Libraries, 2.5.05302008):
* FIX : Workaround added to Sybase ASE dqe to avoid bug in parameter passing in the Sybase ASE ADO.NET provider where precision/scale can't be set for decimal / numeric fields. 

15-mei-2008: (Runtime Libraries, 2.5.05152008):
* FIX : EntityField(2).CompareTo() could crash if the value was null.

02-mei-2008: (Runtime Libraries, 2.5.05022008):
* FIX : Calling DataAccessAdapter.ExecuteScalarQuery with a properly constructed RetrievalQuery didn't wire the connection to the retrieval query. It assumed it was already set in the query object. 

09-apr-2008: (Runtime Libraries, 2.5.04092008):
* FIX : The XML document descriptions on IEntityCollection(2).DefaultView were wrong: the instance is always the same instance

08-apr-2008: (Runtime Libraries, 2.5.04082008):
* FIX : In a rare case it could be that creating a dependencyinjectionscope instance could run into a null reference exception inside the DependencyInjectionInfoProvider class

03-apr-2008: (Runtime Libraries, 2.5.04032008):
* FIX : Changed doc comment on LivePersistence property of datasourcecontrols as it wasn't mentioning that the property controlled fetches as well.

03-apr-2008: (Runtime Libraries, 2.5.04032008):
* FIX : Oracle DQE for MS didn't obtain the 'Code' property of the OracleException when filling the DbSpecificExceptionInfo object

28-mrt-2008: (Runtime Libraries, 2.5.03282008):
* FIX : Passing in null to DataAccessAdapter.DeleteEntity for the restriction to use didn't obtain the right predicate for concurrency checks.

28-mrt-2008: (Runtime Libraries, 2.5.03282008):
* FIX : .NET 2.0: MySql DQE didn't wrap field names in ` characters so illegal characters in the fieldnames could cause queries to fail.

19-mrt-2008: (Runtime Libraries, 2.5.03192008):
* FIX : When a field was excluded in an entity and it had a lower index than a field with a typeconverter and the entity wasn't in an inheritance hierarchy, the typeconverter was applied to the wrong field.


