using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class ColonistPlanet
    {
        public int Id { get; set; }
        public int? ColonistId { get; set; }
        public int? PlanetId { get; set; }

        public virtual Colonist Colonist { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
