using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private HotelRepository hotels;
        private RoomRepository rooms;
        private string[] availableRooms = new string[] { "Apartment", "DoubleBed", "Studio" };
        public Controller()
        {
            hotels = new HotelRepository();
            rooms = new RoomRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.Select(hotelName) != null)
            {
                return String.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(new Hotel(hotelName, category));

            return String.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (hotels.All().Any(x => x.Category == category) == false)
            {
                return String.Format(OutputMessages.CategoryInvalid, category);
            }

            var ordereHotels = hotels.All()
                .Where(x => x.Category == category)
                .OrderBy(x => x.FullName);

            foreach (var hotel in ordereHotels)
            {
                IRoom room = hotel.Rooms
                    .All()
                    .Where(x => x.PricePerNight > 0)
                    .OrderBy(x => x.BedCapacity)
                    .FirstOrDefault(x => x.BedCapacity >= adults + children);

                if (room != null)
                {
                    hotel.Bookings.AddNew(new Booking(room,duration,adults,children, hotel.Bookings.All().Count+1));
                    return String.Format(OutputMessages.BookingSuccessful, hotel.Bookings.All().Count, hotel.FullName);
                }
            }
            return OutputMessages.RoomNotAppropriate;
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if(hotel==null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");

            if(hotel.Bookings.All().Count==0)
            {
                sb.AppendLine(string.Empty);
                sb.AppendLine("none");
            }
            else
            {
                sb.AppendLine(string.Empty);
                foreach (var booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine(string.Empty);
                }
            }    

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (!availableRooms.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            if (hotel.Rooms.Select(roomTypeName) == null)
            {
                return OutputMessages.RoomTypeNotCreated;
            }

            if (hotel.Rooms.Select(roomTypeName).PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }

            hotel.Rooms.Select(roomTypeName).SetPrice(price);

            return String.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotels.Select(hotelName) == null)
            {
                return String.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (hotel.Rooms.Select(roomTypeName) != null)
            {
                return String.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            if (!availableRooms.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            IRoom room = null;

            if (roomTypeName == "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "DoubleBed")
            {
                room = new DoubleBed();
            }
            else
            {
                room = new Studio();
            }

            hotel.Rooms.AddNew(room);

            return String.Format(OutputMessages.RoomTypeAdded, room.GetType().Name, hotelName);
        }
    }
}
