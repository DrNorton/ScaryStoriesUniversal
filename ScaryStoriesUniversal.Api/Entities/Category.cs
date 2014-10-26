namespace ScaryStoriesUniversal.Api.Entities
{
    public class Category:BaseEntity
    {

        public byte[] Image { get; set; }


        public byte[] Thumb { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }
    }
}
