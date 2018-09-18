using HomeLi.Entities.Models;

using System;

namespace HomeLi.Entities.ExtendedModels
{
    public class BookExtended : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public Guid? SerieId { get; set; }
        public virtual Serie Serie { get; set; }
        public string ISBN { get; set; }

        public BookExtended()
        {
        }

        public BookExtended(Book book)
        {
            Id = book.Id;
            Title = book.Title;
            AuthorId = book.AuthorId;
            SerieId = book.SerieId;
            ISBN = book.ISBN;
        }
    }
}