using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Entity;

namespace ScaryStories.MobileService.Controllers
{
    public class PhotoController : ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ScaryStoriesContext();
        }

        public IQueryable<PhotoDto> GetAll(int limit, int offset)
        {
            return _context.Photos.OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new PhotoDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                Id = x.Id,
                Thumb = x.Thumb
            });
        }

        public IQueryable<PhotoDto> Get(string photoId)
        {
            return _context.Photos.Where(x=>x.Id.ToString().Equals(photoId)).Select(x => new PhotoDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                Id = x.Id,
                Thumb = x.Thumb,
                Image = x.Image
               
            });
        }

    }
}

