namespace ScaryStoriesUniversal.Dtos
{
    public class CategoryDto:BaseDto
    {

        public byte[] Image { get; set; }


        public byte[] Thumb { get; set; }


        public string Name { get; set; }

        public string Description { get; set; }
    }
}
