using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class SerieExtensions
    {
        public static void Map(this Series dbSeries, Series series)
        {
            dbSeries.Title = series.Title;
            dbSeries.Authors = series.Authors;
            dbSeries.Books = series.Books;
        }
    }
}