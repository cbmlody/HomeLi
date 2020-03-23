using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLi.Entities.Models
{
    public class Author : IEntity
    {
        [Key]
        [Column("AuthorId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(60, ErrorMessage = "First name can't be longer than 60 chars.")]
        public string FirstName { get; set; }

        [StringLength(60, ErrorMessage = "Middle name can't be longer than 60 chars.")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(60, ErrorMessage = "Last name can't be longer than 60 chars.")]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Series> Series { get; set; }
    }
}