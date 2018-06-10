namespace DisciplineMe.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Habits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        DateStart = c.DateTime(nullable: false),
                        ActiveDuration = c.Time(nullable: false, precision: 7),
                        QuestionPhrase = c.String(maxLength: 100),
                        DayPassed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Habits");
        }
    }
}
