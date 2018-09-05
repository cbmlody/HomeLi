using HomeLi.Contracts;
using HomeLi.Entities;

namespace HomeLi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private LibraryContext _libraryContext;
        private IAuthorRepository _author;
        private IBookRepository _book;
        private ISerieRepository _serie;

        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_libraryContext);
                }
                return _author;
            }
        }

        public IBookRepository Book
        {
            get
            {
                if (_book == null)
                {
                    _book = new BookRepository(_libraryContext);
                }
                return _book;
            }
        }

        public ISerieRepository Serie
        {
            get
            {
                if (_serie == null)
                {
                    _serie = new SerieRepository(_libraryContext);
                }
                return _serie;
            }
        }

        public RepositoryWrapper(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
    }
}