using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private readonly List<IRoom> roomRepository;

        public RoomRepository()
        {
            roomRepository= new List<IRoom>();
        }
        public void AddNew(IRoom model)
        {
            roomRepository.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
                => roomRepository.AsReadOnly();

        public IRoom Select(string criteria)
        {
            return roomRepository.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
