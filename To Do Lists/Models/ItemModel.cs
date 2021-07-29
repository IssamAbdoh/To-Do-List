using System.ComponentModel.DataAnnotations;

namespace To_Do_Lists.Models
{
    public class ItemsModel
    {
        public int ItemID { get; set; }
        
        [Required]
        public string Text { get; set; }

        public ListOfItemsModel list { get; set; }
    }
}