using GymMangement.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Models
{
    public class Trainer: GymUser
    {
        public Specialties specialties { get; set; }
        public ICollection<Session> Sessions { get; set; } = new HashSet<Session>();
    }
}
