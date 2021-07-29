using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using To_Do_Lists.Data;
using To_Do_Lists.Data.Entities;
using To_Do_Lists.Models;

namespace To_Do_Lists.Controllers
{
    [Route("api/ToDoList")]
    [ApiController]
    public class ListOfListsController : ControllerBase
    {
        private readonly IToDoListRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ListOfListsController(IToDoListRepository repository,IMapper mapper,LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet]
        public async Task<ActionResult<ListOfLists>> Get()//get all lists
        {
            try
            {
                return Ok("Hello");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            /*
            try
            {
                var results = await _repository.GetAllListsAsync1();

                return _mapper.Map<ListOfListsModel>(results);
            }
            catch (Exception e)
            {
                
            }*/
        }
        /*
        public async Task<AcceptedResult<ListOfItems>> Delete(int id)//deleting a list
        {
            
        }
        
        public async Task<AcceptedResult<ListOfItems>> Post(ListOfItemsModel model)//add a list of itmes
        {
            
        }
        */
    }
}