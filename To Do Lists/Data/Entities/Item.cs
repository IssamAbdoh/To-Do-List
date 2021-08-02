using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace To_Do_Lists.Data.Entities
{
    public class Item
    {
        public int ItemId { get; set; }
        
        public string Text { get; set; }

        public ListOfItems ListOfItems { get; set; }
    }
}