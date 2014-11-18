using System;
using System.Collections.Generic;
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

        public void Get()
        {
                _scaryStories=new ScaryStoriesContext();
                var settings = new YouTubeRequestSettings("Parser Scary", "AI39si5rF2hYuZZITqLuri2O1hk5ZW5RBFWdNRhDNRZDNnkz8oJNgSIGSkZy5AIuUnB9qFvYccesg_xMp7PXOK5fY0bxzf8j_Q");
                var request = new YouTubeRequest(settings);
            var sourceId = "0d654178-adc4-4100-b67f-8082f7f3e5d1";
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

        private string InsertSource()
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
    }
}
