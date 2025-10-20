using GymMangement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Persistence.Repositories.Interfaces
{
    public interface IMemberRebository
    {
        Member? GetById(int id);
        IEnumerable<Member> GetAll();
        int Add(Member member);
        int Update(Member member);
        int Delete(int id);
    }
}
