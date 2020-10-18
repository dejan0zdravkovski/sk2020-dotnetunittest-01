# SetUp
  - [SetUp] : This code will be executed before running each test within the class that has [TestFixture] attribute in order to provide a common set of functions.  

# TearDown  
  - [TearDown] : This code will be executed after executing each test within the class that has [TestFixture] attribute in order to provide a common set of functions.  

# OneTimeSetUp
  - [OneTimeSetUp] : This code will be executed only once before running the tests in a fixture. If we have n tests this will be called only once.  

# OneTimeTearDown
  - [OneTimeTearDown] : This code will be executed only once after executing the tests in a fixture. If we have n tests this will be called only once.  
  
# SetUp+TearDown+OneTimeSetUp+OneTimeTearDown  
```csharp
    [TestFixture]
    public class SetupTesingTest
    {
        [OneTimeSetUp]
        public void Init() { }

        [OneTimeTearDown]
        public void CleanUp() { }

        [SetUp]
        public void Setup() { }

        [TearDown]
        public void TearDown() { }

        [Test]
        public void Test1()
        {
            Assert.IsTrue(true);
        }    
    }
```

# SetUpFixture
  - [SetUpFixture] : This is the attribute that marks a class that contains the one-time setup or teardown methods for all the test fixtures under a given namespace.  
    - [OneTimeSetUp] : The OneTimeSetUp method in a SetUpFixture is executed once before any of the fixtures contained in its namespace.  
    - [OneTimeTearDown] : The OneTimeTearDown method is executed once after all the fixtures have completed execution.
  ```csharp
    [SetUpFixture]
    public class MySetupTestFixture
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTest() { }

        [OneTimeTearDown]
	    public void RunAfterAnyTest() { }
    }
  ```

# Author
  - [Author] : Author attribute will add information about the author of the tests. Can be applied to Test and TestFixture.
  ```csharp
  [Test]
  [Author("Add Name")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  
  [Test]
  [Author("Add Name", "Add email")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  
  [Test(Author = "Add Name")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  
  [TestFixture(Author = "Add Name")]
  
  ```

# Description
  - [Description] : Description attribute is used to apply descriptive text if needed. Can be applied to Test and TestFixture. 
   ```csharp
  [Test]
  [Description("Add description")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
    
  [Test(Description = "Add description")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  
  [TestFixture(Description = "Add description")]
  
  ```

# Category
  - [Category] - Category attribute is used to categorize. Can be applied to Test and TestFixture.  
   ```csharp
  [Test]
  [Category("Add category")]
  public void Test()
  {
      Assert.IsTrue(true);
  }
   
  [TestFixture(Category ="Add category")]
  ```

# Order
  - [Order] - The Order attribute may be placed on a test method or fixture to specify the order in which tests are run within the fixture. 
   ```csharp
  [Test]
  [Order(x)]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  
  [TestFixture]
  [Order(x)]
  ```

# Retry
  - [Retry] - Retry attribute is used on a test method to specify that it should be rerun if it fails, up to a maximum number of times.  
  ```csharp
  [Test]
  [Retry(x)]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  ```

# MaxTime
  - [MaxTime] - MaxTime attribute is used on test methods to specify a maximum time in milliseconds for a test case. If the test case takes longer than the specified time to complete, it is reported as a failure.
  ```csharp
  [Test]
  [MaxTime(x)]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  ```
	
# Timeout
  - [Timeout] - Timeout attribute is used to specify a timeout value in milliseconds for a test case. If the test case runs longer than the time specified it is immediately cancelled and reported as a failure, with a message indicating that the timeout was exceeded.
   ```csharp
  [Test]
  [Timeout(x)]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  ```

# Repeat
  - [Repeat] - Repeat attribute is used on a test method to specify that it should be executed multiple times.  
  ```csharp
  [Test]
  [Repeat(x)]
  public void Test()
  {
      Assert.IsTrue(true);
  }
  ```
