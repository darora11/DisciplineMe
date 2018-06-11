namespace DisciplineMe.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addconfirmatontal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Confirmations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        IsConfirmed = c.Boolean(nullable: false),
                        Habit_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Habits", t => t.Habit_Id)
                .Index(t => t.Habit_Id);
            
            DropColumn("dbo.Habits", "DayPassed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Habits", "DayPassed", c => c.Int(nullable: false));
            DropForeignKey("dbo.Confirmations", "Habit_Id", "dbo.Habits");
            DropIndex("dbo.Confirmations", new[] { "Habit_Id" });
            DropTable("dbo.Confirmations");
        }
    }
}
