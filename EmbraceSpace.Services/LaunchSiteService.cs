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
        public List<LaunchSiteDetail> GetAllLaunchSites()
        {
            var launchSiteEntities = _context.LaunchSites.ToList();
            var launchSiteList = launchSiteEntities.Select(c => new LaunchSiteDetail
            {
                Id = c.Id,
                Name = c.Name,
                Location = c.Location,
                CreatedUtc = c.CreatedUtc
            }).ToList();
            return launchSiteList;
        }
        //get by name
        public LaunchSiteDetail GetLaunchSiteById(string name)
        {
            var launchSiteEntity = _context.LaunchSites.Find(name);
            if (launchSiteEntity == null)
                return null;
            var detail = new LaunchSiteDetail
            {
                Id = launchSiteEntity.Id,
                Name = launchSiteEntity.Name,
                Location = launchSiteEntity.Location,
                CreatedUtc = launchSiteEntity.CreatedUtc
            };
            return detail;
        }
        //get by location
        public LaunchSiteDetail GetLaunchSiteByLocation(string location)
        {
            var launchSiteEntity = _context.LaunchSites.Find(location);
            if (launchSiteEntity == null)
                return null;
            var detail = new LaunchSiteDetail
            {
                Id = launchSiteEntity.Id,
                Name = launchSiteEntity.Name,
                Location = launchSiteEntity.Location,
                CreatedUtc = launchSiteEntity.CreatedUtc
            };
            return detail;
        }
        //update
        public bool UpdateLaunchSite(LaunchSiteDetail newData)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var oldData =
                    ctx
                    .LaunchSites
                    .Single(s => s.Id == newData.Id);
                oldData.Id = newData.Id;
                oldData.Name = newData.Name;
                oldData.Location = newData.Location;
                oldData.CreatedUtc = newData.CreatedUtc;
                oldData.ModifiedUtc = DateTimeOffset.Now;
                return ctx.SaveChanges() == 1;
            }
        }
        //delete
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
    }
}
