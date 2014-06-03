namespace Seranet.SpecM2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMemberRep : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "ProjectMemberRep", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "ProjectMemberRep");
        }
    }
}
