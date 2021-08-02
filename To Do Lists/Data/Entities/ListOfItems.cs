using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace To_Do_Lists.Data.Entities
{
    public class ListOfItems
    {
        public int ListOfItemsId { get; set; }
        
        public string ListTitle { get; set; }
        
        public ICollection<Item> ToDoList { get; set; }
    }
}