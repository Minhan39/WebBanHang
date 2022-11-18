namespace SpiderFoodStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListImages");
        }
    }
}
