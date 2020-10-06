# NUnit  
NUnit is an open source test framework designed for writing and running tests in Microsoft .NET programming languages. This framework is very easy to work with and has user friendly attributes for working. NUnit is an attribute-based testing framework. Which means everything is annotated using attributes for the testing framework to find out the test and execute them. Out of all the attributes available, the most common and must-have for a test to execute are TestFixure and Test.

# How to create NUnit testing project  
  - Visual Studio 2019 already has template for NUnit. Select the "NUnit Test Project (.NET Core)"
  - Create a new Class Library (.NET Core) and add these nuget packages:  
     - Microsoft.NET.Test.Sdk (The MSbuild targets and properties for building .NET test projects.) 
     - NUnit (This package includes the NUnit 3 framework assembly, which is referenced by your tests.)
     - NUnit3TestAdapter (The NUnit3TestAdapter extension works with the Visual Studio Unit Test window to allow integrated test execution under Visual Studio 2012 and newer.)
      
  
# Attributes
In order to identify tests NUnit use attributes. The attributes are within the NUnit.Framework namespace. Each source file that contains tests must include a using statement for that namespace and the project must reference the framework assembly, nunit.framework.dll.

# Assertions
NUnit Assert class is used to determine whether a particular test method gives expected result or not.   
  - Assert.True(bool condition) and Assert.IsTrue(bool condition)  
  - Assert.Falze(bool condition) and Assert.IsFalse(bool condition)  
  - Assert.Null(object anObject) and Assert.IsNull(object anObject)  
  - Assert.NotNull(object anObject) and Assert.IsNotNull(object anObject)  
  - Assert.IsEmpty(string aString) and Assert.IsEmpty(IEnumerable collection)  
  - Assert.AreEqual(double expected, double actual) + Assert.AreNotEqual(object expected, object actual)  
  - Assert.Contains(object anObject, ICollection collection)  
  - Assert.Greater(int arg1, int arg2)  and GreaterOrEqual, Less, LessOrEqual  
  - Assert.IsInstanceOf(Type expected, object actual) and Assert.IsInstanceOf<T>(object actual)  
  - Assert.Throws and Assert.Catch  
   

# Write first test using TestFixture + Test  
  - [TestFixture] : TestFixture attribute is a class level attribute and it indicates that this class contains NUnit Test Methods.  
  - [Test] : Test attribute is for marking the method as a test.  

# Running/Debuging NUnit tests
  - Running
    - Visual Studio  
    - ReSharper  
    - CMD  
  - Debuging  

# Ignore
  - [Ignore] - Ignore attribute is used to indicate that a test should not be executed. Can be applied to Test and TestFixture.
    - Unitl parametar will ignore the Test or TestFixture for a specific period of time and after the period the Test will run.

# Exceptions 
  - Use assertion as Assert.Throws and Assert.Catch 
