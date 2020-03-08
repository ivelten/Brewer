using System.Collections.Generic;

namespace Brewer.Domain.Entities
{
    public class UserGroup
    {
        public string Name { get; set; }

        public ICollection<Permission> Permissions { get; set; }
    }
}
