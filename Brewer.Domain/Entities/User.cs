using System;
using System.Collections.Generic;

namespace Brewer.Domain.Entities
{
    public class User
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserGroup> Groups { get; set; }
    }
}
