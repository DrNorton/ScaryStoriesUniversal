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
            _apiService = new ApiService(@"https://storiesmobileservice.azure-mobile.net/", "eOxFathFeOfvquGBFoAZmDsGJuifQH42");
            //_apiService = new ApiService(@"http://localhost:16781", null);
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
            var stories = await _apiService.GetByCategory(Guid.NewGuid().ToString(),10,10);
            Assert.IsNull(stories);
        }

        [Test()]
        public async void GetBySourceIdTest()
        {
            var stories = await _apiService.GetBySourceId("201c6c54-469c-45e1-9e56-dd7086b6a8cb", 10, 10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetStoryTest()
        {
            var stories = await _apiService.GetStory("0439c727-e29c-4009-96d2-d028c86bc89c");
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
            var sources = await _apiService.GetSources(100,0);
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
            var photo = await _apiService.GetPhoto("022369e1-37c2-4461-b7cb-5df104312126");
            Assert.IsNotNull(photo);
        }

        [Test()]
        public async void FindStoriesTest()
        {
            var stories = await _apiService.FindStories("у", 10, 10);
            Assert.IsNotNull(stories);
        }

        [Test()]
        public async void GetVideosTest()
        {
            var videos = await _apiService.GetVideos(10, 10);
            Assert.IsNotNull(videos);
        }

        [Test()]
        public async void GetVideoTest()
        {

            var video = await _apiService.GetVideo("03529aa8-3962-46f9-a34a-ce934bffe647");
            Assert.IsNotNull(video);
        }

        [Test()]
        public async void GetVideosBySourceIdTest()
        {
            var videos = await _apiService.GetVideosBySourceId("0d654178-adc4-4100-b67f-8082f7f3e5d1", 10, 10);
            Assert.IsNotNull(videos);
        }

       

        //[Test()]
        //public async void LikeStoryTest()
        //{
        //    var story = await _apiService.GetStory(Guid.Parse("0439c727-e29c-4009-96d2-d028c86bc89c"));
        //    await _apiService.LikeStory(story);
        //    Assert.IsTrue(true);
        //}


    }
}
