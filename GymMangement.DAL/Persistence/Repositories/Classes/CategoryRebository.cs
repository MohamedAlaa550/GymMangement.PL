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
    public class CategoryRebository:ICategoryRebository
    {
        private readonly GymDbContext _context;
        public CategoryRebository(GymDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int id)
        {
            return _context.Categories.Find(id);
        }


        public int Add(Category Category)
        {
            _context.Categories.Add(Category);
            return _context.SaveChanges();
        }


        public int Update(Category Category)
        {
            _context.Categories.Update(Category);
            return _context.SaveChanges();
        }

        public int Delete(int id)
        {
            var Category = _context.Categories.Find(id);
            if (Category != null)
            {
                _context.Categories.Remove(Category);
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
