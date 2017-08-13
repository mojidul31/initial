namespace EFSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_Address_Trainee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainees", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trainees", "Address");
        }
    }
}
