using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DataBase.DbManager;
using DataBase.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BLL.RN
{
    public class LibroBLL : IBusinessLogic<LibroDTO>
    {
        private readonly IMapper _mapper;
        public Repositorio<Libro> repoLibro;
        IConfigurationRoot _configuration;
       // public LibroBLL(IMapper mapper, IConfigurationRoot config)
        public LibroBLL(IMapper mapper)
        {
            _mapper = mapper;
            //_configuration = config;
            repoLibro = new Repositorio<Libro>(new NexosContext());


        }
        public List<LibroDTO> BuscarLibro(params object[] keyValues)
        {
            List<LibroDTO> usuariosDest = new List<LibroDTO>();

            return usuariosDest;

        }

        public IList<LibroDTO> ListAll()
        {
            List<LibroDTO> modelDTO = new List<LibroDTO>();
            //SOlución temporal
            using (var db = new NexosContext())
            {
                var libros = db.Libros.Include(x => x.Autor).ToList();
                modelDTO = _mapper.Map<List<LibroDTO>>(libros);
            }
            //List<Libro> modelBD = repoLibro.Listar.ToList();           
            //List<LibroDTO> modelDTO = _mapper.Map<List<LibroDTO>>(modelBD);
            return modelDTO;
        }

        public string Crear(LibroDTO model)
        {
            string Error = string.Empty;

            try
            {
                if (!ValLibroAutor(model.IdAutor))
                {
                    return "No es posible registrar el libro, se alcanzó el máximo permitido.";
                }
                Libro lib = _mapper.Map<Libro>(model);
                repoLibro.Crear(lib);
                repoLibro.Confirmar();
            }
            catch (Exception ex)
            {

                Error = ex.Message;
            }



            return Error;
        }

        public LibroDTO Buscar(params object[] keyValues)
        {
            Libro modelBD = repoLibro.BuscarPorId(keyValues);
            LibroDTO modelDTO = _mapper.Map<LibroDTO>(modelBD);
            return modelDTO;
        }

        private bool ValLibroAutor(int IdAutor)
        {
            int totalLibros = ListAll().Count(x => x.IdAutor == IdAutor);
           // int.TryParse(_configuration.GetSection("LibrosPermitidos").Value, out int librosPermitidos);
            if (totalLibros >= 3)
            {
                return false;
            }
            return true;
        }

    }
}
