using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudyMeet.Models
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostFeedback> PostFeedbacks { get; set; }
        public DbSet<User_Team> Users_Teams { get; set; }
    }
}