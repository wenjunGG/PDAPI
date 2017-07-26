namespace Services.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init_1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_MON_Back",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        PortsID = c.Guid(nullable: false),
                        BackCode = c.String(maxLength: 50, storeType: "nvarchar"),
                        BackMess = c.String(maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .ForeignKey("dbo.T_MON_Ports", t => t.PortsID, cascadeDelete: true)
                .Index(t => t.ModularID)
                .Index(t => t.PortsID);
            
            CreateTable(
                "dbo.T_ACT_Modular",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularName = c.String(maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.T_SYS_SysUserModular",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        SysUserID = c.Guid(),
                        ModularID = c.Guid(nullable: false),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .ForeignKey("dbo.T_SYS_USER", t => t.SysUserID)
                .Index(t => t.SysUserID)
                .Index(t => t.ModularID);
            
            CreateTable(
                "dbo.T_SYS_USER",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Password = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.T_MON_Ports",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        PortsName = c.String(maxLength: 50, storeType: "nvarchar"),
                        PortsIp = c.String(maxLength: 50, storeType: "nvarchar"),
                        PortsAddress = c.String(maxLength: 50, storeType: "nvarchar"),
                        PortsType = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsPag = c.Boolean(nullable: false),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .Index(t => t.ModularID);
            
            CreateTable(
                "dbo.T_MON_Coefficient",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        PortsID = c.Guid(nullable: false),
                        CoeffiCode = c.String(maxLength: 50, storeType: "nvarchar"),
                        CoffiName = c.String(maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .ForeignKey("dbo.T_MON_Ports", t => t.PortsID, cascadeDelete: true)
                .Index(t => t.ModularID)
                .Index(t => t.PortsID);
            
            CreateTable(
                "dbo.T_MON_DicModular",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        DicName = c.String(maxLength: 50, storeType: "nvarchar"),
                        DicValue = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsImportant = c.Boolean(nullable: false),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .Index(t => t.ModularID);
            
            CreateTable(
                "dbo.T_MON_DicPorts",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        PortsID = c.Guid(nullable: false),
                        DicName = c.String(maxLength: 50, storeType: "nvarchar"),
                        DicValue = c.String(maxLength: 50, storeType: "nvarchar"),
                        IsImportant = c.Boolean(nullable: false),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .ForeignKey("dbo.T_MON_Ports", t => t.PortsID, cascadeDelete: true)
                .Index(t => t.ModularID)
                .Index(t => t.PortsID);
            
            CreateTable(
                "dbo.Headers",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        HeaderCode = c.String(maxLength: 50, storeType: "nvarchar"),
                        HeaderName = c.String(maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .Index(t => t.ModularID);
            
            CreateTable(
                "dbo.T_MON_RequestCoeff",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        ModularID = c.Guid(nullable: false),
                        PortsID = c.Guid(nullable: false),
                        CoeffCode = c.String(maxLength: 50, storeType: "nvarchar"),
                        CoffValue = c.String(maxLength: 50, storeType: "nvarchar"),
                        REMARK = c.String(maxLength: 3000, storeType: "nvarchar"),
                        CreatedDate = c.DateTime(nullable: false, precision: 0),
                        UPDATEDDATE = c.DateTime(nullable: false, precision: 0),
                        USERID = c.Guid(),
                        DELETED = c.Boolean(nullable: false),
                        ISTURE = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_ACT_Modular", t => t.ModularID, cascadeDelete: true)
                .ForeignKey("dbo.T_MON_Ports", t => t.PortsID, cascadeDelete: true)
                .Index(t => t.ModularID)
                .Index(t => t.PortsID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.T_MON_RequestCoeff", "PortsID", "dbo.T_MON_Ports");
            DropForeignKey("dbo.T_MON_RequestCoeff", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.Headers", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_MON_DicPorts", "PortsID", "dbo.T_MON_Ports");
            DropForeignKey("dbo.T_MON_DicPorts", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_MON_DicModular", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_MON_Coefficient", "PortsID", "dbo.T_MON_Ports");
            DropForeignKey("dbo.T_MON_Coefficient", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_MON_Back", "PortsID", "dbo.T_MON_Ports");
            DropForeignKey("dbo.T_MON_Ports", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_MON_Back", "ModularID", "dbo.T_ACT_Modular");
            DropForeignKey("dbo.T_SYS_SysUserModular", "SysUserID", "dbo.T_SYS_USER");
            DropForeignKey("dbo.T_SYS_SysUserModular", "ModularID", "dbo.T_ACT_Modular");
            DropIndex("dbo.T_MON_RequestCoeff", new[] { "PortsID" });
            DropIndex("dbo.T_MON_RequestCoeff", new[] { "ModularID" });
            DropIndex("dbo.Headers", new[] { "ModularID" });
            DropIndex("dbo.T_MON_DicPorts", new[] { "PortsID" });
            DropIndex("dbo.T_MON_DicPorts", new[] { "ModularID" });
            DropIndex("dbo.T_MON_DicModular", new[] { "ModularID" });
            DropIndex("dbo.T_MON_Coefficient", new[] { "PortsID" });
            DropIndex("dbo.T_MON_Coefficient", new[] { "ModularID" });
            DropIndex("dbo.T_MON_Ports", new[] { "ModularID" });
            DropIndex("dbo.T_SYS_SysUserModular", new[] { "ModularID" });
            DropIndex("dbo.T_SYS_SysUserModular", new[] { "SysUserID" });
            DropIndex("dbo.T_MON_Back", new[] { "PortsID" });
            DropIndex("dbo.T_MON_Back", new[] { "ModularID" });
            DropTable("dbo.T_MON_RequestCoeff");
            DropTable("dbo.Headers");
            DropTable("dbo.T_MON_DicPorts");
            DropTable("dbo.T_MON_DicModular");
            DropTable("dbo.T_MON_Coefficient");
            DropTable("dbo.T_MON_Ports");
            DropTable("dbo.T_SYS_USER");
            DropTable("dbo.T_SYS_SysUserModular");
            DropTable("dbo.T_ACT_Modular");
            DropTable("dbo.T_MON_Back");
        }
    }
}
