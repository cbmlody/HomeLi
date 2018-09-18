using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Contracts
{
    public interface ISerieRepository : IRepositoryBase<Serie>
    {
        /// <summary>
        /// Gets all series.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Serie> GetAllSeries();

        /// <summary>
        /// Gets the serie by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Serie GetSerieById(Guid id);

        /// <summary>
        /// Creates the serie.
        /// </summary>
        /// <param name="serie">The serie.</param>
        void CreateSerie(Serie serie);

        /// <summary>
        /// Updates the serie.
        /// </summary>
        /// <param name="dbSerie">The database serie.</param>
        /// <param name="serie">The serie.</param>
        void UpdateSerie(Serie dbSerie, Serie serie);

        /// <summary>
        /// Deletes the serie.
        /// </summary>
        /// <param name="serie">The serie.</param>
        void DeleteSerie(Serie serie);
    }
}