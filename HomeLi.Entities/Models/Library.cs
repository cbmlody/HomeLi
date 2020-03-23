using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLi.Entities.Models
{
    public class Library : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(120, ErrorMessage = "Incorrect lenght of name. Should be between 3 and 120 chars.", MinimumLength = 3)]
        public string Name { get; set; }

        public User Owner { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
