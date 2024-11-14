using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using NETSample.Interfaces;
using NETSample.Models;
using NETSample.Models.DTOs;
using AutoMapper;

namespace NETSample.Services
{
    public class BookService : IBookService
    {
        private readonly SampleDbContext _context;
        private readonly IMapper _mapper;

        public BookService(SampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> GetAllBooksAsync()
        {
            List<Book> books = await _context.Books.ToListAsync();
            return _mapper.Map<IEnumerable<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> AddBookAsync(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> UpdateBookAsync(int id, BookDTO bookDTO)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _mapper.Map(bookDTO, book);
                await _context.SaveChangesAsync();
                return _mapper.Map<BookDTO>(book);
            } else
            {
                return null;
            }
        } 

        public async Task<bool> RemoveBookAsync(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            } else
            {
                return false;
            }
        }
    }
}
