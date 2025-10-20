using GymMangement.DAL.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangement.BLL.ViewModels.MemberViewModels
{
    public class MemberToUpdateViewModel
    {
        

        public string? Name { get; set; }
        public string? Photo { get; set; }

        [Required(ErrorMessage = "Email Is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Is Required")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^(010|011|012|015)\\d{8}$\r\n", ErrorMessage = "You Must Type Valid Egyptian Number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date Of Birth Is Required")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender Is Required")]

        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Bulding Number Is Required")]
        [Range(1, int.MaxValue, ErrorMessage = "Bulding Number must be a positive integer.")]
        public int BuldingNo { get; set; }

        [Required(ErrorMessage = "City Is Required")]
        [RegularExpression("^[A-Za-z\\s]+$", ErrorMessage = "City can only contain letters and spaces.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "City name Must Be Between 2 And 100 Characters.")]
        public string City { get; set; } = string.Empty;


        [Required(ErrorMessage = "Street Is Required")]
        [RegularExpression("^[A-Za-z\\s]+$", ErrorMessage = "Street can only contain letters and spaces.")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "Street name Must Be Between 2 And 150 Characters.")]
        public string? Street { get; set; } = string.Empty;


    }
}
