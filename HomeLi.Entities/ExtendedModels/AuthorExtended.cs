using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Entities.ExtendedModels
{
    public class AuthorExtended : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public AuthorExtended()
        {
        }

        public AuthorExtended(Author author)
        {
            Id = author.Id;
            FirstName = author.FirstName;
            MiddleName = author.MiddleName;
            LastName = author.LastName;
        }
    }
}