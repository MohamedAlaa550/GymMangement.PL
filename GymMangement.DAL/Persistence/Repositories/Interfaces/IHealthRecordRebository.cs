using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IHealthRecordRebository
    {
        HealthRecord? GetById(int id);
        IEnumerable<HealthRecord> GetAll();
        int Add(HealthRecord HealthRecord);
        int Update(HealthRecord HealthRecord);
        int Delete(int id);
    }
}
