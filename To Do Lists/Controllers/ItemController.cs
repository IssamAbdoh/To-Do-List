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
    [Route("api/Agenda/{ListId:int}/{ItemId:int}")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IToDoListRepository _repository;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ItemController(IToDoListRepository repository,IMapper mapper,LinkGenerator linkGenerator)
        {
            _repository = repository;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        
        /// <summary>
        /// Edit the text of an Item
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///    PUT /Todo
        ///     {
        ///         "itemId": 0,
        ///         "text": "string"
        ///     }
        /// </remarks>
        /// <param name="ListId"></param>
        /// <param name="ItemId"></param>
        /// <param name="model"></param>
        /// <returns>Returns list with new edits</returns>
        /// <response code="404">If The desired item is Not found !</response>
        /// <response code="200">Returns The list with new edits !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>            
        /// <response code="400">If Something wrong has happened ... !</response>
        [HttpPut]
        public async Task<ActionResult<ListOfItemsModel>> Put(int ListId,int ItemId, ItemsModel model)//EditItem
        {
            try
            {
                var oldItem = await _repository.GetItemAsync(ItemId);

                if (oldItem == null)
                {
                    return NotFound($"The item with id = {ItemId} is Notu foundu !");
                }

                _mapper.Map(model, oldItem);
                if (await _repository.SaveChangesAsync())
                {
                    var list = await _repository.GetListAsync(ListId);
                    return _mapper.Map<ListOfItemsModel>(list);
                }
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Shekloo error ya kbeer !");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete an Item
        /// </summary>
        /// <param name="ListId"></param>
        /// <param name="ItemId"></param>
        /// <returns>Returns The status after deletion</returns>
        /// <response code="404">If The item you want to delete is already not existed !</response>
        /// <response code="200">If item was deleted successfully !</response>
        /// <response code="500">If Something bad happened (Internal Server Error)</response>
        /// <response code="404">If Could not delete the desired item</response>
        [HttpDelete]
        public async Task<ActionResult<ListOfItemsModel>> Delete(int ListId, int ItemId) //DeleteItem
        {
            try
            {
                var item = await _repository.GetItemAsync(ItemId);
                if (item == null)
                {
                    return NotFound("The item you want to delete is already not existed !");
                }
            
                _repository.Delete(item);

                if (await _repository.SaveChangesAsync())
                {
                    var list = await _repository.GetListAsync(ListId);
                    return _mapper.Map<ListOfItemsModel>(list);
                    //return Ok();
                }
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Something bad happened");
            }
            return BadRequest("Could not delete the desired item");
        }
    }
}
