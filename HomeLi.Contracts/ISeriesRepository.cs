using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Contracts
{
    public interface ISeriesRepository : IRepositoryBase<Series>
    {
        /// <summary>
        /// Gets all series.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Series> GetAllSeries();

        /// <summary>
        /// Gets the series by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Series GetSeriesById(Guid id);

        /// <summary>
        /// Creates the series.
        /// </summary>
        /// <param name="series">The series.</param>
        void CreateSeries(Series series);

        /// <summary>
        /// Updates the series.
        /// </summary>
        /// <param name="dbSeries">The database series.</param>
        /// <param name="series">The series.</param>
        void UpdateSeries(Series dbSeries, Series series);

        /// <summary>
        /// Deletes the series.
        /// </summary>
        /// <param name="series">The series.</param>
        void DeleteSeries(Series series);
    }
}