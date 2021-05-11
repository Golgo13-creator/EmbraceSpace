using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Models.SpaceShipModels
{
    public class SpaceShipDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ship Name")]
        public string ShipName { get; set; }
        [Required]
        [Display(Name = "Crew Capacity")]
        public int CrewCapacity { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
