using System;
using System.Collections.Generic;
using System.Text;
using ScaryStoriesUniversal.Api.Entities;
using SQLite;

namespace ScaryStoriesUniversal.Database.Entities
{
    [Table("FavoriteStories")]
    public class FavoriteStory:IBaseEntity
    {
        private string _id;
        private byte[] _thumb;
        private string _name;
        private DateTimeOffset? _createdAt;

        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public byte[] Thumb
        {
            get { return _thumb; }
            set { _thumb = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTimeOffset? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }
    }
}
