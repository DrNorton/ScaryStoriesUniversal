using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.WindowsAzure.Mobile.Service;
using ScaryStories.MobileService.Dtos;
using ScaryStories.MobileService.Entity;
using ScaryStories.MobileService.Entity.Entities;


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

        public IQueryable<StoryDto> GetAll(int limit,int offset)
        {
            return _context.Stories.OrderBy(x=>x.Id).Skip(offset).Take(limit).Select(x=>new StoryDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoDto() { Thumb = x.Photo.Thumb},
                Text = x.Text,
                Url = x.Text
            });
        }

        [Route("bycategory")]
        public IQueryable<StoryDto> GetByCategoryId(string categoryId,int limit,int offset)
        {
            return _context.Stories.Where(x => x.CategoryId.ToString().Equals(categoryId)).OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new StoryDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoDto() { Thumb = x.Photo.Thumb },
                Text = x.Text,
                Url = x.Text
            }); ;
        }

        [Route("bysource")]
        public IQueryable<StoryDto> GetBySourceId(string sourceId, int limit, int offset)
        {
            return _context.Stories.Where(x => x.SourceId.ToString().Equals(sourceId)).OrderBy(x => x.Id).Skip(offset).Take(limit).Select(x => new StoryDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoDto() { Thumb = x.Photo.Thumb },
                Text = x.Text,
                Url = x.Text
            }); ;
        }


        public StoryDto Get(string storyId)
        {
            return _context.Stories.Where(x => x.Id.ToString().Equals(storyId)).OrderBy(x => x.Id).Select(x => new StoryDto()
            {
                CreatedAt = x.CreatedAt,
                Deleted = x.Deleted,
                UpdatedAt = x.UpdatedAt,
                Version = x.Version,
                CategoryId = x.CategoryId,
                Id = x.Id,
                Name = x.Name,
                Photo = new PhotoDto() { Image = x.Photo.Image },
                Text = x.Text,
                Url = x.Text
            }).FirstOrDefault(); ;
        }
        

        // GET tables/TodoItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
       
    }
}