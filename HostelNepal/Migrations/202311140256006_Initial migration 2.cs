namespace HostelNepal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigration2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblusers", "Flag");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblusers", "Flag", c => c.Int());
        }
    }
}
