using Entities;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.interfaces;

namespace RestaurantApi.Controller;
[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserRepository repository;

    public UsersController(UserRepository repository)
    {
        this.repository = repository;
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute(Name ="id")]int id)
    {
        repository.Delete(id);
        return Ok();
    }
    [HttpGet]
    public IActionResult GetOne(int id)
    {
        var item = repository.GetOne(id);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    [HttpPost("register")]
    public IActionResult Register(User item)
    {
        if (item is null)
        {
            return BadRequest();
        }
        repository.Post(item);
        return Created("The user has been added succesfully!!",item);
    }
    [HttpPost("LogIn")]
    public IActionResult LogIn(string email, string password){
        var item = repository.GetData(email,password);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(item);
    }
}