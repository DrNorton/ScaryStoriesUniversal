using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ScaryStories.MobileService.Entity;

using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using Photo = VkNet.Model.Attachments.Photo;


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
           // GetVk();
            GetYoutube();
        }

        private async void GetVk()
        {
            var parser = new VkScaryParser();
            parser.Get();
        }

        private void GetYoutube()
        {
            var youtubeParser = new YoutubeVideoParser();
           
            youtubeParser.Get();
        }

       
       
    }
}
