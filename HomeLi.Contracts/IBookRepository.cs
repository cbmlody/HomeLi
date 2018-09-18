using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        /// <summary>
        /// Gets all books.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetAllBooks();

        /// <summary>
        /// Gets the book by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Book GetBookById(Guid id);

        /// <summary>
        /// Creates the book.
        /// </summary>
        /// <param name="book">The book.</param>
        void CreateBook(Book book);

        /// <summary>
        /// Updates the book.
        /// </summary>
        /// <param name="dbBook">The database book.</param>
        /// <param name="book">The book.</param>
        void UpdateBook(Book dbBook, Book book);

        /// <summary>
        /// Deletes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        void DeleteBook(Book book);
    }
}