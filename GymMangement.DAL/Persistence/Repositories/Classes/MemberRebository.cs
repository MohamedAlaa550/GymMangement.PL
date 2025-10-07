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
    public class MemberRebository : IMemberRebository
    {
        private readonly GymDbContext _context;
        public MemberRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members.ToList();
        }

        public Member? GetById(int id)
        {
            return _context.Members.Find(id);
        }

        
        public int Add(Member member)
        {
            _context.Members.Add(member);
            return _context.SaveChanges();
        }

        
        public int Update(Member member)
        {
            _context.Members.Update(member);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var member = _context.Members.Find(id);
            if (member != null)
            {
                _context.Members.Remove(member);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
