using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScaryStoriesUniversal.Helpers
{
    public class StoryListIdsContainer
    {
        private IEnumerable<string> _storiesIds;
        private int _position=0;

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public void SetIds(IEnumerable<string> ids)
        {
            _storiesIds = ids;
        }

        public bool CanNext()
        {
            if (Position+1>=_storiesIds.Count())
            {
                return false;
            }
            return true;
        }

        public bool CanBack()
        {
            if (Position-1 <= 0)
            {
                return false;
            }
            return true;
        }

        public string Back()
        {
            if (!CanBack())
            {
                return String.Empty;
            }
            Position--;
           var storyId= _storiesIds.ElementAt(Position);
            return storyId;
        }

        public string Next()
        {
            if (!CanNext())
            {
                return String.Empty;
            }
            Position++;
            var storyId = _storiesIds.ElementAt(Position);
         
            return storyId;
        }

        public string GetCurrentStoryId()
        {
            return _storiesIds.ElementAt(Position);
        }

    }
}
