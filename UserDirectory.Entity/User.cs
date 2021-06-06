using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDirectory.Entity
{
    public class User
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname cannot be empty")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Birthday cannot be empty")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public string Image { get; set; }

        [Required(ErrorMessage = "Location cannot be empty")]
        public string Location { get; set; }


        [Required(ErrorMessage = "Phone cannot be empty")]
        public List<Phone> Phones { get; set; }
    }
}
