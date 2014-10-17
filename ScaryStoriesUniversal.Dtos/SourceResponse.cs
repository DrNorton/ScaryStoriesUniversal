namespace ScaryStoriesUniversal.Dtos
{
    public class SourceResponse:BaseResponse
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public string Url { get; set; }
    }
}
