using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;

namespace HomeLi.Contracts.Repositories
{
    public interface ILibraryRepository : IRepositoryBase<Library>
    {
        /// <summary>
        /// Get all libraries.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Library> GetAllLibraries();

        /// <summary>
        /// Get library by id.
        /// </summary>
        /// <param name="id">Library id.</param>
        /// <returns></returns>
        Library GetLibraryBy(Guid id);

        /// <summary>
        /// Create new library.
        /// </summary>
        /// <param name="library"></param>
        void CreateLibrary(Library library);

        /// <summary>
        /// Update library with new values.
        /// </summary>
        /// <param name="dbLibrary">The DB library.</param>
        /// <param name="library">The library.</param>
        void UpdateLibrary(Library dbLibrary, Library library);

        /// <summary>
        /// Deletes the library.
        /// </summary>
        /// <param name="library">The library.</param>
        void DeleteLibrary(Library library);
    }
}
