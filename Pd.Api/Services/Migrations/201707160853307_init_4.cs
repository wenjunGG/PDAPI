namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_MON_RequestCoeff", "ModularID", c => c.Guid(nullable: false));
            CreateIndex("dbo.T_MON_RequestCoeff", "ModularID");
            AddForeignKey("dbo.T_MON_RequestCoeff", "ModularID", "dbo.T_ACT_Modular", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_MON_RequestCoeff", "ModularID", "dbo.T_ACT_Modular");
            DropIndex("dbo.T_MON_RequestCoeff", new[] { "ModularID" });
            DropColumn("dbo.T_MON_RequestCoeff", "ModularID");
        }
    }
}
