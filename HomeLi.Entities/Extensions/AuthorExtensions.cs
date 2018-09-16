using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class AuthorExtensions
    {
        public static void Map(this Author dbAuthor, Author author)
        {
            dbAuthor.FirstName = author.FirstName;
            dbAuthor.MiddleName = author.MiddleName;
            dbAuthor.LastName = author.LastName;
            dbAuthor.Books = author.Books;
        }
    }
}