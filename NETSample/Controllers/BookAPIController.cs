using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NETSample.Interfaces;
using NETSample.Models.DTOs;
using System.Web.Http;

namespace NETSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookAPIController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookAPIController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDTO>>> GetAll()
        {
            IEnumerable<BookDTO> books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDTO>> GetById(int id)
        {
            BookDTO book = await _bookService.GetBookByIdAsync(id);
            if (book != null) return Ok(book);
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<BookDTO>> Add([FromBody] BookDTO bookDTO)
        {
            BookDTO newBook = await _bookService.AddBookAsync(bookDTO);
            return CreatedAtAction(nameof(GetById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BookDTO>> Update(int id, [FromBody] BookDTO bookDTO)
        {
            BookDTO updatedBook = await _bookService.UpdateBookAsync(id, bookDTO);
            if (updatedBook != null) return Ok(updatedBook);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Remove(int id)
        {
            bool removed = await _bookService.RemoveBookAsync(id);
            if (removed) return NoContent();
            return NotFound();
        }
    }
}
