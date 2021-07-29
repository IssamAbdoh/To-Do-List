using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using To_Do_Lists.Data.Entities;

namespace To_Do_Lists.Data
{
  public interface IToDoListRepository
  {
    // General 
    void Add<T>(T entity) where T : class;
    void Delete<T>(T entity) where T : class;
    Task<bool> SaveChangesAsync();
    
    //List Of Lists
    
    Task<ListOfLists> GetAllListsAsync1();
    //dont forget to make just one of them and give them includeItems boolean variable
    
    Task<ListOfItems[]> GetAllListsAsync2();

    //public void DeleteListAsync(int id)
    //public void ChangeListTitleAsync(int id, string title)
    //public void AddListOfItemsAsync(ListOfItems listOfItems)
    //public bool IsExistAsync(int id)
    
    
    //List Of Items
    
    //public void AddItem(string itemText)
    //public void DeleteItem(int id)
    Task<ListOfItems> GetListAsync(int id);
    //public void EditItem(int id, string newItemText)
    //public bool IsExist(int id)
    //private int uniqueID()
    
    
    //Items
    //none
  }
}