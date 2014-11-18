using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Entity;
using ScaryStoriesUniversal.Dtos;

namespace ScaryStories.MobileService.Controllers
{
    public class VideoController : TableController<Video>
    {
        private readonly ScaryStoriesContext _context;

        public VideoController(ScaryStoriesContext context)
        {
            _context = context;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            DomainManager = new EntityDomainManager<Video>(_context, Request, Services);
        }

        public IQueryable<VideoDto> GetAllTodoItems()
        {
            return Query().Select(x=>new VideoDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                Id = x.Id,
                Name = x.Name,
                SourceId = x.SourceId,
                Thumb = x.Thumb,
                UpdatedAt = x.UpdatedAt
            });
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Video> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Video> PatchTodoItem(string id, Delta<Video> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(Video item)
        {
            var current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteTodoItem(string id)
        {
            return DeleteAsync(id);
        }

    }
}
