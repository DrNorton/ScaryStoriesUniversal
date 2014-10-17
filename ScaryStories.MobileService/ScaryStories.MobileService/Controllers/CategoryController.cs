using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ScaryStories.MobileService.Entity;
using ScaryStoriesUniversal.Dtos;

namespace ScaryStories.MobileService.Controllers
{
    [RoutePrefix("api/Category")]
    public class CategoryController : ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            _context = new ScaryStoriesContext();
        }

        [Route("GetItems")]
        public IQueryable<CategoryResponse> GetAll()
        {
            return _context.Categories.Select(x => new CategoryResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,Description = x.Description,Id = x.Id,Name = x.Name,
                Thumb = x.Thumb,UpdatedAt = x.UpdatedAt,Version = x.Version});
        }

       
      
    }
}
