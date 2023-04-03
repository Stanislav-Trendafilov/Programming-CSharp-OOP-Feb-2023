using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            rooms= new RoomRepository();  
            bookings=new BookingRepository();
        }

        public double Turnover
             =>Math.Round(Bookings.All().Sum(x=>x.ResidenceDuration * x.Room.PricePerNight),2);

        public int Category
        {
            get { return category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
                }
                fullName = value;
            }
        }

        private IRepository<IRoom> rooms;
        public IRepository<IRoom> Rooms => rooms;

        private IRepository<IBooking> bookings;
        public IRepository<IBooking> Bookings => bookings;
    }
}
