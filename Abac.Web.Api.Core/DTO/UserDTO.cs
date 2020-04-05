using System;
using System.Collections.Generic;
using System.Text;

namespace Abac.Web.Api.Core.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpirationDate { get; set; }
        public string[] Roles { get; set; }
    }
}
