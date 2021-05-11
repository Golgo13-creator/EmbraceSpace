using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Data
{
    public class LaunchSite
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public virtual ICollection<StationOrigin> StationOrigins { get; set; } = new List<StationOrigin>();
        public virtual ICollection<ShipOrigin> ShipOrigins { get; set; } = new List<ShipOrigin>();
    }
}
