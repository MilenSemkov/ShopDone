﻿namespace ShopVegieAndFruitMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vegans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Discription = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VeganTypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VeganTypes", t => t.VeganTypesId, cascadeDelete: true)
                .Index(t => t.VeganTypesId);
            
            CreateTable(
                "dbo.VeganTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vegans", "VeganTypesId", "dbo.VeganTypes");
            DropIndex("dbo.Vegans", new[] { "VeganTypesId" });
            DropTable("dbo.VeganTypes");
            DropTable("dbo.Vegans");
        }
    }
}
