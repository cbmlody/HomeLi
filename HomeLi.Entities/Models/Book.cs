using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLi.Entities.Models
{
    public class Book : IEntity
    {
        [Key]
        [Column("BookID")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is Required.")]
        [StringLength(120, ErrorMessage = "Tittle can't be longer than 120 chars.")]
        public string Title { get; set; }

        [StringLength(10, ErrorMessage = "ISBN 10 must have 10 digits.")]
        public string ISBN10 { get; set; }

        [StringLength(13, ErrorMessage = "ISBN 13 must have 13 digits.")]
        public string ISBN13 { get; set; }

        public virtual ICollection<Author> Authors { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
        public virtual Series Series { get; set; }
    }
}