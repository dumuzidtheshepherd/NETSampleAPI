using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NETSample.Models;
using NETSample.Models.DTOs;

namespace NETSample.Mappers
{
    public class DTOMapping : Profile
    {
        public DTOMapping()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
        }
    }
}
