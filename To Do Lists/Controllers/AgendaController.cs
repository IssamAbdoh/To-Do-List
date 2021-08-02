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
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IToDoListRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
  
        public AgendaController(IToDoListRepository repository,IMapper mapper,LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        
        /// <summary>
        /// View All Lists
        /// </summary>
        /// <param name="includeItems"></param>
        /// <returns>Returns all existed Lists</returns>
        /// <response code="200">Returns all existed Lists</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>            
        [HttpGet]
        public async Task<ActionResult<ListOfItemsModel[]>> Get(bool includeItems = false)//ViewAllLists
        {
            try
            {
                var results = await _repository.GetAllListsAsync(includeItems);

                return _mapper.Map<ListOfItemsModel[]>(results);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Something bad happened");
            }
        }
        
        
        /// <summary>
        /// Create List
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /Todo
        ///     {
        ///         "listTitle": "string",
        ///         "toDoList":
        ///         [
        ///             {
        ///                 "text": "string"
        ///             },
        ///             {
        ///                 "text": "string"
        ///             },
        ///             {
        ///                 "text": "string"
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <returns>Returns A newly created List</returns>
        /// <response code="400">If Couldn't add the list</response>
        /// <response code="200">Returns A newly created List</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>            
        [HttpPost]
        public async Task<ActionResult<ListOfItemsModel>> Post(ListOfItemsModel model)//CreateList
        {
            try
            {
                var location = _linkGenerator.GetPathByAction(
                    "Get",
                    "List",
                    values: new {ListOfItemsID = model.ListOfItemsId});

                if (string.IsNullOrWhiteSpace(location))
                {
                    return BadRequest("Couldn't add the list");
                }
                
                //create a new list
                var list = _mapper.Map<ListOfItems>(model);
                _repository.Add(list);

                if (await _repository.SaveChangesAsync())
                {
                    return Created(location, _mapper.Map<ListOfItemsModel>(list));
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Something bad happened");
            }

            return BadRequest();
        }
        
    }
}