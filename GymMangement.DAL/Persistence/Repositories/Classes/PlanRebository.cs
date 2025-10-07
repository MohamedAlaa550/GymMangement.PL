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
    public class PlanRebository :IPlanRebository
    {
        private readonly GymDbContext _context;
        public PlanRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Plan> GetAll()
        {
            return _context.Plans.ToList();
        }

        public Plan? GetById(int id)
        {
            return _context.Plans.Find(id);
        }


        public int Add(Plan Plan)
        {
            _context.Plans.Add(Plan);
            return _context.SaveChanges();
        }


        public int Update(Plan Plan)
        {
            _context.Plans.Update(Plan);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Plan = _context.Plans.Find(id);
            if (Plan != null)
            {
                _context.Plans.Remove(Plan);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
