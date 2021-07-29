﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace To_Do_Lists.Data.Entities
{
    [Keyless]
    public class ListOfLists
    {
        
        public ICollection<ListOfItems> Lists { get; set; }

        /*
        //public List<ListOfItems> Lists;

        //private string mainFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"main folder");
        

        
        public ListOfLists()
        {
            Lists = new List<ListOfItems>();
        }
        

        
        public void ViewAllLists()
        {
            if (Lists.Count != 0)
            {
                Console.WriteLine("List ID\t\t\tTitle of the list");
                foreach (var list in Lists)
                {
                    Console.WriteLine(list.ListOfItemsID + "\t\t\t" + list.ListTitle);
                }
            }
            else
            {
                Console.WriteLine("Unfortunately , there is not any list to display .");
            }
            Console.WriteLine();
        }

        public void DeleteList(int id)
        {
            var list = Lists.SingleOrDefault(l => l.ListOfItemsID == id);
            if (list is not null)
            {
                Lists.Remove(list);
                Console.WriteLine("You have successfully deleted the list .");
                if (File.Exists(Path.Combine(mainFolderPath, id.ToString()+".txt")))    
                {    
                    // If file found, delete it    
                    File.Delete(Path.Combine(mainFolderPath, id.ToString()+".txt"));    
                    //Console.WriteLine("File deleted.");    
                }
            }
            else
            {
                Console.WriteLine("There is no list with the ID you have provided .");
                Console.WriteLine("Try again .");
            }
        }

        public void ChangeListTitle(int id, string title)
        {
            var list = Lists.SingleOrDefault(l => l.ListOfItemsID == id);
            if (list is not null)
            {
                list.ListTitle = title;
                Console.WriteLine("You have successfully changed the title .");
            }
            else
            {
                Console.WriteLine("There is no list with the ID you have provided .");
                Console.WriteLine("Try again .");
            }
        }

        public void AddListOfItems(ListOfItems listOfItems)
        {
            Lists.Add(listOfItems);
        }
        
        public bool IsExist(int id)
        {
            var list = Lists.SingleOrDefault(l => l.ListOfItemsID == id);
            if (list is not null)
            {
                return true;
            }
            return false;
        }
        */
    }
}