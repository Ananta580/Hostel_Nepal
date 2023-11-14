namespace HostelNepal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblAdmins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdminName = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.tblBanners",
                c => new
                    {
                        BannerId = c.Int(nullable: false, identity: true),
                        HostelId = c.Int(),
                        Activated = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.BannerId)
                .ForeignKey("dbo.tblHostels", t => t.HostelId)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.tblHostels",
                c => new
                    {
                        HostelId = c.Int(nullable: false, identity: true),
                        HostelName = c.String(),
                        Description = c.String(),
                        Star = c.Int(),
                        Address = c.String(),
                        Capacity = c.Int(),
                        MapLocation = c.String(),
                        Photo = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        WardenId = c.Int(),
                        Latest = c.String(),
                        DescriptionNext = c.String(),
                        Facilites = c.String(),
                    })
                .PrimaryKey(t => t.HostelId)
                .ForeignKey("dbo.tblWardens", t => t.WardenId)
                .Index(t => t.WardenId);
            
            CreateTable(
                "dbo.tblChoices",
                c => new
                    {
                        ChoiceId = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(),
                        HostelId = c.Int(),
                    })
                .PrimaryKey(t => t.ChoiceId)
                .ForeignKey("dbo.tblHostels", t => t.HostelId)
                .ForeignKey("dbo.tblStudents", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.tblStudents",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        UserName = c.String(),
                        TemporaryAddress = c.String(),
                        PermanentAddress = c.String(),
                        Education = c.String(),
                        Phone = c.String(),
                        DOB = c.DateTime(),
                        Age = c.Int(),
                        Email = c.String(),
                        Testomonial = c.String(),
                        Photo = c.String(),
                        AvatarPhoto = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.tblPhotoes",
                c => new
                    {
                        PhotoId = c.Int(nullable: false, identity: true),
                        Photo = c.String(),
                        HostelId = c.Int(),
                    })
                .PrimaryKey(t => t.PhotoId)
                .ForeignKey("dbo.tblHostels", t => t.HostelId)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.tblRooms",
                c => new
                    {
                        RoomId = c.Int(nullable: false, identity: true),
                        RoomName = c.String(),
                        PriceId = c.Int(),
                        HostelId = c.Int(),
                    })
                .PrimaryKey(t => t.RoomId)
                .ForeignKey("dbo.tblHostels", t => t.HostelId)
                .ForeignKey("dbo.tblPrices", t => t.PriceId)
                .Index(t => t.PriceId)
                .Index(t => t.HostelId);
            
            CreateTable(
                "dbo.tblPrices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PriceId);
            
            CreateTable(
                "dbo.tblWardens",
                c => new
                    {
                        WardenId = c.Int(nullable: false, identity: true),
                        WardenName = c.String(),
                        WardenQuotes = c.String(),
                        WardenPhone = c.String(),
                        WardenAddress = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Photo = c.String(),
                        Best = c.String(),
                    })
                .PrimaryKey(t => t.WardenId);
            
            CreateTable(
                "dbo.tblMessages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        SenderName = c.String(),
                        Subject = c.String(),
                        Email = c.String(),
                        Message = c.String(),
                        Tag = c.String(),
                    })
                .PrimaryKey(t => t.MessageId);
            
            CreateTable(
                "dbo.tblNews",
                c => new
                    {
                        NewsId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.NewsId);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.tblUserRoles",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.tblRoles", t => t.RoleId)
                .ForeignKey("dbo.tblusers", t => t.UserId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.tblusers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Flag = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblUserRoles", "UserId", "dbo.tblusers");
            DropForeignKey("dbo.tblUserRoles", "RoleId", "dbo.tblRoles");
            DropForeignKey("dbo.tblHostels", "WardenId", "dbo.tblWardens");
            DropForeignKey("dbo.tblRooms", "PriceId", "dbo.tblPrices");
            DropForeignKey("dbo.tblRooms", "HostelId", "dbo.tblHostels");
            DropForeignKey("dbo.tblPhotoes", "HostelId", "dbo.tblHostels");
            DropForeignKey("dbo.tblChoices", "StudentId", "dbo.tblStudents");
            DropForeignKey("dbo.tblChoices", "HostelId", "dbo.tblHostels");
            DropForeignKey("dbo.tblBanners", "HostelId", "dbo.tblHostels");
            DropIndex("dbo.tblUserRoles", new[] { "UserId" });
            DropIndex("dbo.tblUserRoles", new[] { "RoleId" });
            DropIndex("dbo.tblRooms", new[] { "HostelId" });
            DropIndex("dbo.tblRooms", new[] { "PriceId" });
            DropIndex("dbo.tblPhotoes", new[] { "HostelId" });
            DropIndex("dbo.tblChoices", new[] { "HostelId" });
            DropIndex("dbo.tblChoices", new[] { "StudentId" });
            DropIndex("dbo.tblHostels", new[] { "WardenId" });
            DropIndex("dbo.tblBanners", new[] { "HostelId" });
            DropTable("dbo.tblusers");
            DropTable("dbo.tblUserRoles");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblNews");
            DropTable("dbo.tblMessages");
            DropTable("dbo.tblWardens");
            DropTable("dbo.tblPrices");
            DropTable("dbo.tblRooms");
            DropTable("dbo.tblPhotoes");
            DropTable("dbo.tblStudents");
            DropTable("dbo.tblChoices");
            DropTable("dbo.tblHostels");
            DropTable("dbo.tblBanners");
            DropTable("dbo.tblAdmins");
        }
    }
}
