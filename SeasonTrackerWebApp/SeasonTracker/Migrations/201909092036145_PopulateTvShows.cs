namespace SeasonTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateTvShows : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 1, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 2, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 3, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 4, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 5, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 6, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 7, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 8, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 9, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 10, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 11, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Big Bang Theory', 12, 20)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 1, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 2, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 3, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 4, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 5, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 6, 10)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 7, 8)");
            Sql("INSERT INTO TvShows (TvShowName, SeasonNumber, NumberOfEpisodes) VALUES ('Game of Thrones', 8, 6)");

        }
        
        public override void Down()
        {
        }
    }
}
