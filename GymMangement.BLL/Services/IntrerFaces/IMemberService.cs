using GymMangement.BLL.ViewModels.MemberViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.Services.IntrerFaces
{
    public interface IMemberService
    {
        IEnumerable<MemberViewModel> GetAllMembers();
        bool CreateMember(CreateMemberViewModel member);

        MemberViewModel? GetMemberDetails(int MemberId);

        HealthRecordViewModel? GetMemberHealthRecord(int MemberId);


    }
}
