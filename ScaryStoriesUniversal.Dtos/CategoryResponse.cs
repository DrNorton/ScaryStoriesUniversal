namespace ScaryStoriesUniversal.Dtos
{
    public class CategoryResponse:BaseResponse
    {

        public byte[] Image { get; set; }


        public byte[] Thumb { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }
    }
}
