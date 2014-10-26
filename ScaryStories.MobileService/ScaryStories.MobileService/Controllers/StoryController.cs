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
using ScaryStories.MobileService.Entity.Entities;
using ScaryStoriesUniversal.Dtos;

namespace ScaryStories.MobileService.Controllers
{
    public class StoryController : TableController<Story>
    {
        private readonly ScaryStoriesContext _context;

        public StoryController(ScaryStoriesContext context)
        {
            _context = context;
        }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
         
            DomainManager = new EntityDomainManager<Story>(_context, Request, Services);
        }

        // GET tables/TodoItem
        public IQueryable<Story> GetAllTodoItems()
        {
            return Query();
        }

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Story> GetTodoItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Story> PatchTodoItem(string id, Delta<Story> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/TodoItem
        public async Task<IHttpActionResult> PostTodoItem(Story item)
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
