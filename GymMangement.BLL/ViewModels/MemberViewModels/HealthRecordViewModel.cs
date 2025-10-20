using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.ViewModels.MemberViewModels
{
    public class HealthRecordViewModel
    {
        [Range(1,300,ErrorMessage ="Height Must Be Between 1 And 300 ")]
        public decimal Height { get; set; }

        [Range(1, 500, ErrorMessage = "Weight Must Be Between 1 And 500 ")]
        public decimal Weight { get; set; }
        [Required(ErrorMessage = "Blood Type Is Required")]

        [StringLength(3,ErrorMessage =" Blood Type Must Be  3 Characters Or Less")]

        public string BloodType { get; set; } = string.Empty;

        public string Note { get; set; } = string.Empty;
    }
}
