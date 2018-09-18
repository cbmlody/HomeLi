using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        /// <summary>
        /// Gets all authors.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Gets the author by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Author GetAuthorById(Guid id);

        /// <summary>
        /// Gets the author with details.
        /// </summary>
        /// <param name="authorId">The author identifier.</param>
        /// <returns></returns>
        AuthorExtended GetAuthorWithDetails(Guid authorId);

        /// <summary>
        /// Creates the author.
        /// </summary>
        /// <param name="author">The author.</param>
        void CreateAuthor(Author author);

        /// <summary>
        /// Updates the author.
        /// </summary>
        /// <param name="dbAuthor">The database author.</param>
        /// <param name="author">The author.</param>
        void UpdateAuthor(Author dbAuthor, Author author);

        /// <summary>
        /// Deletes the author.
        /// </summary>
        /// <param name="author">The author.</param>
        void DeleteAuthor(Author author);
    }
}