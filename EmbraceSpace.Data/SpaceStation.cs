using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Data
{
    public class SpaceStation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumOccupancy { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual ICollection<StationOrigin> StationOrigins { get; set; } = new List<StationOrigin>();
    }
}
