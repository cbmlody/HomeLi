using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeLi.Entities.ExtendedModels
{
    public class CategoryExtended : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }

        public CategoryExtended()
        {
        }

        public CategoryExtended(Category category)
        {
            Id = category.Id;
            Name = category.Name;
            Books = category.Books;
        }
    }
}
