using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class BookExtensions
    {
        public static void Map(this Book dbBook, Book book)
        {
            dbBook.Title = book.Title;
            dbBook.AuthorId = book.AuthorId;
            dbBook.SerieId = book.SerieId;
            dbBook.ISBN = book.ISBN;
        }
    }
}