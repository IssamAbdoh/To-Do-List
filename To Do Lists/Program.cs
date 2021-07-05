using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace To_Do_Lists
{
    class Program
    {
        static ListOfLists main = new ListOfLists();

        static void Main(string[] args)
        {
            //Setting the lists up 
            
            //creating the main list of lists

            DownloadingData();

            RunProgram();
            string input;
            do
            {
                DisplayMainMenu();
                Console.WriteLine("\nEnter \"exit\" to exit , or any button to continue ...");
                input = Console.ReadLine();
                if (input == null || input.ToLower() == "exit")
                {
                    break;
                }
            } while (true);
            SaveAllUpdates();
        }
        
        static void SaveAllUpdates()
        {
            string mainPath = @"C:\Users\GTS\Desktop\Terkwaz Intership\Tasks\To Do Lists\main folder";
            foreach (var list in main.Lists)
            {
                string filePath = mainPath + @"\" + list.ID + ".txt";
                //Console.WriteLine($"File Path : \n{filePath}\n");

                // updateing content 
                // Write the tasks into the files .
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    outputFile.WriteLine(list.ListTitle);
                    foreach (var item in list.ToDoList)
                    {
                        outputFile.WriteLine(item.Text);
                    }
                }
            }
        }

        static void DownloadingData()
        {
            //checking if there is previous data
            
            //string mainFolderPath = @"C:\Users\GTS\Desktop\Terkwaz Intership\Tasks\To Do Lists\main folder";
            string mainFolderPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,"main folder");

            var directoryInfo = new DirectoryInfo(mainFolderPath);
            
            if (directoryInfo.Exists)
            {
                //downloading data from files to program
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (var fileInfo in fileInfos)
                {
                    List<string> contentOfAFile = new List<string>();
                    //reading data from a file
                    using (StreamReader sr = fileInfo.OpenText())
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Length != 0)
                            {
                                contentOfAFile.Add(s);
                            }
                        }
                    }

                    //reading items of a file
                    string name = fileInfo.Name.Substring(0, fileInfo.Name.IndexOf('.'));
                    
                    int h = Convert.ToInt32(name);
                    ListOfItems listOfItems = new ListOfItems(contentOfAFile[0],h);
                    for (int i = 1; i < contentOfAFile.Count; i++)
                    {
                        listOfItems.AddItem(contentOfAFile[i]);
                    }

                    main.AddListOfItems(listOfItems);
                }
            }
            else
            {
                directoryInfo.Create();
            }
        }

        static void RunProgram()
        {
            Console.WriteLine($"Welcome to \"My Item Manager\" !");
            Console.WriteLine("Press any button to display the menu ");
            string h = Console.ReadLine();
            Console.WriteLine();
        }

        static void CreateList()
        {
            Console.WriteLine("Enter the title of the list you want to create ");
            string title = Console.ReadLine();
            ListOfItems listOfItems = new ListOfItems(title);
            int count = 0;
            do
            {
                Console.WriteLine(
                    $"Enter the item you want to add to {title} list \nif you want to stop in any time enter \"exit\".");
                var item = Console.ReadLine();
                if (item != null && item.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    listOfItems.AddItem(item);
                    count++;
                }
            } while (true);

            Console.WriteLine($"You have added {count} item(s) to {listOfItems.ListTitle} list successfully !");
            Console.WriteLine();
            listOfItems.ViewList();
            main.AddListOfItems(listOfItems);
        }

        static void DeleteList()
        {
            main.ViewAllLists();
            Console.WriteLine("\nEnter the id of the list you want to delete .\n");
            string input = Console.ReadLine();
            if ( input != null && input.All(char.IsDigit))
            {
                int id = int.Parse(input);
                main.DeleteList(id);
                Console.WriteLine("The list has been deleted successfully !\n");
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
        }

        static void EnterList()
        {
            main.ViewAllLists();
            Console.WriteLine("Enter the ID of the list you want to enter .");
            string input = Console.ReadLine();
            if ( input != null && input.All(char.IsDigit))
            {
                int id = int.Parse(input);
                ListOfItems tem;
                var list = main.Lists.SingleOrDefault(l => l.ID == id);
                if(list!=null)
                {
                    tem = list;
                    DisplayListMenu(tem);
                }
                else
                {
                    Console.WriteLine("There is no list with the ID you have provided .");
                    Console.WriteLine("Try again .");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
        }

        static void AddItem(ListOfItems listOfItems)
        {
            do
            {
                Console.WriteLine("Enter the item you want to add or enter \"exit\" to quit .");
                string input = Console.ReadLine();
                if (input != null && input.ToLower() == "exit")
                {
                    break;
                }
                listOfItems.AddItem(input);
                Console.WriteLine("The item has been added successfully !");
            } while (true);
        }

        static void EditItem(ListOfItems listOfItems)
        {
            listOfItems.ViewList();
            Console.WriteLine("Enter the ID of the item you want to edit .\n");
            string input = Console.ReadLine();
            if ( input != null && input.All(char.IsDigit))
            {
                int id = int.Parse(input);
                var list = listOfItems.ToDoList.SingleOrDefault(i => i.ID == id);
                if(list!=null)
                {
                    Console.WriteLine("Enter the new text of the item \n");
                    string s = Console.ReadLine();
                    listOfItems.EditItem(id, s);
                    Console.WriteLine("You have updated the text of the item successfully !");
                }
                else
                {
                    Console.WriteLine("There is no item with the ID you have provided .");
                    Console.WriteLine("Try again .");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
        }

        static void DeleteItem(ListOfItems listOfItems)
        {
            listOfItems.ViewList();
            Console.WriteLine("Enter the ID of the item you want to delete .");
            string input = Console.ReadLine();
            if ( input != null && input.All(char.IsDigit))
            {
                int id = int.Parse(input);
                var list = listOfItems.ToDoList.SingleOrDefault(i => i.ID == id);
                if(list!=null)
                {
                    listOfItems.DeleteItem(id);
                    Console.WriteLine("you have deleted the desired item successfully !");
                }
                else
                {
                    Console.WriteLine("There is no item with the ID you have provided .");
                    Console.WriteLine("Try again .");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
        }

        static void ChangeTitle(ListOfItems listOfItems)
        {
            Console.WriteLine("Enter the new title ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                listOfItems.ListTitle = input;
                Console.WriteLine("The title has been changed successfully !");
            }
            else
            {
                Console.WriteLine("Invalid Input !");
            }
        }

        static void DisplayListMenu(ListOfItems listOfItems)
        {
            do
            {
                Console.WriteLine($"You are now inside {listOfItems.ListTitle} list ");
                Console.WriteLine("List Menu : \n");

                Console.WriteLine("Choose one of the options below .\n");

                Console.WriteLine($"1 - View all items {listOfItems.ListTitle} List .");
                Console.WriteLine("2 - Add a new item .");
                Console.WriteLine("3 - Edit a item .");
                Console.WriteLine("4 - Delete a item .");
                Console.WriteLine("5 - Change the title of the list .");
                Console.WriteLine("exit - to quit this menu and return for the main menu .\n");

                string input = Console.ReadLine();
                if (input != null)
                {
                    switch (input.ToLower())
                    {
                        case "1":
                        {
                            listOfItems.ViewList();
                            break;
                        }
                        case "2":
                        {
                            AddItem(listOfItems);
                            SaveAllUpdates();
                            break;
                        }
                        case "3":
                        {
                            EditItem(listOfItems);
                            SaveAllUpdates();
                            break;
                        }
                        case "4":
                        {
                            DeleteItem(listOfItems);
                            SaveAllUpdates();
                            break;
                        }
                        case "5":
                        {
                            ChangeTitle(listOfItems);
                            SaveAllUpdates();
                            break;
                        }
                        case "exit":
                        {
                            goto barra;
                        }
                        default:
                        {
                            Console.WriteLine("Invalid input .\nTRY AGAIN !\n");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input .\nTRY AGAIN !\n");
                }
            } while (true);

            barra : ;
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("Main Menu : \n");
            Console.WriteLine("Choose one of the options .\n");
            Console.WriteLine("1 - View all current Lists .");
            Console.WriteLine("2 - Create a new List .");
            Console.WriteLine("3 - Choose a List .");
            Console.WriteLine("4 - Delete a List .\n");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                {
                    main.ViewAllLists();
                    break;
                }
                case "2":
                {
                    CreateList();
                    SaveAllUpdates();
                    break;
                }
                case "3":
                {
                    EnterList();
                    SaveAllUpdates();
                    break;
                }
                case "4":
                {
                    DeleteList();
                    SaveAllUpdates();
                    break;
                }
                default:
                {
                    Console.WriteLine("Invalid input .\nTRY AGAIN !\n");
                    break;
                }
            }
        }
    }
}