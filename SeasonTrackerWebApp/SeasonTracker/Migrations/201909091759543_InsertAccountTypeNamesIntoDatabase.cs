namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertAccountTypeNamesIntoDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AccountTypes SET Name = 'Free' WHERE Id = 1");
            Sql("UPDATE AccountTypes SET Name = 'Enthusiast' WHERE Id = 2");
            Sql("UPDATE AccountTypes SET Name = 'Devotee' WHERE Id = 3");
            Sql("UPDATE AccountTypes SET Name = 'Addict' WHERE Id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
