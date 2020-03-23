using HomeLi.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeLi.Entities.ExtendedModels
{
    public class UserExtended : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName {get;set;}
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public IEnumerable<Library> Libraries { get; set; }

        public UserExtended()
        {
        }

        public UserExtended(User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Email = user.Email;
            PhoneNumber = user.PhoneNumber;
            Libraries = user.Libraries;
        }
    }
}
