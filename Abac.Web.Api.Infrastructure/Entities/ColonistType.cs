using System;
using System.Collections.Generic;

namespace Abac.Web.Api.Infrastructure.Entities
{
    public partial class ColonistType
    {
        public ColonistType()
        {
            Colonist = new HashSet<Colonist>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Colonist> Colonist { get; set; }
    }
}
