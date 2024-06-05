using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ItemsController(ApplicationDbContext context)
    {
        _context = context;

        // Initialize sample items if the database is empty
        if (!_context.Items.Any())
        {
            _context.Items.AddRange(new List<Item>
            {
                new Item { Name = "Sample Item 1", Description = "Description of Sample Item 1", Category = "Category A" },
                new Item { Name = "Sample Item 2", Description = "Description of Sample Item 2", Category = "Category B" },
                new Item { Name = "Sample Item 3", Description = "Description of Sample Item 3", Category = "Category C" }
            });
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Item>> GetItems()
    {
        return _context.Items.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<Item> GetItem(int id)
    {
        var item = _context.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return item;
    }

    [HttpPost]
    public ActionResult<Item> PostItem(Item item)
    {
        _context.Items.Add(item);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult PutItem(int id, Item item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        var existingItem = _context.Items.Find(id);
        if (existingItem == null)
        {
            return NotFound();
        }

        existingItem.Name = item.Name;
        existingItem.Description = item.Description;
        existingItem.Category = item.Category;

        _context.SaveChanges();
        return NoContent();
    }
}
