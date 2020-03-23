using HomeLi.Entities.Models;

namespace HomeLi.Entities.Extensions
{
    public static class LibraryExtensions
    {
        public static void Map(this Library dbLibrary, Library library)
        {
            dbLibrary.Name = library.Name;
            dbLibrary.Owner = library.Owner;
            dbLibrary.Books = library.Books;
        }
    }
}
