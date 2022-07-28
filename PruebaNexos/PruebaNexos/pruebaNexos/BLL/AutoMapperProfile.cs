using AutoMapper;
using BLL.DTO;
using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Libro, LibroDTO>().ReverseMap();
            CreateMap<Autor, AutorDTO>().ReverseMap();
        }

    }
}
