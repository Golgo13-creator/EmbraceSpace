using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Models.SpaceStationModels
{
    public class SpaceStationDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaximumOccupancy { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
