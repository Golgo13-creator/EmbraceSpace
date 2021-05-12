using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Models.SpaceStationModels
{
    public class SpaceStationCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaximumOccupancy { get; set; }
    }
}
