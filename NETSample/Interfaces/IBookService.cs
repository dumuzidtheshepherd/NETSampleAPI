using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NETSample.Models;
using NETSample.Models.DTOs;

namespace NETSample.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        Task<BookDTO> AddBookAsync(BookDTO bookDTO);
        Task<BookDTO> UpdateBookAsync(int id, BookDTO bookDTO);
        Task<bool> RemoveBookAsync(int id);
    }
}
