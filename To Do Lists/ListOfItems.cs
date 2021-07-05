using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace To_Do_Lists
{
    public class ListOfItems
    {
        public List<Item> ToDoList;//solid princebles
        public string ListTitle;
        //private string mainFolderPath = @"C:\Users\GTS\Desktop\Terkwaz Intership\Tasks\To Do Lists\main folder";
        private string mainFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"main folder");

        
        public int ID { get; set; }

        public ListOfItems(string listTitle)
        {
            ID = uniqueID();
            this.ListTitle = listTitle;
            ToDoList = new List<Item>();
        }

        public ListOfItems(string listTitle, int id)
        {
            //Console.WriteLine(mainFolderPath);
            this.ID = id;
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
            var item = ToDoList.SingleOrDefault(i => i.ID == id);
            
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
                Console.WriteLine($"{t.ID}\t{t.Text}");
            }
        }

        public void EditItem(int id, string newItemText)
        {
            var item = ToDoList.SingleOrDefault(i => i.ID == id);
            
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
            var item = ToDoList.SingleOrDefault(i => i.ID == id);
            
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
            /*
            Console.WriteLine("MAX : "+ _list.Max(i => i.id));
            return _list.Max(i => i.id) + 1;
            return items;
            */
            int id = 1;
            while(File.Exists(mainFolderPath + @"\" + id.ToString() + ".txt"))
            {
                id++;
            }

            return id;
        }
    }
}