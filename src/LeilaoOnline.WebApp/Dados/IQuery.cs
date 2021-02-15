using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeilaoOnline.WebApp.Dados
{
    public interface IQuery<T>
    {
        //Reader class object
        IEnumerable<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
