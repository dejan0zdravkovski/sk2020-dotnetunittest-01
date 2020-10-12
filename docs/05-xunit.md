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
  
  # Skip
 
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
