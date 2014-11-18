using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ScaryStoriesUniversal.Database.Entities
{
    [Table("PhotoEntity")]
    public class PhotoEntity
    {
        private string _id;
        private DateTimeOffset? _createdAt;
        
        [PrimaryKey]
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public byte[] Image { get; set; }
        public byte[] Thumb { get; set; }

        public DateTimeOffset? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }
    }
}
