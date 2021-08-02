using System.ComponentModel.DataAnnotations;

namespace To_Do_Lists.Models
{
    public class ItemsModel
    {
        public int ItemId { get; set; }
        
        public string Text { get; set; }
    }
}