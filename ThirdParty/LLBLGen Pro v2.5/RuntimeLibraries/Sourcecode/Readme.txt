LLBLGen Pro - Runtime Libraries 2.5 Sourcecode
========================================================================
Release date: 19-jun-2008

The ORM Support classes library sourcecode is released under the BSD2 license. Please see the 
enclosed license.txt in the ORMSupportClasses folder, or any of the sourcefiles. 

The SqlServer Dynamic Query Engine is released under the BSD2 license. 
The SqlServerCE Compact Framework Dynamic Query Engine is released under the BSD2 license. 
The Oracle Dynamic Query Engine is released under the BSD2 license. 
The Oracle 10g Dynamic Query Engine is released under the BSD2 license.
The Firebird Dynamic Query Engine is released under the BSD2 license
The Access Dynamic Query Engine is released under the BSD2 license.
The DB2 Dynamic Query Engine is released under the BSD2 license.
The Oracle MS Dynamic Query Engine is released under the BSD2 license.
The MySql Corelab Dynamic Query Engine is released under the BSD2 license.
The PostgreSql Dynamic Query Engine is released under the BSD2 license.
The Sybase iAnywhere (ASA) Dynamic Query Engine is released under the BSD2 license.
The Sybase Adaptive Server Enterprise (ASE) Dynamic Query Engine is released under the BSD2 license.

To build the libraries, use the predefined .cmd files. They require a vsvars3210.bat file, which is simply the
copy of vsvars32.bat but for the .NET 1.0 SDK. For .NET 2.0 builds, a vsvars3220.bat file has to be available.

The source code references a strong key, which is not shipped with the code. You should remove these 
references in the AssemblyInfo.cs classes.

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


