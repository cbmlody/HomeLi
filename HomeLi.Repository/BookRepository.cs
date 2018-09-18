using HomeLi.Contracts;
using HomeLi.Entities;
using HomeLi.Entities.Extensions;
using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLi.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(LibraryContext libraryContext) : base(libraryContext)
        {
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return FindAll()
                .OrderBy(book => book.Author.LastName)
                .ThenBy(book => book.Title);
        }

        public Book GetBookById(Guid id)
        {
            return FindByCondition(book => book.Id.Equals(id))
                .DefaultIfEmpty(new Book())
                .FirstOrDefault();
        }

        public void CreateBook(Book book)
        {
            book.Id = Guid.NewGuid();
            Create(book);
            Save();
        }

        public void UpdateBook(Book dbBook, Book book)
        {
            dbBook.Map(book);
            Update(dbBook);
            Save();
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
            Save();
        }
    }
}