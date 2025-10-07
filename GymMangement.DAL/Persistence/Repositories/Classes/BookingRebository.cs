using GymMangement.DAL.Models;
using GymMangement.DAL.Persistence.Data.Context;
using GymMangement.DAL.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Classes
{
    public class BookingRebository : IBookingRebository
    {
        private readonly GymDbContext _context;
        public BookingRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings.Find(id);
        }


        public int Add(Booking Booking)
        {
            _context.Bookings.Add(Booking);
            return _context.SaveChanges();
        }


        public int Update(Booking Booking)
        {
            _context.Bookings.Update(Booking);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Booking = _context.Bookings.Find(id);
            if (Booking != null)
            {
                _context.Bookings.Remove(Booking);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
