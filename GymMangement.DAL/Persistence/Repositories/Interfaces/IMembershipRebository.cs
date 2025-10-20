using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IMemberShipRebository
    {
        MemberShip? GetById(int id);
        IEnumerable<MemberShip> GetAll();
        int Add(MemberShip MemberShip);
        int Update(MemberShip MemberShip);
        int Delete(int id);
    }
}
