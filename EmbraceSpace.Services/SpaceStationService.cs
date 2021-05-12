using EmbraceSpace.Data;
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
        //get by name
        //test
        public SpaceStationDetail GetSpaceStationByName(string spaceStation)
        {
            var spaceStationEntity = _context.SpaceStations.Find(spaceStation);
            if (spaceStationEntity == null)
                return null;
            var spaceStationDetail = new SpaceStationDetail
            {
                Id = spaceStationEntity.Id,
                Name = spaceStationEntity.Name,
                MaximumOccupancy = spaceStationEntity.MaximumOccupancy,
                CreatedUtc = spaceStationEntity.CreatedUtc
            };
            return spaceStationDetail;
        }
        //get by max occupants (return a list)
        //test

        //update
        //test
        public bool UpdateSpaceStation(SpaceStationDetail newStationData)
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
                oldData.CreatedUtc = newStationData.CreatedUtc;
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
    }
}
