using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class SerieRepository : RepositoryBase<Serie>, ISerieRepository
    {
        public SerieRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public IEnumerable<Serie> GetAllSeries()
        {
            return FindAll()
                .OrderBy(serie => serie.Author.LastName)
                .ThenBy(serie => serie.Title);
        }

        public Serie GetSerieById(Guid id)
        {
            return FindByCondition(serie => serie.Id.Equals(id))
                .DefaultIfEmpty(new Serie())
                .FirstOrDefault();
        }

        public void CreateSerie(Serie serie)
        {
            serie.Id = Guid.NewGuid();
            Create(serie);
            Save();
        }

        public void UpdateSerie(Serie dbSerie, Serie serie)
        {
            dbSerie.Map(serie);
            Update(dbSerie);
            Save();
        }

        public void DeleteSerie(Serie serie)
        {
            throw new NotImplementedException();
        }
    }
}