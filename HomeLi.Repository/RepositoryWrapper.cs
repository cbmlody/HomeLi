using HomeLi.Contracts;
using HomeLi.Entities;

namespace HomeLi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly LibraryContext _libraryContext;
        private IAuthorRepository _author;
        private IBookRepository _book;
        private ISeriesRepository _series;

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

        public ISeriesRepository Series
        {
            get
            {
                if (_series == null)
                {
                    _series = new SeriesRepository(_libraryContext);
                }
                return _series;
            }
        }

        public RepositoryWrapper(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
    }
}