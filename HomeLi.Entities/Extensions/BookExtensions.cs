using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class BookExtensions
    {
        public static void Map(this Book dbBook, Book book)
        {
            dbBook.Title = book.Title;
            dbBook.ISBN10 = book.ISBN10;
            dbBook.ISBN13 = book.ISBN13;
            dbBook.Authors = book.Authors;
            dbBook.Series = book.Series;
            dbBook.Categories = book.Categories;
        }
    }
}