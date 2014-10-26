using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using ScaryStoriesUniversal.Api.Entities;

namespace ScaryStoriesUniversal.Api
{
    public class ApiService : IApiService
    {
        private MobileServiceClient _serviceClient;
        private IMobileServiceTable<Story> _storyTable;
        private IMobileServiceTable<Category> _categoryTable;
        private IMobileServiceTable<Source> _sourceTable;
        private IMobileServiceTable<Photo> _photoTable;

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
            _storyTable = _serviceClient.GetTable<Story>();
            _categoryTable = _serviceClient.GetTable<Category>();
            _sourceTable = _serviceClient.GetTable<Source>();
            _photoTable = _serviceClient.GetTable<Photo>();
        }

       

        public MobileServiceClient ServiceClient
        {
            get { return _serviceClient; }
        }

        public  async Task<IEnumerable<Story>> GetStories(int limit, int offset)
        {
            return await _storyTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
        }

        public async Task<IEnumerable<Story>> GetByCategory(Guid categoryId,int limit, int offset)
        {
            return await _storyTable.Where(x => x.CategoryId.ToString() == categoryId.ToString()).OrderBy(x => x.CreatedAt).Take(limit).Skip(offset).ToCollectionAsync();
        }

        public async Task<IEnumerable<Story>> GetBySourceId(Guid sourceId, int limit, int offset)
        {
            return await _storyTable.Where(x => x.SourceId.ToString() == sourceId.ToString()).OrderBy(x => x.CreatedAt).Take(limit).Skip(offset).ToCollectionAsync(); ;
        }

        public Task<Story> GetStory(Guid storyId)
        {
            return  _storyTable.LookupAsync(storyId);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryTable.Take(100).ToCollectionAsync();
        }

        public async Task<IEnumerable<Source>> GetSources()
        {
            return await _sourceTable.Take(100).ToCollectionAsync();
            
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int limit, int offset)
        {
            return await _photoTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
        }
        public Task<Photo> GetPhoto(Guid storyId)
        {
            return _photoTable.LookupAsync(storyId);
        }

    }
}
