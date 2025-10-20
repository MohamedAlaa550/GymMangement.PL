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
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ModelBase
    {
        private readonly GymDbContext _context;

        public GenericRepository(GymDbContext context) 
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
           
        }

        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
           if(condition is null)
            {
                return _context.Set<TEntity>().ToList();
            }
              return _context.Set<TEntity>().Where(condition).ToList();
        }

        public TEntity? GetById(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity is null)
                return null;
            return entity;


        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }
    }
}
