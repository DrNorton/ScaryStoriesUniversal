using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Dtos;
using ScaryStories.MobileService.Entity;

namespace ScaryStories.MobileService.Controllers
{
    public class CategoryController : ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ScaryStoriesContext();
        }

        public IQueryable<CategoryDto> GetAll()
        {
            return _context.Categories.Select(x=>new CategoryDto(){CreatedAt =x.CreatedAt,
                Deleted = x.Deleted,Description = x.Description,Id = x.Id,Name = x.Name,
                Thumb = x.Thumb,UpdatedAt = x.UpdatedAt,Version = x.Version});
        }

       
      
    }
}
