namespace ScaryStoriesUniversal.Api.Entities
{
    public class Photo : BaseEntity
    {
        public byte[] Image { get; set; }
        public byte[] Thumb { get; set; }
    }
}
