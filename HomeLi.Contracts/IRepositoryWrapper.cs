using HomeLi.Contracts.Repositories;

namespace HomeLi.Contracts
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the author repository.
        /// </summary>
        IAuthorRepository Author { get; }

        /// <summary>
        /// Gets the book repository.
        /// </summary>
        IBookRepository Book { get; }

        /// <summary>
        /// Gets category repository.
        /// </summary>
        ICategoryRepository Categories {get;}

        /// <summary>
        /// Gets library repository.
        /// </summary>
        ILibraryRepository Libraries {get;}

        /// <summary>
        /// Gets the series repository.
        /// </summary>
        ISeriesRepository Series { get; }
        
        /// <summary>
        /// Gets
        /// </summary>
        IUserRepository Users {get;}
    }
}