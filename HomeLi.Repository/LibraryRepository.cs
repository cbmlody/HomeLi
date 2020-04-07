using HomeLi.Contracts.Repositories;
using HomeLi.Entities;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class LibraryRepository : RepositoryBase<Library>, ILibraryRepository
    {
        public LibraryRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }
        
        public IEnumerable<Library> GetAllLibraries()
        {
            return FindAll();
        }

        public Library GetLibraryById(Guid id)
        {
            return FindByCondition(library => library.Id.Equals(id))
                .DefaultIfEmpty(new Library())
                .FirstOrDefault();
        }

        public void CreateLibrary(Library library)
        {
            library.Id = Guid.NewGuid();
            Create(library);
            Save();
        }
        
        public void UpdateLibrary(Library dbLibrary, Library library)
        {
            dbLibrary.Map(library);
            Update(dbLibrary);
            Save();
        }

        public void DeleteLibrary(Library library)
        {
            Delete(library);
            Save();
        }
    }
}
