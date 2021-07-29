using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using To_Do_Lists.Data.Entities;

namespace To_Do_Lists.Data
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly ListDbContext _context;
        private readonly ILogger<ToDoListRepository> _logger;
        
        public ToDoListRepository(ListDbContext context, ILogger<ToDoListRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        
        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object of type {entity.GetType()} to the context.");
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _logger.LogInformation($"Removing an object of type {entity.GetType()} to the context.");
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            _logger.LogInformation($"Attempitng to save the changes in the context");

            // Only return success if at least one row was changed
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<ListOfItems[]> GetAllListsAsync2()
        {
            _logger.LogInformation($"Getting all Lists2");

            IQueryable<ListOfItems> query = _context.ListOfItemsEnumerable.Include(c => c.ListTitle);
            //order it
            query = query.OrderByDescending(c => c.ListOfItemsID);

            return await query.ToArrayAsync();
        }

        public async Task<ListOfLists> GetAllListsAsync1()
        {
            _logger.LogInformation($"Getting all Lists1");

            IQueryable<ListOfLists> query = _context.ListOfListsEnumerable.Include(c => c.Lists);
                
                
            //order it
            query = query
                .OrderByDescending(c => c.Lists);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<ListOfItems> GetListAsync(int id)
        {
            _logger.LogInformation($"Getting a list with id = {id}");

            IQueryable<ListOfItems> query = _context.ListOfItemsEnumerable
                .Include(c => c.ListTitle);
            
            // Query It
            query = query.Where(c => c.ListOfItemsID == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}