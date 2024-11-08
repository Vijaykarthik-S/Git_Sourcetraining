using DTO_demo.DTO;
using DTO_demo.Mappings;
using DTO_demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DTO_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyContext _context;
        public BooksController(MyContext context)
        {
            _context = context;
        }
    }
    [HttpGet]
    public async Task<ActionResult<List<BookDTO>>> GetBooks()
    {
       List<Book> books = _context.Book.ToList();
        if (books != null)
        {
           List<BookDTO> bookDTOs = books.ToDTOList();
            return bookDTOs;
        }
        else
        { return NotFound(); }

        
    }
    
}
