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
    [Route("api/Agenda/{ListId:int}")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private readonly IToDoListRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ListController(IToDoListRepository repository,IMapper mapper,LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        /// <summary>
        /// view One List
        /// </summary>
        /// <param name="ListId"></param>
        /// <param name="includeItems"></param>
        /// <returns>Returns The desired List</returns>
        /// <response code="200">Returns The desired List</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>
        /// <response code="404">If Couldn't add the list</response>
        [HttpGet]
        public async Task<ActionResult<ListOfItemsModel>>Get(int ListId,bool includeItems = false)//viewOneList
        {
            try
            {
                var result = await _repository.GetListAsync(ListId,includeItems);
                if (result == null)
                {
                    return NotFound("The list that you are trying to retrieve is not existed");
                }

                return _mapper.Map<ListOfItemsModel>(result);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Shekloo error ya kbeer !");
            }
        }
        
        /// <summary>
        /// Add Item to a List
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///    POST /Todo
        ///    {
        ///        "text": "string"
        ///    }
        ///
        /// </remarks>
        /// <param name="ListId"></param>
        /// <param name="model"></param>
        /// <returns>Returns The list with the new item added</returns>
        /// <response code="404">If The desired list is not existed !</response>
        /// <response code="400">If The Text of the task is missing !</response>
        /// <response code="201">Returns The list with the new item added</response>
        /// <response code="400">If Something wrong has happened ... !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>            
        [HttpPost]
        public async Task<ActionResult<ListOfItemsModel>> Post(int ListId,ItemsModel model)//AddItem
        {
            try
            {
                var list = await _repository.GetListAsync(ListId);
                if (list == null)
                {
                    return NotFound("The desired list is not existed !");
                }

                var item = _mapper.Map<Item>(model);
                item.ListOfItems = list;

                if (model.Text == null)
                {
                    return BadRequest("Text of the task is required !");
                }
                
                _repository.Add(item);
                if (await _repository.SaveChangesAsync())
                {
                    var url = _linkGenerator.GetPathByAction(HttpContext,
                        "Get",
                        values: new {ListId});
                    //the url is binding us to the individual talk on the server
                    //because we need to send the location back not just a new object
                    //and so we are going to use that linkGenerator to do it
                    
                    return Created(url, _mapper.Map<ListOfItemsModel>(list));
                }
                else
                {
                    return BadRequest("Something wrong has happened ...");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error ya kbeeer");
            }
        }

        /// <summary>
        /// Add Item to a List
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///    PUT /Todo
        ///{
        ///    "listTitle": "string",
        ///    "toDoList": [
        ///    {
        ///        "text": "string"
        ///    },
        ///    {
        ///        "text": "string"
        ///    },
        ///    {
        ///        "text": "string"
        ///    }
        ///    ]
        ///}
        ///
        /// </remarks>
        /// <param name="ListId"></param>
        /// <param name="model"></param>
        /// <returns>Returns The list with new edits</returns>
        /// <response code="404">If The desired list is not existed !</response>
        /// <response code="200">Returns The list with new edits !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>            
        /// <response code="400">If Something wrong has happened ... !</response>
        [HttpPut]
        public async Task<ActionResult<ListOfItemsModel>> Put(int ListId,ListOfItemsModel model)//EditList(ChangeTitle)
        {
            try
            {
                var oldList = await _repository.GetListAsync(ListId);
                if (oldList == null)
                {
                    return NotFound($"Notu foundu {ListId}");
                }

                _mapper.Map(model, oldList);
                if (await _repository.SaveChangesAsync())
                {
                    return _mapper.Map<ListOfItemsModel>(oldList);
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Shekloo error ya kbeer !");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a List
        /// </summary>
        /// <param name="ListId"></param>
        /// <returns>Returns The status after deletion</returns>
        /// <response code="404">If The list you want to delete is already not existed !</response>
        /// <response code="200">If list was deleted successfully !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>
        /// <response code="404">If Could not delete the desired list</response>
        [HttpDelete]
        public async Task<ActionResult<ListOfItemsModel>> Delete([FromRoute]int ListId)//DeleteList
        {
            try
            {
                var list = await _repository.GetListAsync(ListId);
                if (list == null)
                {
                    return NotFound("The list you want to delete is already not existed !");
                }
            
                _repository.Delete(list);

                if (await _repository.SaveChangesAsync())
                {
                    return Ok("list was deleted successfully !");
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Something bad happened");
            }
            return BadRequest("Could not delete the desired list");

        }
        
        /// <summary>
        /// Checks if a list is existed
        /// </summary>
        /// <param name="ListId"></param>
        /// <returns>Returns The status after searching</returns>
        /// <response code="404">If The list that you are trying to retrieve is not existed !</response>
        /// <response code="200">If The list is found !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>
        [HttpGet("isExist")]
        public async Task<IActionResult>Get(int ListId)//isExist(List)
        {
            try
            {
                var result = await _repository.GetListAsync(ListId);
                if (result == null)
                {
                    return NotFound("The list that you are trying to retrieve is not existed");
                }

                return this.StatusCode(StatusCodes.Status200OK,"The list is found");
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Shekloo error ya kbeer !");
            }
        }
    }
}
