using System.Collections.Generic;
using To_Do_Lists.Data.Entities;

namespace To_Do_Lists.Models
{
    public class ListOfListsModel
    {
        public ICollection<ListOfItemsModel> Lists { get; set; }
    }
}