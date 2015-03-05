using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ScaryStories.MobileService.Entity;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;

namespace StoryParser
{
    public class VkScaryParser
    {
        public void Get()
        {
            int res = 0;
            var scaryStories = new ScaryStoriesContext();
           //// InsertCategory(scaryStories);
          //  InsertSource(scaryStories);
            int appId = 3383873; // указываем id приложения
            string email = "kozak_andrews@mail.ru"; // email для авторизации
            string password = "rianon90"; // пароль
            Settings settings = Settings.Wall; // уровень доступа к данным

            var api = new VkApi();
            api.Authorize(appId, email, password, settings); // авторизуемся

            var category = scaryStories.Categories.FirstOrDefault();
            var source = scaryStories.Sources.FirstOrDefault(x => x.Id == "8c49ac0e-f541-40af-a556-e3c4651f0194");
            int totalCount;
            var wallTotal = api.Wall.Get(-40529013, out totalCount, 100);

            int count = 0;
            for (int j = 0; j < totalCount; j += 100)
            {

                int count2 = 0;
                var wall = api.Wall.Get(-40529013, out count2, 100, j);
                foreach (var post in wall)
                {
                    try
                    {
                        InsertStory(scaryStories, post, category, source);
                        res++;
                        Debug.WriteLine(res);
                    }
                    catch (Exception e)
                    {

                    }

                }

            }

            Console.WriteLine(res);
            
        }

        private void InsertSource(ScaryStoriesContext scaryStories)
        {
            scaryStories.Sources.Add(new Source()
            {
                Id = Guid.NewGuid().ToString(),

                Url = "https://vk.com/horror_tales",
                Name = "Страшные истории (horror_tales)",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\UBBFayZv4F0.jpg")
            });
            scaryStories.SaveChanges();
        }

        private void InsertStory(ScaryStoriesContext scaryStories, Post post, Category category, Source sources)
        {
            var index = post.Text.IndexOf("\n\n");
            string url = null;
            byte[] thumblBytes = null;
            byte[] imageBytes = null;
            if (index == -1)
            {
                return;
            }
            var header = post.Text.Substring(0, index);
            if (header.Length > 100) return;
            var text = post.Text.Substring(index + 2, post.Text.Length - index - 2);
            if (post.Attachment != null)
            {
                if (post.Attachment.Instance is VkNet.Model.Attachments.Photo)
                {
                    var photo = (VkNet.Model.Attachments.Photo)post.Attachment.Instance;
                    var thumbl = photo.Photo130;
                    var image = photo.Photo604;
                    var webClient = new WebClient();

                    thumblBytes = webClient.DownloadData(thumbl);
                    imageBytes = webClient.DownloadData(image);
                    url = String.Format("https://vk.com/photo{0}_{1}", photo.OwnerId, photo.Id);
                }
            }

            var photo2 = new ScaryStories.MobileService.Entity.Photo()
            {
                Id = Guid.NewGuid().ToString(),

                Image = imageBytes,
                Thumb = thumblBytes
            };
            var entity = new Story()
            {
                Category = category,
                Source = sources,



                Id = Guid.NewGuid().ToString(),
                Text = text,
                Name = header,

                Photo = photo2,
                Url = url

            };
            scaryStories.Stories.Add(entity);
            try
            {
                scaryStories.SaveChanges();
            }
            catch (Exception e)
            {

            }



        }

        private void InsertCategory(ScaryStoriesContext scaryStories)
        {
            var category = new Category()
            {
                Id = Guid.NewGuid().ToString(),
                Description = "",
                Name = "Страшные истории",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\UBBFayZv4F0.jpg")
            };

            scaryStories.Categories.Add(category);
            try
            {
                scaryStories.SaveChanges();

            }
            catch (Exception e)
            {

            }

        }
    }
}
