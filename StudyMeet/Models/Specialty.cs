using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class Specialty
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Fill Full Name")]
        [StringLength(5, MinimumLength = 50, ErrorMessage = "The full name length must be between 6 and 12 characters")]
        public string fullname { get; set; }

        [Required(ErrorMessage = "Fill Short Name")]
        [StringLength(2, MinimumLength = 11, ErrorMessage = "The full name length must be between 6 and 12 characters")]
        public string shortname { get; set; }

        public ICollection<User> users { get; set; }

        public Specialty()
        {
            users = new List<User>();
        }
    }
}