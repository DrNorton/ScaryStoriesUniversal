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
            var stories = await _apiService.GetBySourceId(Guid.NewGuid(), 10, 10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetStoryTest()
        {
            var stories = await _apiService.GetStory(Guid.Parse("c82e20ab-5e2b-485f-8840-04a571b6c8d3"));
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
            var photo = await _apiService.GetPhoto(Guid.Parse("faa400df-d6b4-4100-a541-017a5c804d38"));
            Assert.IsNotNull(photo);
        }


    }
}
