using EmbraceSpace.Data;
using EmbraceSpace.Models.LaunchSiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbraceSpace.Services
{
    public class LaunchSiteService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        //create
        //test
        public bool CreateLaunchSite(LaunchSiteCreate model)
        {
            LaunchSite entity = new LaunchSite
            {
                Name = model.Name,
                Location = model.Location,
                CreatedUtc = DateTimeOffset.Now
            };
            _context.LaunchSites.Add(entity);
            return _context.SaveChanges() == 1;
        }
        //get all
        //test
        public List<LaunchSiteDetail> GetAllLaunchSites()
        {
            var launchSiteEntities = _context.LaunchSites.ToList();
            var launchSiteList = launchSiteEntities.Select(c => new LaunchSiteDetail
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location,
                CreatedUtc = c.CreatedUtc,
                ModifiedUtc = c.ModifiedUtc
            }).ToList();
            return launchSiteList;
        }
        //get (details by id)
        //test
        public LaunchSiteDetail GetLaunchSiteById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .LaunchSites
                        .Single(s => s.Id == id);
                return
                     new LaunchSiteDetail
                     {
                         Id = entity.Id,
                         Name = entity.Name,
                         Location = entity.Location,
                         CreatedUtc = entity.CreatedUtc
                     };
            }
        }
        //update
        //test
        public bool UpdateLaunchSite(LaunchSiteEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var oldData =
                    ctx
                    .LaunchSites
                    .Single(s => s.Id == model.Id);
                oldData.Id = model.Id;
                oldData.Name = model.Name;
                oldData.Location = model.Location;
                oldData.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete
        //test
        public bool DeleteLaunchSite(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var siteToDelete =
                    ctx
                    .LaunchSites
                    .Single(s => s.Id == id);
                if (siteToDelete != null)
                {
                    ctx.LaunchSites.Remove(siteToDelete);
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        //get by location (return a list)
        //test
        //public LaunchSiteDetail GetLaunchSiteByLocation(string location)
        //{
        //    var launchSiteEntity = _context.LaunchSites.Find(location);
        //    if (launchSiteEntity == null)
        //        return null;
        //    var detail = new LaunchSiteDetail
        //    {
        //        Id = launchSiteEntity.Id,
        //        Name = launchSiteEntity.Name,
        //        Location = launchSiteEntity.Location,
        //        CreatedUtc = launchSiteEntity.CreatedUtc
        //    };
        //    return detail;
        //}
    }
}
