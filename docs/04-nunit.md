# Values  
  - [Values] - Values attribute is for providing a set of values in a parameterized test method.  
    - NUnit will create test cases for all possible combination of the provided values
  ```csharp  
  [Test]
  public void MyTest([Values(1997, 2001)] int year, [Values(false)] bool expectedResult)
  {
      /* ... */
  }
  ```
# TestCase  
  - [TestCase] - TestCase attribute has two purposes, one is for marking method as Test and another is to pass parameters to the test method
   ```csharp  
  [TestCase(1996 , true)]
  [TestCase(1997 , false)]
  public void MyTest([Values(int year, bool expectedResult)
  {
      /* ... */
  }
  
  [TestCase(1996, ExpectedResult = true)]
  [TestCase(1997, ExpectedResult = false)]
  public bool MyTest([Values(int year)
  {
     var bm = new BoolMethods();
     return bm.IsLeapYear(year);
  }
  ```
# TestCaseSource  
  - [TestCaseSource] - TestCaseSource attribute has two purposes, one is for marking method as Test and another is to pass parameters to the test method. 
  The passing itself is different from the TestCase attribute, here the parameters are not provided inline and may be defined in a different ways.
  ```csharp  
  [TestCaseSource("TestCase")]
  public void MyTest([Values(int year, bool expectedResult)
  {
      /* ... */
  }
  //this is defined in the test fixture
  static object[] TestCase =
        {
            new object[] { 1996 , true},
            new object[] { 1999 , false},
            new object[] { 2001 , false},
        };
  ```
   ```csharp  
  [TestCaseSource(typeof(BoolTestCase), "TestCase")]
  public void MyTest([Values(int year, bool expectedResult)
  {
      /* ... */
  }
  //this is in a separate class
  public class BoolTestCase
  {
      static object[] TestCase =
      {
          new object[] { 1996 , true},
          new object[] { 1999 , false},
          new object[] { 2001 , false},
      };
  }
 ```
# SetCulture
  - [SetCulture] - SetCalture attribute is for setting up the Culture while the test is executing. Can be applied to Test and TestFixture.
