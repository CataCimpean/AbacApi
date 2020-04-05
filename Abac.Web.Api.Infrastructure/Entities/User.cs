using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class User
    {
        public User()
        {
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpirationDate { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
