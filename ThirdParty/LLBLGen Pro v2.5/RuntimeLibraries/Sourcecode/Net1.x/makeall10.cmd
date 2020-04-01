@ECHO OFF
call vsvars3210.bat
pushd ORMSupportClasses
call make10.cmd
popd
pushd SqlServerDQE
call make10.cmd
popd
pushd OracleDQE
call make10.cmd
popd
pushd AccessDQE
call make10.cmd
popd
pushd DB2DQE
call make10.cmd
popd
pushd MySqlDQE
call make10.cmd
popd
copy OracleDQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.Oracle.NET10.dll DotNet10
copy OracleDQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.Oracle10g.NET10.dll DotNet10
copy SqlServerDQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.SqlServer.NET10.dll DotNet10
copy AccessDQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.Access.NET10.dll DotNet10
copy MySqlDQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.MySql.NET10.dll DotNet10
copy MySqlDQE\DotNet1.0\bin\v355\SD.LLBLGen.Pro.DQE.MySql.NET10.dll DotNet10\MySqlDirectv355
copy DB2DQE\DotNet1.0\bin\SD.LLBLGen.Pro.DQE.DB2.NET10.dll DotNet10
copy ORMSupportClasses\DotNet1.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET10.dll DotNet10