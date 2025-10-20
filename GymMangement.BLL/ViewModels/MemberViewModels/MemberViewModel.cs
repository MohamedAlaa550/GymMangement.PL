using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.ViewModels.MemberViewModels
{
    public class MemberViewModel
    {
        public int Id { get; set; }
        public string Photo { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string DateOfBirth { get; set; }= string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? MembershipStartDate { get; set; } = string.Empty;
        public string? MembershipEndDate { get; set; }= string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string? PlanName { get; set; } = string.Empty;
    }
}
