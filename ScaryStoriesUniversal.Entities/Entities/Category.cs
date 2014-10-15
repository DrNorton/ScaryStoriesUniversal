using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ScaryStoriesUniversal.Entities.Entities
{
    [Table("Categories")]
    public class Category : IDetail
    {
        private int _id;
        private string _name;
        private byte[] _image;
        private DateTime _createdTime;
        public Category(int id, string name, byte[] image)
        {
            _id = id;
            _name = name;
            _image = image;
        }

        [PrimaryKey,AutoIncrement]
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
        public Category()
        {

        }
    }
}
