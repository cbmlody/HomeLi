using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Models;

namespace HomeLi.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }
    }
}