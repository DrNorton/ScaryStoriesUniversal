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
        Task<IEnumerable<Story>> GetByCategory(string categoryId,int limit, int offset);
        Task<IEnumerable<Story>> GetBySourceId(string sourceId, int limit, int offset);
        Task<Story> GetStory(string storyId);
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Source>> GetSources(int limit, int offset);
        Task<IEnumerable<Photo>> GetPhotos(int limit, int offset);
        Task<Photo> GetPhoto(string storyId);
        MobileServiceClient ServiceClient { get; }
        Task<IEnumerable<Story>> FindStories(string search,int limit, int offset);
        Task<IEnumerable<Video>> GetVideos(int limit, int offset);
        Task<Video> GetVideo(string videoId);
        Task<Source> GetSource(string sourceId);
        Task<IEnumerable<Video>> GetVideosBySourceId(string sourceId, int limit, int offset);
    }
}