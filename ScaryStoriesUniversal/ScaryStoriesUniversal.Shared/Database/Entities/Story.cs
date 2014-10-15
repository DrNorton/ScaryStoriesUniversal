using System;
using SQLite;

namespace ScaryStoriesUniversal.Database.Entities
{
    [Table("Stories")]
    public class Story : IDetail
    {
        private int _id;
        private DateTime _createdTime;
        private string _sourceUrl;
        private int _sourceId;

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

        private string _header;
        private byte[] _image;
        private string _text;
        private long _likes;
        private byte[] _thumbnail;


        public bool IsFavorite { get; set; }

        public int _categoryId { get; set; }
     
        public DateTime CreatedTime
        {
            get
            {
                return _createdTime;
            }
            set
            {
                _createdTime = value;
            }
        }
      
        public string Header
        {
            get
            {
                return _header;
            }
            set
            {
                _header = value;
            }
        }
     
        public byte[] Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
            }
        }

    
        public byte[] Thumbnail
        {
            get
            {
                return _thumbnail;
            }
            set
            {
                _thumbnail = value;
            }
        }

  
        public long Likes
        {
            get
            {
                return _likes;
            }
            set
            {
                _likes = value;
            }
        }
     
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public string SourceUrl
        {
            get
            {
                return _sourceUrl;
            }
            set
            {
                _sourceUrl = value;
            }
        }
    
        public int SourceId
        {
            get
            {
                return _sourceId;
            }
            set
            {
                _sourceId = value;
            }
        }

        public Story(int id, string header, byte[] image, string text, long likes, int categoryId, bool isFavorite)
        {
            _id = id;
            _header = header;
            _image = image;
            _text = text;
            _likes = likes;
            _categoryId = categoryId;
            IsFavorite = isFavorite;
        }

        public Story()
        {

        }
    }
}
