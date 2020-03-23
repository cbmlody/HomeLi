using HomeLi.Entities.Models;

using System;
using System.Collections.Generic;

namespace HomeLi.Entities.ExtendedModels
{
    public class BookExtended : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN10 { get; set; }
        public string ISBN13 { get; set; }
        public Series Series {get; set;}

        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Category> Categories {get; set;}

        public BookExtended()
        {
        }

        public BookExtended(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            ISBN10 = book.ISBN10;
            ISBN13 = book.ISBN13;
            Series = book.Series;
            Authors = book.Authors;
            Categories = book.Categories;
        }
    }
}