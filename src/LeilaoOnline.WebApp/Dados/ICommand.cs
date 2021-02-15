using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeilaoOnline.WebApp.Dados
{
    public interface ICommand<T>
    {
        //Writer class object
        void Incluir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);
    }
}
