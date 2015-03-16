using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Notifications;

namespace ScaryStoriesUniversal.Services.Tiles
{
    public interface ITileService
    {
        void UpdateTile();
    }

    public class TileService : ITileService
    {
        public void UpdateTile()
        {
            var xmltile = Windows.UI.Notifications.TileUpdateManager.GetTemplateContent(Windows.UI.Notifications.TileTemplateType.TileSquare310x310ImageAndTextOverlay03);
            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            var test = xmltile.ToString();
            updater.EnableNotificationQueue(true);
            updater.Clear();
        }
    }
}
