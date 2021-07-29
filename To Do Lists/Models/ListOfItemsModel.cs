using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using To_Do_Lists.Data.Entities;

namespace To_Do_Lists.Models
{
    public class ListOfItemsModel
    {
        public ICollection<ItemsModel> ToDoList { get; set; }
        
        public ListOfListsModel main { get; set; }
        
        [Required]
        public string ListTitle;

        public int ListOfItemsID { get; set; }
    }
}