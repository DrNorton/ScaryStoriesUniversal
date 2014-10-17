using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Entity;
using ScaryStoriesUniversal.Dtos;

namespace ScaryStories.MobileService.Controllers
{
    [RoutePrefix("api/Photo")]
    public class PhotoController : ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ScaryStoriesContext();
        }

        [Route("GetItems")]
        public IQueryable<PhotoResponse> GetItems(int limit, int offset)
        {
            return _context.Photos.OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new PhotoResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                Id = x.Id,
                Thumb = x.Thumb 
            });
        }
        [Route("GetItem")]
        public PhotoResponse GetItem(string photoId)
        {
            return _context.Photos.Where(x => x.Id.ToString().Equals(photoId)).Select(x => new PhotoResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                Id = x.Id,
                Thumb = x.Thumb,
                Image = x.Image
               
            }).FirstOrDefault();
        }

    }
}

