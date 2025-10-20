using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface ISessionRebository
    {
        Session? GetById(int id);
        IEnumerable<Session> GetAll();
        int Add(Session Session);
        int Update(Session Session);
        int Delete(int id);
    }
}
