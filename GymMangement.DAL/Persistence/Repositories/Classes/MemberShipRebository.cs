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
    public class MemberShipRebository:IMemberShipRebository
    {
        private readonly GymDbContext _context;
        public MemberShipRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MemberShip> GetAll()
        {
            return _context.MemberShips.ToList();
        }

        public MemberShip? GetById(int id)
        {
            return _context.MemberShips.Find(id);
        }


        public int Add(MemberShip MemberShip)
        {
            _context.MemberShips.Add(MemberShip);
            return _context.SaveChanges();
        }


        public int Update(MemberShip MemberShip)
        {
            _context.MemberShips.Update(MemberShip);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var MemberShip = _context.MemberShips.Find(id);
            if (MemberShip != null)
            {
                _context.MemberShips.Remove(MemberShip);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
