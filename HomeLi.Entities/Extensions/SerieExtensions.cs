using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class SerieExtensions
    {
        public static void Map(this Series dbSeries, Series series)
        {
            dbSeries.AuthorId = series.AuthorId;
            dbSeries.Title = series.Title;
        }
    }
}