namespace DisciplineMe.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxcharsfortextfields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Habits", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Habits", "QuestionPhrase", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Habits", "QuestionPhrase", c => c.String(maxLength: 100));
            AlterColumn("dbo.Habits", "Title", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
