using HomeLi.Contracts;
using HomeLi.Contracts.Repositories;
using HomeLi.Entities;

namespace HomeLi.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly LibraryContext _libraryContext;
        private IAuthorRepository _author;
        private IBookRepository _book;
        private ISeriesRepository _series;
        private IUserRepository _users;
        private ICategoryRepository _categories;
        private ILibraryRepository _libraries;

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

        public ICategoryRepository Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryRepository(_libraryContext);
                }
                return _categories;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_libraryContext);
                }
                return _users;
            }
        }

        public ILibraryRepository Libraries
        {
            get
            {
                if (_libraries == null)
                {
                    _libraries = new LibraryRepository(_libraryContext);
                }
                return _libraries;
            }
        }

        public RepositoryWrapper(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }
    }
}