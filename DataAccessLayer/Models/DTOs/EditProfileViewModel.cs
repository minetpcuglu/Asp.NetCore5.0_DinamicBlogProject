using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models.DTOs
{
    public class EditProfileViewModel
    {

        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        [Display(Name = "User Name")]
        public string Email { get; set; }
    }
}
