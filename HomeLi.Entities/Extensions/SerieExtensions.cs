using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class SerieExtensions
    {
        public static void Map(this Serie dbSerie, Serie serie)
        {
            dbSerie.AuthorId = serie.AuthorId;
            dbSerie.Title = serie.Title;
        }
    }
}