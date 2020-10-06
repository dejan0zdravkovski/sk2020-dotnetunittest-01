# SetUp
  - [SetUp] : This code will be executed before running each test within the class that has [TestFixture] attribute in order to provide a common set of functions.  

# TearDown  
  - [TearDown] : This code will be executed after executing each test within the class that has [TestFixture] attribute in order to provide a common set of functions.  

# OneTimeSetUp
  - [OneTimeSetUp] : This code will be executed only once before running the tests in a fixture. If we have n tests this will be called only once.  

# OneTimeTearDown
  - [OneTimeTearDown] : This code will be executed only once after executing the tests in a fixture. If we have n tests this will be called only once.  

# SetUpFixture
  - [SetUpFixture] : This is the attribute that marks a class that contains the one-time setup or teardown methods for all the test fixtures under a given namespace.  
    - [OneTimeSetUp] : The OneTimeSetUp method in a SetUpFixture is executed once before any of the fixtures contained in its namespace.  
    - [OneTimeTearDown] : The OneTimeTearDown method is executed once after all the fixtures have completed execution.

# Author
  - [Author] : Author attribute will add information about the author of the tests. Can be applied to Test and TestFixture.

# Description
  - [Description] : Description attribute is used to apply descriptive text if needed. Can be applied to Test and TestFixture. 

# Category
  - [Category] - Category attribute is used to categorize. Can be applied to Test and TestFixture.  

# Order
  - [Order] - The Order attribute may be placed on a test method or fixture to specify the order in which tests are run within the fixture. 

# Retry
  - [Retry] - Retry attribute is used on a test method to specify that it should be rerun if it fails, up to a maximum number of times.

# MaxTime
  - [MaxTime] - MaxTime attribute is used on test methods to specify a maximum time in milliseconds for a test case. If the test case takes longer than the specified time to complete, it is reported as a failure.
	
# Timeout
  - [Timeout] - Timeout attribute is used to specify a timeout value in milliseconds for a test case. If the test case runs longer than the time specified it is immediately cancelled and reported as a failure, with a message indicating that the timeout was exceeded.

# Repeat
  - [Repeat] - Repeat attribute is used on a test method to specify that it should be executed multiple times.  
  
