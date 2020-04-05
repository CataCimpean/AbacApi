using System.ComponentModel.DataAnnotations;
using static Abac.Web.Api.Core.Helpers.AttributeHelper;

namespace Abac.Web.Api.Core.DTO
{
    public class PlanetDTO
    {
        [RequiredGreaterThanZero(ErrorMessage="Value for Id must be greater than > 0.")]
        public int Id { get; set; }

        public string Status { get; set; }

        [StringLength(50, ErrorMessage = "String Length must be smaller than 50 characters")]
        public string Name { get; set; }

        [StringLength(200,ErrorMessage="String Length must be smaller than 200 characters")]
        public string Description { get; set; }

        [StringLength(300, ErrorMessage = "String Length must be smaller than 300 characters")]
        public string ImageLink { get; set; }
    }
}
