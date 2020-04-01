@ECHO OFF
call vsvars32.bat
pushd ORMSupportClasses
call make11.cmd
call makeCF11.cmd
popd
pushd SqlServerDQE
call make11.cmd
popd
pushd OracleDQE
call make11.cmd
popd
pushd FirebirdDQE
call make11.cmd
popd
pushd AccessDQE
call make11.cmd
popd
pushd DB2DQE
call make11.cmd
popd
pushd MySqlDQE
call make11.cmd
popd
pushd PostgreSqlDQE
call make11.cmd
popd
pushd SqlServerCEDQE
call makeCF11.cmd
popd
pushd SybaseAseDQE
call make11.cmd
popd
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Oracle.NET11.dll DotNet11
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Oracle10g.NET11.dll DotNet11
copy OracleDQE\DotNet1.1\bin\v10104\SD.LLBLGen.Pro.DQE.Oracle10g.NET11.dll DotNet11\Oracle10gv10104
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.OracleMS.NET11.dll DotNet11
copy SqlServerDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SqlServer.NET11.dll DotNet11
copy SybaseAseDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SybaseAse.NET11.dll DotNet11
copy FirebirdDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Firebird.NET11.dll DotNet11
copy AccessDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Access.NET11.dll DotNet11
copy MySqlDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.MySql.NET11.dll DotNet11
copy MySqlDQE\DotNet1.1\bin\v355\SD.LLBLGen.Pro.DQE.MySql.NET11.dll DotNet11\MySqlDirectv355
copy DB2DQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.DB2.NET11.dll DotNet11
copy DB2DQE\DotNet1.1\bin\v8121\SD.LLBLGen.Pro.DQE.DB2.NET11.dll DotNet11\IBMDB2v8121
copy PostgreSqlDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.PostgreSql.NET11.dll DotNet11
copy ORMSupportClasses\DotNet1.1\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET11.dll DotNet11
copy ORMSupportClasses\DotNet1.1\bin\SD.LLBLGen.Pro.ORMSupportClasses.CF11.dll DotNet11
copy SqlServerCEDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.CF11.dll DotNet11
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Oracle.NET11.xml DotNet11
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Oracle10g.NET11.xml DotNet11
copy OracleDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.OracleMS.NET11.xml DotNet11
copy SqlServerDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SqlServer.NET11.xml DotNet11
copy FirebirdDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Firebird.NET11.xml DotNet11
copy AccessDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.Access.NET11.xml DotNet11
copy MySqlDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.MySql.NET11.xml DotNet11
copy DB2DQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.DB2.NET11.xml DotNet11
copy ORMSupportClasses\DotNet1.1\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET11.xml DotNet11
copy PostgreSqlDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.PostgreSql.NET11.xml DotNet11
copy ORMSupportClasses\DotNet1.1\bin\SD.LLBLGen.Pro.ORMSupportClasses.CF11.xml DotNet11
copy SqlServerCEDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.CF11.xml DotNet11
copy SybaseAseDQE\DotNet1.1\bin\SD.LLBLGen.Pro.DQE.SybaseAse.NET11.xml DotNet11
