using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScaryStoriesUniversal.Api;
using NUnit.Framework;
namespace ScaryStoriesUniversal.Api.Tests
{
    [TestFixture()]
    public class ApiServiceTests
    {
        private ApiService _apiService;

        [TestFixtureSetUp]
        public void SetUp()
        {
            //_apiService = new ApiService(@"http://storiesmobileservice.azure-mobile.net/", "tKroqvWTOqDmJGvBvowSrMSpGYFpGH69");
            _apiService = new ApiService(@"http://localhost:16781", null);
        }

        [Test()]
        public async  void GetStoriesTest()
        {
            var stories=await _apiService.GetStories(10,10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetByCategoryTest()
        {
            var stories = await _apiService.GetByCategory(Guid.NewGuid(),10,10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetBySourceIdTest()
        {
            var stories = await _apiService.GetBySourceId(Guid.Parse("201c6c54-469c-45e1-9e56-dd7086b6a8cb"), 10, 10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetStoryTest()
        {
            var stories = await _apiService.GetStory(Guid.Parse("0439c727-e29c-4009-96d2-d028c86bc89c"));
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetCategoriesTest()
        {
            var categories = await _apiService.GetCategories();
            Assert.IsNotNull(categories);
        }

        [Test()]
        public async void GetSourcesTest()
        {
            var sources = await _apiService.GetSources();
            Assert.IsNotNull(sources);
        }

        [Test()]
        public async void GetPhotosTest()
        {
            var photos = await _apiService.GetPhotos(10,10);
            Assert.IsNotNull(photos);
        }

        [Test()]
        public async void GetPhotoTest()
        {
            var photo = await _apiService.GetPhoto(Guid.Parse("022369e1-37c2-4461-b7cb-5df104312126"));
            Assert.IsNotNull(photo);
        }


    }
}
