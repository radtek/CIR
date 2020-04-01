@ECHO OFF
call vsvars3220.bat
pushd ORMSupportClasses
call make20.cmd
call makeCF20.cmd
popd
pushd SqlServerDQE
call make20.cmd
popd
pushd OracleDQE
call make20.cmd
popd
pushd MySqlDQE
call make20.cmd
popd
pushd FirebirdDQE
call make20.cmd
popd
pushd AccessDQE
call make20.cmd
popd
pushd DB2DQE
call make20.cmd
popd
pushd PostgreSqlDQE
call make20.cmd
popd
pushd SqlServerCEDQE
call makeCF20.cmd
popd
pushd SybaseAseDQE
call make20.cmd
popd
pushd SybaseAsaDQE
call make20.cmd
popd

pushd DebugVisualizers
msbuild DebugVisualizers.csproj /t:rebuild /p:Configuration=Release
msbuild DebugVisualizers2008.csproj /t:rebuild /p:Configuration=Release
popd

copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Oracle.NET20.dll DotNET20
copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Oracle10g.NET20.dll DotNET20
copy OracleDQE\DotNET2.0\bin\v10104\SD.LLBLGen.Pro.DQE.Oracle10g.NET20.dll DotNET20\Oracle10gv10104
copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.OracleMS.NET20.dll DotNET20
copy SqlServerDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SqlServer.NET20.dll DotNET20
copy MySqlDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.MySql.NET20.dll DotNET20
copy MySqlDQE\DotNET2.0\bin\v355\SD.LLBLGen.Pro.DQE.MySql.NET20.dll DotNET20\MySqlDirectv355
copy FirebirdDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Firebird.NET20.dll DotNET20
copy AccessDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Access.NET20.dll DotNET20
copy DB2DQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.DB2.NET20.dll DotNET20
copy DB2DQE\DotNET2.0\bin\v8121\SD.LLBLGen.Pro.DQE.DB2.NET20.dll DotNET20\IBMDB2v8121
copy PostgreSqlDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.PostgreSql.NET20.dll DotNET20
copy ORMSupportClasses\DotNET2.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET20.dll DotNET20
copy ORMSupportClasses\DotNET2.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.CF20.dll DotNET20
copy ORMSupportClasses\DotNET2.0\bin\Debug\SD.LLBLGen.Pro.ORMSupportClasses.NET20.*  DotNET20\ORMSupportClassesDebugBuild
copy SqlServerCEDQE\DotNet2.0\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.CF20.dll DotNet20
copy SqlServerCEDQE\DotNet2.0\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.NET20.dll DotNet20
copy SybaseAseDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SybaseAse.NET20.dll DotNET20
copy SybaseAsaDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SybaseAsa.NET20.dll DotNET20
copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Oracle.NET20.xml DotNET20
copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Oracle10g.NET20.xml DotNET20
copy OracleDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.OracleMS.NET20.xml DotNET20
copy SqlServerDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SqlServer.NET20.xml DotNET20
copy MySqlDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.MySql.NET20.xml DotNET20
copy FirebirdDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Firebird.NET20.xml DotNET20
copy AccessDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.Access.NET20.xml DotNET20
copy DB2DQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.DB2.NET20.xml DotNET20
copy PostgreSqlDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.PostgreSql.NET20.xml DotNET20
copy ORMSupportClasses\DotNET2.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET20.xml DotNET20
copy ORMSupportClasses\DotNET2.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.CF20.xml DotNET20
copy SqlServerCEDQE\DotNet2.0\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.CF20.xml DotNet20
copy SqlServerCEDQE\DotNet2.0\bin\SD.LLBLGen.Pro.DQE.SqlServerCE.NET20.xml DotNet20
copy SybaseAseDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SybaseAse.NET20.xml DotNET20
copy SybaseAsaDQE\DotNET2.0\bin\SD.LLBLGen.Pro.DQE.SybaseAsa.NET20.xml DotNET20
copy DebugVisualizers\bin\Release\SD.LLBLGen.Pro.DebugVisualizers.dll DotNet20\DebugVisualizers
copy DebugVisualizers\bin\Release\vs.net2008\SD.LLBLGen.Pro.DebugVisualizers.dll "DotNet20\DebugVisualizers\VS.NET 2008"