using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.ExtendedModels;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return FindAll()
                .OrderBy(author => author.LastName);
        }

        public Author GetAuthorById(Guid id)
        {
            return FindByCondition(author => author.Id.Equals(id))
                .DefaultIfEmpty(new Author())
                .FirstOrDefault();
        }

        public AuthorExtended GetAuthorWithDetails(Guid authorId)
        {
            return new AuthorExtended(GetAuthorById(authorId))
            {
                Books = LibraryContext.Books
                    .Where(b => b.AuthorId == authorId)
            };
        }

        public void CreateAuthor(Author author)
        {
            author.Id = Guid.NewGuid();
            Create(author);
            Save();
        }

        public void UpdateAuthor(Author dbAuthor, Author author)
        {
            dbAuthor.Map(author);
            Update(dbAuthor);
            Save();
        }

        public void DeleteAuthor(Author author)
        {
            Delete(author);
            Save();
        }
    }
}