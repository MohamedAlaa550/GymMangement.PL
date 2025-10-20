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
    public class TrainerRebository : ITrainerRebository
    {
        private readonly GymDbContext _context;
        public TrainerRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _context.Trainers.ToList();
        }

        public Trainer? GetById(int id)
        {
            return _context.Trainers.Find(id);
        }


        public int Add(Trainer Trainer)
        {
            _context.Trainers.Add(Trainer);
            return _context.SaveChanges();
        }


        public int Update(Trainer Trainer)
        {
            _context.Trainers.Update(Trainer);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Trainer = _context.Trainers.Find(id);
            if (Trainer != null)
            {
                _context.Trainers.Remove(Trainer);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
    
