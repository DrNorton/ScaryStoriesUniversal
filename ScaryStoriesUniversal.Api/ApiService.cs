using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using ScaryStoriesUniversal.Api.Entities;

namespace ScaryStoriesUniversal.Api
{
    public class ApiService : IApiService
    {
        public delegate void ErrorHandled(Exception e);
        public event ErrorHandled OnErrorHandled;


        private MobileServiceClient _serviceClient;
        private IMobileServiceTable<Story> _storyTable;
        private IMobileServiceTable<Category> _categoryTable;
        private IMobileServiceTable<Source> _sourceTable;
        private IMobileServiceTable<Photo> _photoTable;
        private IMobileServiceTable<Video> _videoTable;

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
            _videoTable = _serviceClient.GetTable<Video>();
        }

        public MobileServiceClient ServiceClient
        {
            get { return _serviceClient; }
        }

        private void CallExceptionHandler(Exception e)
        {
            if (OnErrorHandled != null)
            {
                OnErrorHandled(e);
            }
        }

        public  async Task<IEnumerable<Story>> GetStories(int limit, int offset)
        {
            try
            {
                return await _storyTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
            }
            catch (Exception e)
            {
               CallExceptionHandler(e);
               return null;
            }
        }

        public async Task<IEnumerable<Story>> FindStories(string search,int limit, int offset)
        {
            try
            {
                return await _storyTable.OrderBy(x => x.CreatedAt).Where(x => x.Name.Contains(search)).Skip(offset).Take(limit).ToCollectionAsync();
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }

            
        }

        public async Task<IEnumerable<Story>> GetByCategory(string categoryId,int limit, int offset)
        {
            try
            {
                return await _storyTable.Where(x => x.CategoryId.ToString() == categoryId.ToString()).OrderBy(x => x.CreatedAt).Take(limit).Skip(offset).ToCollectionAsync();
            }

            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public async Task<IEnumerable<Story>> GetBySourceId(string sourceId, int limit, int offset)
        {
            try
            {
                return await _storyTable.OrderBy(x => x.CreatedAt).Where(x => x.SourceId == sourceId).Skip(offset).Take(limit).IncludeTotalCount().ToCollectionAsync(); ;

            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public async Task<IEnumerable<Video>> GetVideosBySourceId(string sourceId, int limit, int offset)
        {
            try
            {
                return await _videoTable.OrderBy(x => x.CreatedAt).Where(x => x.SourceId == sourceId).Skip(offset).Take(limit).IncludeTotalCount().ToCollectionAsync(); 
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public Task<Story> GetStory(string storyId)
        {
            try
            {
                return _storyTable.LookupAsync(storyId);
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            try
            {
                return await _categoryTable.Take(100).ToListAsync();
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public async Task<IEnumerable<Source>> GetSources(int limit, int offset)
        {
            try
            {
                return await _sourceTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int limit, int offset)
        {
            try
            {
                return await _photoTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }
        public Task<Photo> GetPhoto(string storyId)
        {
            try
            {
                return _photoTable.LookupAsync(storyId);
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
            
        }

        public async Task<IEnumerable<Video>> GetVideos(int limit, int offset)
        {
            try
            {
                return await _videoTable.OrderBy(x => x.CreatedAt).Skip(offset).Take(limit).ToCollectionAsync();
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public Task<Video> GetVideo(string videoId)
        {
            try
            {
                return _videoTable.LookupAsync(videoId);
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

        public Task<Source> GetSource(string sourceId)
        {
            try
            {
                return _sourceTable.LookupAsync(sourceId);
            }
            catch (Exception e)
            {
                CallExceptionHandler(e);
                return null;
            }
        }

       
    }
}
