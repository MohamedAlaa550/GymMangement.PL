using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IPlanRebository
    {
        Plan? GetById(int id);
        IEnumerable<Plan> GetAll();
        int Add(Plan Plan);
        int Update(Plan Plan);
        int Delete(int id);
    }
}
