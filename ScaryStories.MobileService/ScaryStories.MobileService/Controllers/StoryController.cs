using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using ScaryStories.MobileService.Entity;
using ScaryStoriesUniversal.Dtos;


namespace ScaryStories.MobileService.Controllers
{
    [RoutePrefix("api/Story")]
    public class StoryController : ApiController
    {
        private ScaryStoriesContext _context;

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
           
            _context = new ScaryStoriesContext();
           
        }

        // GET tables/TodoItem
        [Route("GetItems")]
        public IQueryable<StoryResponse> GetItems(int limit,int offset)
        {
            return _context.Stories.OrderBy(x=>x.Id).Skip(offset).Take(limit).Select(x=>new StoryResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoResponse() { Thumb = x.Photo.Thumb},
                Text = x.Text,
                Url = x.Text
            });
        }

        [Route("ByCategory")]
        public IQueryable<StoryResponse> GetByCategoryId(string categoryId, int limit, int offset)
        {
            return _context.Stories.Where(x => x.CategoryId.ToString().Equals(categoryId)).OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new StoryResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoResponse() { Thumb = x.Photo.Thumb },
                Text = x.Text,
                Url = x.Text
            }); ;
        }

        [Route("BySource")]
        public IQueryable<StoryResponse> GetBySourceId(string sourceId, int limit, int offset)
        {
            return _context.Stories.Where(x => x.SourceId.ToString().Equals(sourceId)).OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new StoryResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoResponse() { Thumb = x.Photo.Thumb },
                Text = x.Text,
                Url = x.Text
            }); ;
        }

        [Route("GetItem")]
        public StoryResponse GetItem(string storyId)
        {
            return _context.Stories.Where(x => x.Id.ToString().Equals(storyId)).OrderBy(x => x.Id).Select(x => new StoryResponse()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoResponse() { Image = x.Photo.Image },
                Text = x.Text,
                Url = x.Text
            }).FirstOrDefault(); ;
        }
        

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
       
    }
}