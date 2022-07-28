using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DataBase.DbManager;
using DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.RN
{
    public class AutorBLL : IBusinessLogic<AutorDTO>
    {
        private readonly IMapper _mapper;
        public Repositorio<Autor> repoAutor;
        public AutorBLL(IMapper mapper)
        {
            _mapper = mapper;
            repoAutor = new Repositorio<Autor>(new NexosContext());
        }

        public string Crear(AutorDTO model)
        {
            string Error = string.Empty;
            try
            {
                Autor autor = _mapper.Map<Autor>(model);
                repoAutor.Crear(autor);
                repoAutor.Confirmar();
            }
            catch (Exception ex)
            {
                Error = ex.Message;
            }
            return string.Empty;
        }

        public IList<AutorDTO> ListAll()
        {
            List<Autor> modelBD = repoAutor.Listar.ToList();
            List<AutorDTO> modelDTO = _mapper.Map<List<AutorDTO>>(modelBD);
            return modelDTO;
        }

        AutorDTO IBusinessLogic<AutorDTO>.Buscar(params object[] keyValues)
        {
            Autor modelBD = repoAutor.BuscarPorId(keyValues);
            AutorDTO modelDTO = _mapper.Map<AutorDTO>(modelBD);
            return modelDTO;
        }
    }
}
