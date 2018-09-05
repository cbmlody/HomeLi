using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLi.Entities.Models
{
    public class Serie
    {
        [Key]
        public Guid SerieId { get; set; }

        [Required(ErrorMessage = "Serie must have a title.")]
        [StringLength(120, ErrorMessage = "Title can't have more than 120 chars.")]
        public string Title { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        [Required(ErrorMessage = "Serie must have an Author")]
        public Guid AuthorId { get; set; }

        public Author Author { get; set; }
    }
}