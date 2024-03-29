﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Todo.API.Models;
using Todo.API.Repositories;

namespace Todo.API.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ItemsController : Controller
{
    private readonly IItemRepository _itemRepository;

    public ItemsController(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    //POST: api/item
    [HttpPost]
    public async Task<ActionResult<Item>> Post(Item item)
    {
        var result = await _itemRepository.Insert(item);

        if (!result)
            return BadRequest();

        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    //GET: api/item
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> Get()
    {
        var items = await _itemRepository.GetTasks();
        return Ok(items);
    }

    //GET: api/item/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetById(int id)
    {
        var item = await _itemRepository.GetTask(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    //GET: api/item/complete/5
    [HttpPut("complete/{id}")]
    public async Task<ActionResult<Item>> CompleteTask(int id)
    {
        var result = await _itemRepository.CompleteTask(id);
        if (!result)
            return NotFound();

        return Ok();
    }

    //DELETE: api/item/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        return Ok();
    }
}

