namespace ScaryStoriesUniversal.Dtos
{
    public class PhotoResponse : BaseResponse
    {
        public byte[] Image { get; set; }

        public byte[] Thumb { get; set; }
    }
}
