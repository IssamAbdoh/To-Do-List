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
    Task<ListOfItems[]> GetAllListsAsync(bool includeItems = false);
    
    
    //List Of Items
    Task<ListOfItems> GetListAsync(int id,bool includeItems = false);
    
    
    //Items
    Task<Item> GetItemAsync(int itemID);
  }
}