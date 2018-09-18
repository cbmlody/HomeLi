namespace HomeLi.Contracts
{
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the author repository.
        /// </summary>
        /// <value>
        /// The author repository.
        /// </value>
        IAuthorRepository Author { get; }

        /// <summary>
        /// Gets the book repository.
        /// </summary>
        /// <value>
        /// The book repository.
        /// </value>
        IBookRepository Book { get; }

        /// <summary>
        /// Gets the serie repository.
        /// </summary>
        /// <value>
        /// The serie repository.
        /// </value>
        ISerieRepository Serie { get; }
    }
}