using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using ScaryStoriesUniversal.Api.Entities;

namespace ScaryStoriesUniversal.Api
{
    public interface IApiService
    {
        Task<IEnumerable<Story>> GetStories(int limit, int offset);
        Task<IEnumerable<Story>> GetByCategory(Guid categoryId,int limit, int offset);
        Task<IEnumerable<Story>> GetBySourceId(Guid sourceId, int limit, int offset);
        Task<Story> GetStory(Guid storyId);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Source>> GetSources();
        Task<IEnumerable<Photo>> GetPhotos(int limit, int offset);
        Task<Photo> GetPhoto(Guid storyId);
        MobileServiceClient ServiceClient { get; }
    }
}