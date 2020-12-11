namespace StudyMeet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostFeedbacks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        feedback = c.String(),
                        created_date = c.DateTime(nullable: false),
                        responderId = c.Int(),
                        postId = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.postId)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.postId)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        created_date = c.DateTime(nullable: false),
                        asking_user_id = c.Int(),
                        teamId = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.teamId)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.teamId)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                        img_url = c.String(),
                        max_users = c.Int(nullable: false),
                        created_date = c.DateTime(nullable: false),
                        organizerId = c.Int(),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fname = c.String(),
                        mname = c.String(),
                        lname = c.String(),
                        age = c.Int(nullable: false),
                        img_url = c.String(),
                        address = c.String(),
                        login = c.String(),
                        password = c.String(),
                        specialty_id = c.Int(),
                        specialty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Specialties", t => t.specialty_Id)
                .Index(t => t.specialty_Id);
            
            CreateTable(
                "dbo.Specialties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        fullname = c.String(),
                        shortname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User_Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(),
                        teamId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.teamId)
                .ForeignKey("dbo.Users", t => t.userId)
                .Index(t => t.userId)
                .Index(t => t.teamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User_Team", "userId", "dbo.Users");
            DropForeignKey("dbo.User_Team", "teamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Users", "specialty_Id", "dbo.Specialties");
            DropForeignKey("dbo.Posts", "user_Id", "dbo.Users");
            DropForeignKey("dbo.PostFeedbacks", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Posts", "teamId", "dbo.Teams");
            DropForeignKey("dbo.PostFeedbacks", "postId", "dbo.Posts");
            DropIndex("dbo.User_Team", new[] { "teamId" });
            DropIndex("dbo.User_Team", new[] { "userId" });
            DropIndex("dbo.Users", new[] { "specialty_Id" });
            DropIndex("dbo.Teams", new[] { "user_Id" });
            DropIndex("dbo.Posts", new[] { "user_Id" });
            DropIndex("dbo.Posts", new[] { "teamId" });
            DropIndex("dbo.PostFeedbacks", new[] { "user_Id" });
            DropIndex("dbo.PostFeedbacks", new[] { "postId" });
            DropTable("dbo.User_Team");
            DropTable("dbo.Specialties");
            DropTable("dbo.Users");
            DropTable("dbo.Teams");
            DropTable("dbo.Posts");
            DropTable("dbo.PostFeedbacks");
        }
    }
}
