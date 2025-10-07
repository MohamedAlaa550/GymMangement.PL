using GymMangement.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Models
{
    public class Member : GymUser
    {
        public string? photo { get; set; }
        public HealthRecord HealthRecord { get; set; } = null!;

        public ICollection<MemberShip> MemberPlans { get; set; } = new HashSet<MemberShip>();

        public ICollection<Booking> MemberSessions { get; set; } = new HashSet<Booking>();

    }
}
