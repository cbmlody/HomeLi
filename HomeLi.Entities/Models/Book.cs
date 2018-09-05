using System;
using System.ComponentModel.DataAnnotations;

namespace HomeLi.Entities.Models
{
    public class Book
    {
        [Key]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "Title is Required.")]
        [StringLength(120, ErrorMessage = "Tittle can't be longer than 120 chars.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Author must be provided.")]
        public Guid AuthorId { get; set; }

        public virtual Author Author { get; set; }

        public Guid? SerieId { get; set; }

        public virtual Serie Serie { get; set; }

        [StringLength(13, MinimumLength = 10, ErrorMessage = "ISBN number must have at least 10 numbers and up to 13")]
        public string ISBN { get; set; }
    }
}