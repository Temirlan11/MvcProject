using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class PostFeedback
    {
        public int Id { get; set; }
        public string feedback { get; set; }
        public DateTime created_date { get; set; }
        public int? responderId { get; set; }
        public User user { get; set; }
        public int? postId { get; set; }
        public Post post { get; set; }
    }
}