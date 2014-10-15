using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using ScaryStories.MobileService.Entity;

namespace ScaryStories.MobileService.Dtos
{
    public class CategoryDto : EntityDto
    {
        public CategoryDto()
        {

        }


        public byte[] Image { get; set; }

    
        public byte[] Thumb { get; set; }

      
        public string Name { get; set; }

        public string Description { get; set; }

       

    }
}
