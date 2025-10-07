using GymMangement.DAL.Models.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Models
{
    [Owned]
    public class Adress
    {
        public int BuldingNo { get; set; }
        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;
    }
    public abstract class GymUser : ModelBase
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public Adress Adress { get; set; } = null!;
    }
}
