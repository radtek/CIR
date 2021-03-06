using System;
using System.Reflection;
using System.Security;
using System.Web.UI;


[assembly: AssemblyTitle("LLBLGen Pro .NET 2.0 ORM Support Classes Library")]
[assembly: AssemblyDescription("Base library used by the generated classes, which forms the foundation of the LLBLGen Pro ORM framework.")]
[assembly: AssemblyConfiguration(".NET 2.0 or higher")]
[assembly: AssemblyCompany("Solutions Design")]
[assembly: AssemblyProduct("LLBLGen Pro")]
[assembly: AssemblyCopyright("(c)2002-2007 Solutions Design. All rights reserved.")]
[assembly: AssemblyTrademark("LLBLGen and LLBLGen Pro are trademarks of Solutions Design.")]
[assembly: AssemblyCulture("")]		
[assembly: CLSCompliant(true)]
[assembly: AllowPartiallyTrustedCallers()]
[assembly: TagPrefix("SD.LLBLGen.Pro.ORMSupportClasses", "llblgenpro")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:
[assembly: AssemblyVersion("2.5.0.0")]

// Assembly file version. Use this version to signal file differences after a hotfix.
[assembly: AssemblyFileVersion("2.5.08.0618")]

// In order to sign your assembly you must specify a key to use. Refer to the 
// Microsoft .NET Framework documentation for more information on assembly signing.
//
// Use the attributes below to control which key is used for signing. 
//
// Notes: 
//   (*) If no key is specified, the assembly is not signed.
//   (*) KeyName refers to a key that has been installed in the Crypto Service
//       Provider (CSP) on your machine. KeyFile refers to a file which contains
//       a key.
//   (*) If the KeyFile and the KeyName values are both specified, the 
//       following processing occurs:
//       (1) If the KeyName can be found in the CSP, that key is used.
//       (2) If the KeyName does not exist and the KeyFile does exist, the key 
//           in the KeyFile is installed into the CSP and used.
//   (*) In order to create a KeyFile, you can use the sn.exe (Strong Name) utility.
//       When specifying the KeyFile, the location of the KeyFile should be
//       relative to the project output directory which is
//       %Project Directory%\obj\<configuration>. For example, if your KeyFile is
//       located in the project directory, you would specify the AssemblyKeyFile 
//       attribute as [assembly: AssemblyKeyFile("..\\..\\mykey.snk")]
//   (*) Delay Signing is an advanced option - see the Microsoft .NET Framework
//       documentation for more information on this.
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("C:\\Myprojects\\mystrongkey.key")]
[assembly: AssemblyKeyName("")]
