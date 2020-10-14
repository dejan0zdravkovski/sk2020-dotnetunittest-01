# XUnit  
XUnit is a free, open source, community-focused unit testing tool for the .NET Framework.

# How to create NUnit testing project  
  - Visual Studio 2019 already has template for XUnit. Select the "XUnit Test Project (.NET Core)"
  - Create a new Class Library (.NET Core) and add these nuget packages:  
     - Microsoft.NET.Test.Sdk (The MSbuild targets and properties for building .NET test projects.) 
     - xunit (This package includes the xunit framework assembly, which is referenced by your tests.)
     - xunit.runner.visualstudio (running the tests within the Visual Studio)
     
 # Write first test using Fact  
  - [Fact] : Fact attribute is for marking the method as a test.  
  
 # Mocking
  - The system under test or the method that is about to be tested may have external dependency. In order to overcome this issue we need to mock (simulate that real behavior) that dependency.  
  - Mocking Frameworks
    - Moq  
    - Rhino Mocks  
    - FakaItEasy  
    - NSubstutute  
    
 # Running/Debuging XUnit tests
  - Running
    - Visual Studio  
    - ReSharper  
    - CMD  
  - Debuging  
  
 # Exceptions
  - Use assertion as Assert.Throws
 
 # Sharing data between tests
  - Constructor and Dispose : in order to have a code that will be run for every test use the constructor and dispose. Constructor and dispose will be called for every test
  because XUnit creates a new instance of the test class for every test.
  - Class Fixture : in order to share single object instance (where you will have a setup/mocked data) that will be used for all test in a test class use Class Fixture
    - Create new class that will be the fixture class and implement IDisposable if needed for cleanup
    ```csharp  
    public class HotelFixtureData
    {
        public Hotel MockedHotel { get; private set; }

        public HotelFixtureData()
        {
            MockedHotel = SetMockedHotel();
            MockedExpectedHotel = SetMockedExpectedHotel();
            HotelList = SetHotelList();
            MockedHotelCategory = SetHotelCategory();
        }

        private Hotel SetMockedHotel()
        {
            var hotel = new Hotel
            {
                Id = 3,
                Code = "03",
                Name = "Diplomat Hotel",
                Description = "Description",
                City = "Ohrid",
                Address = "BB",
                Email = "test@in.com",
                CountryId = 1,
                HotelCategoryId = 1,
                Web = "http://diplomat.mk"
            };

            return hotel;
        }
    }
    ```
    - Add IClassFixture<> to the test class and in order to access the data add in the constructor
    ```csharp  
    public class SearchServiceTest : IClassFixture<HotelFixtureData>
    {
        HotelFixtureData _hotelFixtureData;

        public SearchServiceTest(HotelFixtureData hotelFixtureData)
        {
            _hotelFixtureData = hotelFixtureData;
        }
    }
    ```
  - Collection Fixture : in order to share a Class Fixture among couple of test classs then use Collection Fixture
    - Create new class that will be the fixture class and implement IDisposable if needed for cleanup
    ```csharp  
    public class HotelFixtureData
    {
        public Hotel MockedHotel { get; private set; }

        public HotelFixtureData()
        {
            MockedHotel = SetMockedHotel();
            MockedExpectedHotel = SetMockedExpectedHotel();
            HotelList = SetHotelList();
            MockedHotelCategory = SetHotelCategory();
        }

        private Hotel SetMockedHotel()
        {
            var hotel = new Hotel
            {
                Id = 3,
                Code = "03",
                Name = "Diplomat Hotel",
                Description = "Description",
                City = "Ohrid",
                Address = "BB",
                Email = "test@in.com",
                CountryId = 1,
                HotelCategoryId = 1,
                Web = "http://diplomat.mk"
            };

            return hotel;
        }
    }
    ```
    - Create collection definition class and decoratr it with the [CollectionDefinition] attribute, add unique name that will identify the test collection. Add ICollectionFixture<> to the collection definition class.
     ```csharp  
    [CollectionDefinition("HotelCollection")]
    public class HotelCollection : ICollectionFixture<HotelFixtureData>
    {
      // This class has no code, and is never created. Its purpose is simply
      // to be the place to apply [CollectionDefinition] and all the
      // ICollectionFixture<> interfaces.
    }
     ```  
    -Add the [Collection] attribute to all the test classes and in order to access the data add in the constructor
    ```csharp  
    [Collection("HotelCollection")]
    public class AvailabilityServiceTest
    {
        HotelFixtureData _hotelFixtureData;
        public AvailabilityServiceTest(HotelFixtureData hotelFixtureData)
        {
            _hotelFixtureData = hotelFixtureData;
        }
    }
    [Collection("HotelCollection")]
    public class SearchServiceTest
    {
        HotelFixtureData _hotelFixtureData;

        public SearchServiceTest(HotelFixtureData hotelFixtureData)
        {
            _hotelFixtureData = hotelFixtureData;
        }
    }
    
    ```
  # Trait 
  - [Trait] - Trait attribute is used to categorize or organize tests. 
  
  # Theory
  - [Theory] attribute denotes a parameterised test that is true for a subset of data  
    - InlineData
      ```csharp  
        [Theory]
        [InlineData("2020-01-15", "2020-01-25", 100, 110)]
        [InlineData("2020-03-25", "2020-04-05", 100, 112)]
        [InlineData("2020-12-25", "2021-01-05", 100, 113)]
        public void CalculatePrice_HasValidPeriod_ResultShouldBeCorrect(string checkIn, string checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            //Act
            //Assert
        }
      ```
    - ClassData  
      ```csharp  
        [Theory]
        [ClassData(typeof(PricingTestData))]
        public void CalculatePrice_TestCasesAreDefinedInClassData_ResultShouldBeCorrect(DateTime checkIn, DateTime checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            //Act
            //Assert
        }
      ```
      Create separate class "PricingTestData"
      ```csharp  
        public class PricingTestData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { new DateTime(2020, 01, 10), new DateTime(2020, 01, 15), 100, 110 };
                yield return new object[] { new DateTime(2020, 03, 27), new DateTime(2020, 04, 15), 100, 112 };
                yield return new object[] { new DateTime(2020, 12, 10), new DateTime(2021, 01, 15), 100, 113 };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
      ```
            
    - MemberData  
       ```csharp  
        [Theory]
        [MemberData(nameof(PricingMemberTestCases))]
        public void CalculatePrice_TestCasesAreDefinedAsMemberData_ResultShouldBeCorrect(DateTime checkIn, DateTime checkOut, decimal price, decimal expectedResult)
        {
            //Arrange
            //Act
            //Assert
        }
      ```
      Create static property within the Test class
      ```csharp
        public static IEnumerable<object[]> PricingMemberTestCases => new List<object[]>
        {
            new object[] { new DateTime(2020, 01, 10), new DateTime(2020, 01, 15), 100, 110 },
            new object[] { new DateTime(2020, 03, 27), new DateTime(2020, 04, 15), 100, 112 },
            new object[] { new DateTime(2020, 12, 10), new DateTime(2021, 01, 15), 100, 113 }
        };
      ```
