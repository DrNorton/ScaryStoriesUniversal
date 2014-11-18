namespace ScaryStoriesUniversal.Api.Entities
{
    public class Source:BaseEntity
    {
        public string Name { get; set; }

        public byte[] Thumb
        {
            get { return Image; }
        }

        public byte[] Image { get; set; }
        public string Url { get; set; }
    }
}
