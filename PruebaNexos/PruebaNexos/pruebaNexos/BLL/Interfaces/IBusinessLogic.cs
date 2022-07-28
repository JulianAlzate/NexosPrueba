using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IBusinessLogic<T> where T : class
    {
        IList<T> ListAll();
        string Crear(T model);
        T Buscar(params object[] keyValues);
    }
}
