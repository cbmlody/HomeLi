using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class SeriesRepository : RepositoryBase<Series>, ISeriesRepository
    {
        public SeriesRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public IEnumerable<Series> GetAllSeries()
        {
            return FindAll()
                .OrderBy(series => series.Author.LastName)
                .ThenBy(series => series.Title);
        }

        public Series GetSeriesById(Guid id)
        {
            return FindByCondition(series => series.Id.Equals(id))
                .DefaultIfEmpty(new Series())
                .FirstOrDefault();
        }

        public void CreateSeries(Series series)
        {
            series.Id = Guid.NewGuid();
            Create(series);
            Save();
        }

        public void UpdateSeries(Series dbSeries, Series series)
        {
            dbSeries.Map(series);
            Update(dbSeries);
            Save();
        }

        public void DeleteSeries(Series series)
        {
            throw new NotImplementedException();
        }
    }
}