using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class RoleType
    {
        public RoleType()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
