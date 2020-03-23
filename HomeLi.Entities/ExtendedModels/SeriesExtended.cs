using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;

namespace HomeLi.Entities.ExtendedModels
{
    public class SeriesExtended : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}
