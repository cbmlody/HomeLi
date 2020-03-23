using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLi.Entities.Models
{
    public class Category : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
