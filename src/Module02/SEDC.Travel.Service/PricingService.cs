using System;
using System.Collections.Generic;
using System.Linq;

using SEDC.Travel.Domain.Contract;
using SEDC.Travel.Service.Contract;
using SEDC.Travel.Service.Model;
using SEDC.Travel.Service.Model.ThirdParty;

namespace SEDC.Travel.Service
{
    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepository;

        public PricingService(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        /// <summary>
        /// Returns percent for given Date period.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>
        /// If no pricing period are defined it will return 13.
        /// If the period is defined it will return the defined percent.
        /// If we have overlapping it will return the bigges percent with in the periods defined.
        /// If only one period is defined it will return 13.
        /// </returns>
        public decimal GetPricingPercent(DateTime from, DateTime to)
        {
            var priceList = _pricingRepository.GetPricings();

            if (!priceList.Any())
            {
                return 13;
            }

            var result = priceList.Where(x => x.From <= from && x.To >= to).OrderBy(x => x.Percent);
            if (result.Any())
            {
                return result.FirstOrDefault().Percent;
            }
            else
            {
                var fromPercent = priceList.FirstOrDefault(x => x.From <= from && from <= x.To);
                var toPercent = priceList.FirstOrDefault(x => x.From <= to && to <= x.To);
                if (fromPercent != null && toPercent != null)
                {
                    return fromPercent.Percent > toPercent.Percent ? fromPercent.Percent : toPercent.Percent;
                }
                else
                {
                    return 13;
                }
            }
        }

        public RoomCombination CalculatePrice(DateTime checkIn, DateTime checkOut, HotelRoomCombination roomCombination)
        {
            var pricePercent = GetPricingPercent(checkIn, checkOut);

            var result = new RoomCombination();
            var roomList = new List<AvailableRoom>();
            foreach (var item in roomCombination.AvailableRooms)
            {
                var room = new AvailableRoom();
                room.Id = item.Id;
                room.Code = item.Code;
                room.Price = item.Price;
                room.NewPrice = item.Price + ((pricePercent / 100) * 100);

                roomList.Add(room);

                result.FullPrice = result.FullPrice + room.NewPrice;
            }

            result.AvailableRooms = roomList;
            return result;
        }

    }
}
