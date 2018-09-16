using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Contracts
{
    public interface IAuthorRepository : IRepositoryBase<Author>
    {
        IEnumerable<Author> GetAllAuthors();

        Author GetAuthorById(Guid id);

        AuthorExtended GetAuthorWithDetails(Guid authorId);

        void CreateAuthor(Author author);

        void UpdateAuthor(Author dbAuthor, Author author);

        void DeleteAuthor(Author author);
    }
}