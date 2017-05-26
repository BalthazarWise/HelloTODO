namespace HelloTODO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubTasks",
                c => new
                    {
                        SubTaskId = c.Int(nullable: false, identity: true),
                        TaskId = c.Int(nullable: false),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubTaskId)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                        Email = c.String(nullable: false),
                        Deadline = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.Boolean(nullable: false),
                        Priority = c.Int(nullable: false),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagTasks",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Task_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Task_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tasks", t => t.Task_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Task_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagTasks", "Task_Id", "dbo.Tasks");
            DropForeignKey("dbo.TagTasks", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.SubTasks", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TagTasks", new[] { "Task_Id" });
            DropIndex("dbo.TagTasks", new[] { "Tag_Id" });
            DropIndex("dbo.SubTasks", new[] { "TaskId" });
            DropTable("dbo.TagTasks");
            DropTable("dbo.Tags");
            DropTable("dbo.Tasks");
            DropTable("dbo.SubTasks");
        }
    }
}
