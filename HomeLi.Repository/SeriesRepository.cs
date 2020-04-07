using HomeLi.Contracts.Repositories;
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
                .OrderBy(series => series.Title)
                .ThenBy(series => series.Authors.Select(a => a.LastName));
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
            Delete(series);
            Save();
        }
    }
}