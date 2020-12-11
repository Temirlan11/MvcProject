using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        public string fname { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        public string mname { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        public string lname { get; set; }
        [Required(ErrorMessage = "The field must be set")]
        [Range(15, 100, ErrorMessage = "Invalid age")]
        public int age { get; set; }
        [Required]
        public string img_url { get; set; }
        public string address { get; set; }
        [Required(ErrorMessage = "The field LOGIN must be set")]
        public string login { get; set; }
        [Required(ErrorMessage = "Fill PASSWORD")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "The password length must be between 6 and 12 characters")]
        public string password { get; set; }
        [Required]
        public int? specialty_id { get; set; }
        public Specialty specialty { get; set; }

        public ICollection<Post> posts { get; set; }
        public ICollection<PostFeedback> postFeedbacks { get; set; }
        public ICollection<Team> teams { get; set; }
        public ICollection<User_Team> Users_Teams { get; set; }
        public User()
        {
            posts = new List<Post>();
            postFeedbacks = new List<PostFeedback>();
            teams = new List<Team>();
            Users_Teams = new List<User_Team>();
        }
    }
}