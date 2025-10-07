using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IBookingRebository
    {
        Booking? GetById(int id);
        IEnumerable<Booking> GetAll();
        int Add(Booking Booking);
        int Update(Booking Booking);
        int Delete(int id);
    }
}
