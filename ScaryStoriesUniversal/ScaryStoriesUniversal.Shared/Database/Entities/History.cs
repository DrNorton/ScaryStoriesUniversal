using System;
using SQLite;

namespace ScaryStoriesUniversal.Database.Entities
{
    [Table("History")]
    public class History : IDetail
    {
        private int _id;
        private int _storyId;
        private DateTime _viewTime;

        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public int StoryId
        {
            get
            {
                return _storyId;
            }
            set
            {
                _storyId = value;
            }
        }
        public DateTime ViewTime
        {
            get
            {
                return _viewTime;
            }
            set
            {
                _viewTime = value;
            }
        }
        public History(int id, int storyId, DateTime viewTime)
        {
            _id = id;
            _storyId = storyId;
            _viewTime = viewTime;
        }
        public History()
        {

        }
    }
}
