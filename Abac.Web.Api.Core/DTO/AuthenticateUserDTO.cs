using System.ComponentModel.DataAnnotations;

namespace Abac.Web.Api.Core.DTO
{
    public class AuthenticateUserDTO
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
