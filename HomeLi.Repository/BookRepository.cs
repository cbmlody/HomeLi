using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Models;

namespace HomeLi.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }
    }
}