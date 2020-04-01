mkdir DotNET2.0\bin
mkdir DotNET2.0\bin\debug

nmake /nologo /f makefile_20 clean
nmake /nologo /f makefile_20
nmake /nologo /f makefile_20 debug

copy /y DotNet2.0\bin\SD.LLBLGen.Pro.ORMSupportClasses.NET20.dll ..\SqlServerDQE\DotNET2.0\bin
