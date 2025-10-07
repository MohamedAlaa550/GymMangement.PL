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
    internal class HealthRecordRebository:IHealthRecordRebository
    {
        private readonly GymDbContext _context;
        public HealthRecordRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<HealthRecord> GetAll()
        {
            return _context.HealthRecords.ToList();
        }

        public HealthRecord? GetById(int id)
        {
            return _context.HealthRecords.Find(id);
        }


        public int Add(HealthRecord HealthRecord)
        {
            _context.HealthRecords.Add(HealthRecord);
            return _context.SaveChanges();
        }


        public int Update(HealthRecord HealthRecord)
        {
            _context.HealthRecords.Update(HealthRecord);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var HealthRecord = _context.HealthRecords.Find(id);
            if (HealthRecord != null)
            {
                _context.HealthRecords.Remove(HealthRecord);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
