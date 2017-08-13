namespace EFSample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Instituation_Add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Trainees", "InstitutionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Trainees", "InstitutionId");
            AddForeignKey("dbo.Trainees", "InstitutionId", "dbo.Institutions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainees", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.Trainees", new[] { "InstitutionId" });
            DropColumn("dbo.Trainees", "InstitutionId");
            DropTable("dbo.Institutions");
        }
    }
}
