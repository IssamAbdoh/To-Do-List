using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do_Lists.Data.Entities
{
    public class Item
    {

        [Key]
        public int ItemID { get; set; }
        
        public string Text { get; set; }

        public ListOfItems list { get; set; }
        
        /*
        private static int itemID = 1;

         
        public Item(string text)
        {
            ItemID = itemID;
            itemID++;
            this.Text = text;
        }
        */
    }
}