namespace DisciplineMe.Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fromdatetomsgtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Habits", "MessageTime", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Habits", "DateStart");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Habits", "DateStart", c => c.DateTime(nullable: false));
            DropColumn("dbo.Habits", "MessageTime");
        }
    }
}
