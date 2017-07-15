namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_SYS_USER",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        ENTERPRISEID = c.Guid(nullable: false),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_SYS_USER");
        }
    }
}
