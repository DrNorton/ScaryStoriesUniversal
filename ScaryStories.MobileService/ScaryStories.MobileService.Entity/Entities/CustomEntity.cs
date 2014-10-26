using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace ScaryStories.MobileService.Entity.Entities
{
    public abstract class CustomEntity : ITableData
    {
        public DateTimeOffset? CreatedAt { get; set; }

        public bool Deleted { get; set; }

        [Key]
        [TableColumn(TableColumnType.Id)]
        public string Id { get; set; }

      
        public DateTimeOffset? UpdatedAt { get; set; }

  
        public byte[] Version { get; set; }
    } 
}
