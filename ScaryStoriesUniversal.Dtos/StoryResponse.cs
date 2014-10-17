using System;

namespace ScaryStoriesUniversal.Dtos
{
    public class StoryResponse:BaseResponse
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }


        public string Url { get; set; }



        public PhotoResponse Photo { get; set; }
    }
}
