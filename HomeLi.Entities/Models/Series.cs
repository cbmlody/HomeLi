using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLi.Entities.Models
{
    public class Series : IEntity
    {
        [Key]
        [Column("SeriesID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Series must have a title.")]
        [StringLength(120, ErrorMessage = "Title can't have more than 120 chars.")]
        public string Title { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
    }
}