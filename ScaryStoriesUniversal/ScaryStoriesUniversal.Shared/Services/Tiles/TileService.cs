using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Notifications;
using ScaryStoriesUniversal.Api.Entities;
using NotificationsExtensions.TileContent;

namespace ScaryStoriesUniversal.Services.Tiles
{
    public interface ITileService
    {
        void UpdateTiles(IEnumerable<Story> stories);
       
        Task AddTilesToQueue(Story story);
    }

    public class TileService : ITileService
    {
        private TileUpdater _updater;

        public TileService()
        {
  
        }
        public async void UpdateTiles(IEnumerable<Story> stories )
        {
            try
            {
                for (int i = 1; i <= 5; i++)
                {
                    await CreateTile(stories.ElementAt(i), i.ToString());
                }
            }
            catch (Exception e)
            {
                
            }
           
        }

        private async Task CreateTile(Story currentStory, string fileName)
        {
            await SaveImage(currentStory, fileName);
           var imageSrc = String.Format("ms-appdata:///local/{0}.jpg", fileName);
            var tileLargeContent = TileContentFactory.CreateTileSquare310x310ImageAndTextOverlay02();
            tileLargeContent.Image.Src = imageSrc;
            tileLargeContent.TextHeadingWrap.Text = currentStory.Name;
            tileLargeContent.TextBodyWrap.Text = String.Format("{0}..", currentStory.Text.Substring(0,300));

            var wideContent = TileContentFactory.CreateTileWide310x150ImageAndText01();
            wideContent.TextCaptionWrap.Text = currentStory.Name;
            wideContent.Image.Src = imageSrc;

            var mediumContent = TileContentFactory.CreateTileSquare150x150PeekImageAndText01();
            mediumContent.TextBody1.Text = currentStory.Name;
            mediumContent.Image.Src = imageSrc;

            wideContent.Square150x150Content = mediumContent;
            tileLargeContent.Wide310x150Content = wideContent;

            var tileLarge = tileLargeContent.CreateNotification();
            _updater.Update(tileLarge);
        }

        private async Task SaveImage(Story story,string name)
        {
            var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(name+".jpg", CreationCollisionOption.ReplaceExisting);
            using (var writeStream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (var streamWriter = new BinaryWriter(writeStream.AsStreamForWrite()))
                {
                    streamWriter.Write(story.Thumb);
                    streamWriter.Flush();
                }
            }
        
        }




        public async Task AddTilesToQueue(Story story)
        {
            _updater = TileUpdateManager.CreateTileUpdaterForApplication();
            _updater.EnableNotificationQueue(true);
           await CreateTile(story,story.Id);
        }


    }
}
