using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface ICategoryRebository
    {
        Category? GetById(int id);
        IEnumerable<Category> GetAll();
        int Add(Category Category);
        int Update(Category Category);
        int Delete(int id);
    }
}
