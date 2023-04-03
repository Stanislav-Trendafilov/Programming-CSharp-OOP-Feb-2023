using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;
        private double pricePerNight ;

        protected Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
        }

        [DefaultValue(0)]
        public double PricePerNight 
        {
            get { return pricePerNight ; }
            private set
            { 
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.PricePerNightNegative);
                }
                pricePerNight  = value;
            }
        }

        public int BedCapacity
        {
            get { return bedCapacity; }
            private set { bedCapacity = value; }
        }


        public void SetPrice(double price)
        {
            PricePerNight= price;
        }
    }
}
