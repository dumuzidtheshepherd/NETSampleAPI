using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETSample.Models.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string YearPublished { get; set; }
        public int NumberSold { get; set; }
    }
}
