mkdir DotNET2.0\bin\x64
nmake /nologo /f makefile_20 clean
nmake /nologo /f makefile_20 x64

copy /y DotNet2.0\bin\x64\SD.LLBLGen.Pro.ORMSupportClasses.NET20.dll ..\SqlServerDQE\DotNET2.0\bin\x64
