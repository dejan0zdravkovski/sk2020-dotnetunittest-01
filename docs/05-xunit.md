# XUnit  
XUnit is a free, open source, community-focused unit testing tool for the .NET Framework.

# How to create NUnit testing project  
  - Visual Studio 2019 already has template for XUnit. Select the "XUnit Test Project (.NET Core)"
  - Create a new Class Library (.NET Core) and add these nuget packages:  
     - Microsoft.NET.Test.Sdk (The MSbuild targets and properties for building .NET test projects.) 
     - xunit (This package includes the xunit framework assembly, which is referenced by your tests.)
     - xunit.runner.visualstudio (running the tests within the Visual Studio)
     ```xml
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="16.5.0" />
    <PackageReference Include="xunit" Version="2.4.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.0" />
     ```
     
 # Write first test using Fact  
  - [Fact] : Fact attribute is for marking the method as a test.  
  ```csharp
    public class InitTests
    {
        [Fact]
        public void Test1()
        {
        }
    }
  ```
  
 # Mocking
  - The system under test or the method that is about to be tested may have external dependency. In order to overcome this issue we need to mock (simulate that real behavior) that dependency.  
  - Mocking Frameworks
    - Moq  
    - Rhino Mocks  
    - FakaItEasy  
    - NSubstutute  
    
# Moq
  - Mock interface
  ```csharp
  var mockRepository = new Mock<IRepository>();
  ```
  - Mock interface and use "Setup" to setup up the call and setup the return value
  ```csharp
  var mockRepository = new Mock<IRepository>();
  mockRepository.Setup(x => x.GetHotelName(1)).Returns("Hotel Royal Skopje");
  ```
    
 # Running/Debuging XUnit tests
  - Running
    - Visual Studio  
    - ReSharper  
    - CMD  
  - Debuging  
  
 # Exceptions
  - Use assertion as Assert.Throws
  ```csharp
   Action result = () => searchService.GetHotels();
   result.Should().Throw<Exception>();
  ```
