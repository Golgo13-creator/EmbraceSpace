using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Data
{
    public class ShipOrigin
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(SpaceShip))]
        public int ShipId { get; set; }
        public virtual SpaceShip SpaceShip { get; set; }
        [ForeignKey(nameof(LaunchSite))]
        public int LaunchSiteId { get; set; }
        public virtual LaunchSite LaunchSite { get; set; }
    }
}
