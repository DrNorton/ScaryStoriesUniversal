using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

using ScaryStoriesUniversal.Dtos;

namespace ScaryStoriesUniversal.Api
{
    public class ApiService
    {
        private MobileServiceClient _serviceClient;

        public ApiService(string url,string key)
        {
            if (String.IsNullOrEmpty(key))
            {
                _serviceClient = new MobileServiceClient(url);
            }
            else
            {
                _serviceClient = new MobileServiceClient(url, key);
            }
            
        }

        public  Task<IEnumerable<StoryResponse>> GetStories(int limit, int offset)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("limit", limit.ToString());
            pars.Add("offset", offset.ToString());

            return _serviceClient.InvokeApiAsync<IEnumerable<StoryResponse>>("Story/GetItems", HttpMethod.Get, pars);
        }

        public Task<IEnumerable<StoryResponse>> GetByCategory(Guid categoryId,int limit, int offset)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("categoryId", categoryId.ToString());
            pars.Add("limit", limit.ToString());
            pars.Add("offset", offset.ToString());

            return _serviceClient.InvokeApiAsync<IEnumerable<StoryResponse>>("Story/ByCategory", HttpMethod.Get, pars);
        }

        public Task<IEnumerable<StoryResponse>> GetBySourceId(Guid sourceId, int limit, int offset)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("sourceId", sourceId.ToString());
            pars.Add("limit", limit.ToString());
            pars.Add("offset", offset.ToString());

            return _serviceClient.InvokeApiAsync<IEnumerable<StoryResponse>>("Story/BySource", HttpMethod.Get, pars);
        }

        public Task<StoryResponse> GetStory(Guid storyId)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("storyId", storyId.ToString());


            return _serviceClient.InvokeApiAsync<StoryResponse>("Story/GetItem", HttpMethod.Get, pars);
        }

        public Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            return _serviceClient.InvokeApiAsync<IEnumerable<CategoryResponse>>("Category/GetItems",HttpMethod.Get,new Dictionary<string, string>());
        }

        public Task<IEnumerable<SourceResponse>> GetSources()
        {
            return _serviceClient.InvokeApiAsync<IEnumerable<SourceResponse>>("Source/GetItems", HttpMethod.Get, new Dictionary<string, string>());
        }

        public Task<IEnumerable<PhotoResponse>> GetPhotos(int limit, int offset)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("limit", limit.ToString());
            pars.Add("offset", offset.ToString());

            return _serviceClient.InvokeApiAsync<IEnumerable<PhotoResponse>>("Photo/GetItems", HttpMethod.Get, pars);
        }
        public Task<PhotoResponse> GetPhoto(Guid storyId)
        {
            var pars = new Dictionary<string, string>();
            pars.Add("photoId", storyId.ToString());


            return _serviceClient.InvokeApiAsync<PhotoResponse>("Photo/GetItem", HttpMethod.Get, pars);
        }

    }
}
