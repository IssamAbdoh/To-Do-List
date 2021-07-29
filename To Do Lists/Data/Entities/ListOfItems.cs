using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace To_Do_Lists.Data.Entities
{
    public class ListOfItems
    {
        //public List<Item> ToDoList;
        public ICollection<Item> ToDoList { get; set; }
        
        public ListOfLists main { get; set; }
        
        public string ListTitle;

        [Key]
        public int ListOfItemsID { get; set; }

        /*
        public string ListTitle;

        private readonly string mainFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"main folder");

        public ListOfItems(string listTitle)
        {
            ListOfItemsID = uniqueID();
            this.ListTitle = listTitle;
            ToDoList = new List<Item>();
        }

        public ListOfItems(string listTitle, int id)
        {
            //Console.WriteLine(mainFolderPath);
            this.ListOfItemsID = id;
            this.ListTitle = listTitle;
            ToDoList = new List<Item>();
        }
        
        public void AddItem(string itemText)
        {
            Item t = new Item(itemText);
            ToDoList.Add(t);
        }

        public void DeleteItem(int id)
        {
            var item = ToDoList.SingleOrDefault(i => i.ItemID == id);
            
            if (item != null)
            {            
                // found 
                ToDoList.Remove(item);
                Console.WriteLine("You have successfully deleted the item .");
            }
            else
            {
                Console.WriteLine("There is no item with the ID you have provided .");
                Console.WriteLine("Try again .");
            }
        }

        public void ViewList()
        {
            Console.WriteLine(ListTitle + " list : ");
            Console.WriteLine("ID\tItem\n");
            foreach (var t in ToDoList)
            {
                Console.WriteLine($"{t.ItemID}\t{t.Text}");
            }
        }

        public void EditItem(int id, string newItemText)
        {
            var item = ToDoList.SingleOrDefault(i => i.ItemID == id);
            
            if (item != null)
            {            
                // found 
                Console.WriteLine("You have successfully deleted the item .");
                item.Text = newItemText;
            }
            else
            {
                Console.WriteLine("There is no item with the ID you have provided .");
                Console.WriteLine("Try again .");
            }
        }

        public bool IsExist(int id)
        {
            var item = ToDoList.SingleOrDefault(i => i.ItemID == id);
            
            if (item != null)
            {            
                // found 
                return true;
            }
            else
            {
                return false;
            }
        }

        private int uniqueID()
        {
            int id = 1;
            while(File.Exists(mainFolderPath + @"\" + id.ToString() + ".txt"))
            {
                id++;
            }

            return id;
        }
        */
    }
}