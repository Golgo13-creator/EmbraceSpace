using EmbraceSpace.Data;
using EmbraceSpace.Models;
using EmbraceSpace.Models.SpaceStationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Services
{
    public class SpaceStationService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //create
        //test
        public bool CreateSpaceStation(SpaceStationCreate model)
        {
            SpaceStation entity = new SpaceStation
            {
                Name = model.Name,
                MaximumOccupancy = model.MaximumOccupancy,
                CreatedUtc = DateTimeOffset.Now
            };
            _context.SpaceStations.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all
        //test
        public List<SpaceStationDetail> GetAllSpaceStations()
        {
            var spaceStationEntities = _context.SpaceStations.ToList();
            var spaceStationList = spaceStationEntities.Select(s => new SpaceStationDetail
            {
                Id = s.Id,
                Name = s.Name,
                MaximumOccupancy = s.MaximumOccupancy,
                CreatedUtc = s.CreatedUtc
            }).ToList();
            return spaceStationList;
        }
        //get (details by id)
        //test
        public SpaceStationDetail GetSpaceStationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .SpaceStations
                        .Single(s => s.Id == id);
                return
                     new SpaceStationDetail
                     {
                         Id = entity.Id,
                         Name = entity.Name,
                         MaximumOccupancy = entity.MaximumOccupancy,
                         CreatedUtc = entity.CreatedUtc,
                         ModifiedUtc = entity.ModifiedUtc
                     };
            }
        }
        //update
        //test
        public bool UpdateSpaceStation(SpaceStationEdit newStationData)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var oldData =
                    ctx
                    .SpaceStations
                    .Single(s => s.Id == newStationData.Id);
                oldData.Id = newStationData.Id;
                oldData.Name = newStationData.Name;
                oldData.MaximumOccupancy = newStationData.MaximumOccupancy;
                oldData.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete
        //test
        public bool DeleteSpaceStation(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var stationToDelete =
                    ctx
                    .SpaceStations
                    .Single(s => s.Id == id);
                if (stationToDelete != null)
                {
                    ctx.SpaceStations.Remove(stationToDelete);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        //get by max occupants (return a list)
        //test
    }
}
