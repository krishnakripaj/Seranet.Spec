namespace Seranet.SpecM2.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeammebrsm : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Project", "TeamMembers", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Project", "TeamMembers");
        }
    }
}
