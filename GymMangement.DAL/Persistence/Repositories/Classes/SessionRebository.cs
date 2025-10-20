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
    public class SessionRebository :ISessionRebository
    {
        private readonly GymDbContext _context;
        public SessionRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Session> GetAll()
        {
            return _context.Sessions.ToList();
        }

        public Session? GetById(int id)
        {
            return _context.Sessions.Find(id);
        }


        public int Add(Session Session)
        {
            _context.Sessions.Add(Session);
            return _context.SaveChanges();
        }


        public int Update(Session Session)
        {
            _context.Sessions.Update(Session);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Session = _context.Sessions.Find(id);
            if (Session != null)
            {
                _context.Sessions.Remove(Session);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
