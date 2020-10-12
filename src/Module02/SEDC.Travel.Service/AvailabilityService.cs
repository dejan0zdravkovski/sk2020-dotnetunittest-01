using System.Collections.Generic;

using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Service.Contract;
using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.ThirdParty;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelAvailability _hotelAvailability;
        private readonly IPricingService _pricingService;

        public AvailabilityService(IHotelRepository hotelRepository, IHotelAvailability hotelAvailability, IPricingService pricingService)
        {
            _hotelRepository = hotelRepository;
            _hotelAvailability = hotelAvailability;
            _pricingService = pricingService;
        }

        public AvailabilityResponse CheckAvailability(SearchRequest request, List<string> hotelCodes)
        {
            if (request.FromDate == null)
            {

            }
            if (request.ToDate == null)
            {

            }

            if (request.ToDate < request.FromDate)
            {

            }

            if (request.Adults < 1)
            {

            }

            if (request.Adults < request.Rooms)
            {

            }

            var hoteSearchRequest = Request(request);

            var response = _hotelAvailability.SearchHotelAvailability(hoteSearchRequest);

            return ProcessAvailability(response);

        }

        public AvailabilityResponse ProcessAvailability(HotelAvailabilityResponse response)
        {
            var result = new AvailabilityResponse();

            result.CheckIn = response.CheckIn;
            result.CheckOut = response.CheckOut;
            var availableHotels = new List<AvailableHotel>();
            foreach (var hotels in response.AvailableHotels)
            {
                var hotel = new AvailableHotel();

                hotel.Code = hotels.Code;

                var rooms = new List<AvailableRoom>();
                foreach (var room in hotels.AvailableRooms)
                {
                    var data = new AvailableRoom();
                    data.Id = room.Id;
                    data.Code = room.Code;
                    data.Price = room.Price;
                    data.NewPrice = _pricingService.CalculatePrice(response.CheckIn, response.CheckOut, room.Price);
                    rooms.Add(data);
                }
                hotel.AvailableRooms = rooms;

                availableHotels.Add(hotel);

            }

            result.AvailableHotels = availableHotels;


            return result;
        }

        private HotelAvailabilityRequest Request(SearchRequest searchRequest)
        {
            var request = new HotelAvailabilityRequest();
            request.CheckIn = searchRequest.FromDate;
            request.CheckOut = searchRequest.ToDate;
            request.Nights = (searchRequest.ToDate - searchRequest.FromDate).Days;

            request.Adults = searchRequest.Adults;
            request.Children = searchRequest.Children;
            request.Infants = searchRequest.Infants;
            request.Rooms = searchRequest.Rooms;
            request.HotelCategory = searchRequest.HotelCategory;

            return request;
        }

    }
}
