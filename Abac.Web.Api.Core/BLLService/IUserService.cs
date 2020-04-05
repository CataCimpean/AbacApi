using Abac.Web.Api.Core.DTO;
using System.Collections.Generic;

namespace Abac.Web.Api.Core.BLLService
{
    public interface IUserService
    {
        UserDTO Authenticate(string username, string password);
        IEnumerable<UserDTO> GetAll();
    }
}
