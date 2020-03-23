using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeLi.Entities.Models
{
    public class User : IEntity
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<Library> Libraries {get; set;}
    }
}
