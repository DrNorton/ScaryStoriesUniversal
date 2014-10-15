using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.Attachments;


namespace StoryParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Get();
        }

        private async void Get()
        {
            int res = 0;
            var scaryStories = new scaryStoriesEntities();
           InsertCategory(scaryStories);
           InsertSource(scaryStories);
            int appId = 3383873; // указываем id приложения
            string email = "kozak_andrews@mail.ru"; // email для авторизации
            string password = "rianon90"; // пароль
            Settings settings = Settings.Wall; // уровень доступа к данным

            var api = new VkApi();
            api.Authorize(appId, email, password, settings); // авторизуемся

            var category = scaryStories.Categories.FirstOrDefault();
            var source = scaryStories.Sources.FirstOrDefault();
            int totalCount;
            var wallTotal=api.Wall.Get(-40529013, out totalCount, 100);

            int count = 0;
            for (int j = 0; j < totalCount; j += 100)
            {
                
                    int count2 = 0;
                    var wall = api.Wall.Get(-40529013, out count2, 100,j);
                foreach (var post in wall)
                {
                    try
                    {
                        InsertStory(scaryStories, post, category, source);
                        res++;
                    }
                    catch (Exception e)
                    {
                        
                    }
             
                }
                
            }
          
            Console.WriteLine(res);
            
        }

        private void InsertCategory(scaryStoriesEntities scaryStories)
        {
            scaryStories.Categories.Add(new Categories()
            {
                Id=Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Description = "",
                Name = "Страшные истории",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\UBBFayZv4F0.jpg")
            });
            try
            {
                scaryStories.SaveChanges();

            }
            catch (Exception e)
            {
                
            }
           
        }
        private void InsertSource(scaryStoriesEntities scaryStories)
        {
            scaryStories.Sources.Add(new Sources()
            {
                Id = Guid.NewGuid(),
                CreatedAt = DateTime.Now,
                Url = "https://vk.com/horror_tales",
                Name = "Страшные истории (horror_tales)",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\UBBFayZv4F0.jpg")
            });
            scaryStories.SaveChanges();
        }

        private void InsertStory(scaryStoriesEntities scaryStories,Post post,Categories category,Sources sources)
        {
            var index = post.Text.IndexOf("\n\n");
            string url = null;
            byte[] thumblBytes = null;
            byte[] imageBytes=null;
            if (index == -1)
            {
                return;
            }
            var header = post.Text.Substring(0, index);
            if(header.Length>100)return;
            var text = post.Text.Substring(index+2, post.Text.Length - index-2);
            if (post.Attachment != null)
            {
                if (post.Attachment.Instance is Photo)
                {
                    var photo = (Photo)post.Attachment.Instance;
                    var thumbl = photo.Photo130;
                    var image = photo.Photo604;
                    var webClient = new WebClient();

                   thumblBytes = webClient.DownloadData(thumbl);
                   imageBytes = webClient.DownloadData(image);
                   url = String.Format("https://vk.com/photo{0}_{1}", photo.OwnerId, photo.Id);
                }
            }
            scaryStories.Stories.Add(new Stories()
            {
                Categories = category,
                Sources = sources,
                CreatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                Text = text,
                Name = header,
                Photos = new Photos() { Id = Guid.NewGuid(), CreatedAt = DateTime.Now, Image = imageBytes, Thumb = thumblBytes },
                Url=url
            
            });
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
