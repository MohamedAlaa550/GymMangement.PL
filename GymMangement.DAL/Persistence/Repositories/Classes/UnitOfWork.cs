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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _context;
        private readonly Dictionary<string, object> repositories = [];
        public UnitOfWork(GymDbContext context) 
        {
            _context = context;
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : ModelBase
        {
            var EntityName = typeof(TEntity).Name;
            if (repositories.TryGetValue(EntityName, out object? value))
            {
                return (IGenericRepository<TEntity>)value;
            }

            var repository = new GenericRepository<TEntity>(_context);
            repositories.Add(EntityName, repository);
            return repository;

        }

        public int SaveChangesAsync() => _context.SaveChanges();

    }
}
