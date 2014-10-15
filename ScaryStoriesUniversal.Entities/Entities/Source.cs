using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ScaryStoriesUniversal.Entities.Entities
{
    [Table("Sources")]
    public class Source : IDetail
    {
        private int _id;
        private string _name;
        private string _url;
        private byte[] _image;
        private DateTime _createdTime;
        private Story[] _stories;
        public Source(int id, string name, string url, byte[] image, DateTime createdTime)
        {
            _id = id;
            _name = name;
            _url = url;
            _image = image;
            _createdTime = createdTime;
        }
        public Source()
        {

        }

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
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
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
        public string Url
        {
            get
            {
                return _url;
            }
            set
            {
                _url = value;
            }
        }
    }
}
