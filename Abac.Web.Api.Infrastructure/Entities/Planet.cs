using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class Planet
    {
        public Planet()
        {
            ColonistPlanet = new HashSet<ColonistPlanet>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }

        public virtual ICollection<ColonistPlanet> ColonistPlanet { get; set; }
    }
}
