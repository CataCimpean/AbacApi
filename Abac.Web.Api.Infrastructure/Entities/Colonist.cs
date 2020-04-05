using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class Colonist
    {
        public Colonist()
        {
            ColonistPlanet = new HashSet<ColonistPlanet>();
        }

        public int Id { get; set; }
        public int? TypeId { get; set; }
        public string Name { get; set; }

        public virtual ColonistType Type { get; set; }
        public virtual ICollection<ColonistPlanet> ColonistPlanet { get; set; }
    }
}
