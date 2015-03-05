using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.YouTube;
using ScaryStories.MobileService.Entity;

namespace StoryParser
{
    public class YoutubeVideoParser
    {
        private List<string> _linksYoutube;
        private ScaryStoriesContext _scaryStories;
        
        public List<string> LinksYoutube
        {
            get { return _linksYoutube; }
            set { _linksYoutube = value; }
        }

        public void GetGrobovshik()
        {
                _scaryStories=new ScaryStoriesContext();
                var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
                var request = new YouTubeRequest(settings);
                var sourceId = InsertGrobovshikSource();
                Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("TheUndertakerHorror");
                foreach (Playlist p in userPlaylists.Entries)
                {
                    var list = request.GetPlaylist(p).Entries;
                    foreach (var video in list)
                    {
                        SaveVideo(video,sourceId);
                    }
                    //some code
                }
            
        }

        public void GetSecretVision()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);
            var sourceId = InsertSecretSource();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("SecretVisionpr");
            foreach (Playlist p in userPlaylists.Entries)
            {
                var list = request.GetPlaylist(p).Entries;
                foreach (var video in list)
                {
                    SaveVideo(video, sourceId);
                }
                //some code
            }

        }

        public void GetVanjuha()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);
           
            var sourceId = InsertVanjuhaSource();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("VanyuhaHorrorGames");
            foreach (Playlist p in userPlaylists.Entries)
            {
                if (p.Title.Contains("Страшные"))
                {
                    var list = request.GetPlaylist(p).Entries;
                    foreach (var video in list)
                    {
                        SaveVideo(video, sourceId);
                    }
                }
               
                //some code
            }
        }

        public void GetFrankestein()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);

            var sourceId = InsertFrankesteinSource();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("MrFrankenstein777");
            foreach (Playlist p in userPlaylists.Entries)
            {
               
                    var list = request.GetPlaylist(p).Entries;
                    foreach (var video in list)
                    {
                        SaveVideo(video, sourceId);
                    }
                

                //some code
            }
        }

        public void GetKotBegemot()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);

            var sourceId = InsertKotBegemotSource();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("DesertFox6211");
            foreach (Playlist p in userPlaylists.Entries)
            {

                var list = request.GetPlaylist(p).Entries;
                foreach (var video in list)
                {
                    SaveVideo(video, sourceId);
                }


                //some code
            }
        }

       
        public void GetTheWorldOfHorror1()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);

            var sourceId = InsertGetTheWorldOfHorror();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("TheWorldOfHorror1");
            foreach (Playlist p in userPlaylists.Entries)
            {

                var list = request.GetPlaylist(p).Entries;
                foreach (var video in list)
                {
                    SaveVideo(video, sourceId);
                }


                //some code
            }
        }
        public void GetGameChannelLeo()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);
           
            var sourceId = InsertGetGameChannelLeo();
            var ds = request.GetVideoFeed("GameChannelLeo").Entries;
            Debug.WriteLine(ds);
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("GameChannelLeo");
       
                foreach (var video in ds)
                {
                    
                    SaveVideo(video, sourceId);
                }


                //some code
            
        }

        public void Placebolikeanart()
        {
            _scaryStories = new ScaryStoriesContext();
            var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
            var request = new YouTubeRequest(settings);

            var sourceId = Insertplacebolikeanart();
            Feed<Playlist> userPlaylists = request.GetPlaylistsFeed("placebolikeanart");
            foreach (Playlist p in userPlaylists.Entries)
            {
                if (p.Title.Contains("Страшные"))
                {
                    var list = request.GetPlaylist(p).Entries;
                    foreach (var video in list)
                    {
                        SaveVideo(video, sourceId);
                    }
                }
               


                //some code
            }
        }

        private string Insertplacebolikeanart()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "http://www.youtube.com/user/placebolikeanart",
                Name = "Entertainment channeL",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo9.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }


        private string InsertGetGameChannelLeo()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "http://www.youtube.com/user/GameChannelLeo",
                Name = "GameChannelLeo",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo8.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private string InsertGetTheWorldOfHorror()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "http://www.youtube.com/user/TheWorldOfHorror1",
                Name = "TheWorldOfHorror1",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo7.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }
        private string InsertKotBegemotSource()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "http://www.youtube.com/user/DesertFox6211",
                Name = " Страшные истории от Кота Бегемота",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo6.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private string InsertGrobovshikSource()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,

                Url = "http://www.youtube.com/user/TheUndertakerHorror",
                Name = "Гробовщик Хоррор",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private string InsertSecretSource()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "https://www.youtube.com/user/SecretVisionpr",
                Name = "Secret Vision",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo2.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private string InsertFrankesteinSource()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "https://www.youtube.com/user/MrFrankenstein777",
                Name = "MrFrankenstein777",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo4.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private string InsertVanjuhaSource()
        {
            var id = Guid.NewGuid().ToString();
            _scaryStories.Sources.Add(new Source()
            {
                Id = id,
                Url = "https://www.youtube.com/user/VanyuhaHorrorGames",
                Name = "VanyuhaHorrorGames",
                Image = File.ReadAllBytes(@"C:\Users\WinPhone\Desktop\photo3.jpg")
            });
            _scaryStories.SaveChanges();
            return id;
        }

        private void SaveVideo(PlayListMember video,string sourceId)
        {
            var vid = new ScaryStories.MobileService.Entity.Video();
            vid.ChannalName = video.Author;
            vid.SourceId = sourceId;
            vid.CreatedAt = DateTime.Now;
            vid.Id = Guid.NewGuid().ToString();
            vid.Name = video.Title;
            vid.Text = video.Description;
            var thumb = video.Thumbnails.ElementAt(1);
            if (thumb != null)
            {
                vid.Thumb = new WebClient().DownloadData(thumb.Url);
                
            }
            var image = video.Thumbnails.ElementAt(2);
            if (image != null)
            {
                vid.Image = new WebClient().DownloadData(image.Url);
            }
            vid.Url = video.WatchPage.ToString();
            _scaryStories.Videos.Add(vid);
            _scaryStories.SaveChanges();
        }

        private void SaveVideo(Google.YouTube.Video video, string sourceId)
        {
            var vid = new ScaryStories.MobileService.Entity.Video();
            vid.ChannalName = video.Author;
            vid.SourceId = sourceId;
            vid.CreatedAt = DateTime.Now;
            vid.Id = Guid.NewGuid().ToString();
            vid.Name = video.Title;
            vid.Text = video.Description;
            var thumb = video.Thumbnails.ElementAt(1);
            if (thumb != null)
            {
                vid.Thumb = new WebClient().DownloadData(thumb.Url);

            }
            var image = video.Thumbnails.ElementAt(2);
            if (image != null)
            {
                vid.Image = new WebClient().DownloadData(image.Url);
            }
            vid.Url = video.WatchPage.ToString();
            _scaryStories.Videos.Add(vid);
            _scaryStories.SaveChanges();
        }
    }
}
