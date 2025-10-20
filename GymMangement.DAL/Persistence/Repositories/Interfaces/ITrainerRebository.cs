using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface ITrainerRebository
    {
        Trainer? GetById(int id);
        IEnumerable<Trainer> GetAll();
        int Add(Trainer trainer);
        int Update(Trainer trainer);
        int Delete(int id);
    }
}
