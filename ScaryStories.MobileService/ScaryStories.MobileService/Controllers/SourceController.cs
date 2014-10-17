using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using ScaryStories.MobileService.Entity;
using ScaryStoriesUniversal.Dtos;

namespace ScaryStories.MobileService.Controllers
{
    [RoutePrefix("api/Source")]
    public class SourceController:ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ScaryStoriesContext();

        }

        // GET tables/TodoItem
        [Route("GetItems")]
        public IQueryable<SourceResponse> GetItems()
        {
            return _context.Sources.Select(x => new SourceResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                Id = x.Id,
                Image = x.Image,
                Name=x.Name,
                Url = x.Url
            });
        }
    }
}