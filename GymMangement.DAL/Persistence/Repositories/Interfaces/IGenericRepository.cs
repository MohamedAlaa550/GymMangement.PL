using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : ModelBase
    {
        TEntity? GetById(int id);
        IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
