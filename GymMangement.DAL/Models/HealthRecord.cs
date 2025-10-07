using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.DAL.Models
{
    [Table("Members")]
    public class HealthRecord :ModelBase
    {
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public string BloodType { get; set; } = null!;
        public string? Notes { get; set; }


    }
}
