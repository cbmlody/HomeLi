using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeLi.Entities.ExtendedModels
{
    public class LibraryExtended : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public User Owner { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public LibraryExtended()
        {
        }

        public LibraryExtended(Library library)
        {
            Id = library.Id;
            Name = library.Name;
            Owner = library.Owner;
            Books = library.Books;
        }
    }
}
