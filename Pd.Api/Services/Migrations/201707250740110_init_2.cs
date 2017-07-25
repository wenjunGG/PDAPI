namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Headers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        HeaderCode = c.String(unicode: false),
                        HeaderName = c.String(unicode: false),
                        REMARK = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .Index(t => t.ModularID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headers", "ModularID", "dbo.T_ACT_Modular");
            DropIndex("dbo.Headers", new[] { "ModularID" });
            DropTable("dbo.Headers");
        }
    }
}
