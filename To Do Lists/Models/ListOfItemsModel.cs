using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using To_Do_Lists.Data.Entities;

namespace To_Do_Lists.Models
{
    public class ListOfItemsModel
    {
        public int ListOfItemsId { get; set; }

        public string ListTitle { get; set; }

        public ICollection<ItemsModel> ToDoList { get; set; }
    }
}