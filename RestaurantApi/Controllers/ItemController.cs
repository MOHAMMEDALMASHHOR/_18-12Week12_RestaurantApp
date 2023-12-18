using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace RestaurantApi.Controller;
[ApiController]
[Route("api/items")]
public class ItemController:ControllerBase
{
    private readonly ItemsRepository itemsRepository;

    public ItemController(ItemsRepository itemsRepository)
    {
        this.itemsRepository = itemsRepository;
    }
    [HttpGet]
    public IActionResult GetAll(){
        return Ok(itemsRepository.GetAll());
    }
    [HttpGet("{id:int}")]
    public IActionResult GetOne([FromRoute(Name ="id")]int id){
        var item = itemsRepository.GetOne(id);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(itemsRepository.GetAll());
    }
    [HttpPost]
    public IActionResult Post(Items items){
       if (items is null)
       {
        return BadRequest();
       }
       return Created("The item is created successfully!!!", items);
    }
    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute(Name ="id")]int id){
        var item = itemsRepository.GetOne(id);
        if (item is null)
        {
            return NotFound();
        }
        itemsRepository.Delete(id);
        return NoContent();
    }
}