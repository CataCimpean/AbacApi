namespace Abac.Web.Api.Core.DTO
{
    public class ColonistPlanetDTO
    {
        public int PlanetId { get; set; }
        public string CaptainName { get; set; }
        public string Status { get; set; }
        public string PlanetName { get; set; }
        public string PlanetDescription { get; set; }
        public string PlanetImageUrl { get; set; }
        public string[] Robots { get; set; }
    }
}