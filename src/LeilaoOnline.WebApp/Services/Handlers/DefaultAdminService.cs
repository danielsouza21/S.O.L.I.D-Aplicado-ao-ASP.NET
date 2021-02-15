using LeilaoOnline.WebApp.Dados;
using LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDAO _LeilaoDAO;

        public DefaultAdminService(ILeilaoDAO LeilaoDAO)
        {
            _LeilaoDAO = LeilaoDAO;
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _LeilaoDAO.BuscarCategorias();
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            return _LeilaoDAO.BuscarTodos();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _LeilaoDAO.BuscarPorId(id);
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _LeilaoDAO.Incluir(leilao);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _LeilaoDAO.Alterar(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            if (leilao != null && leilao.Situacao != SituacaoLeilao.Pregao)
            {
                _LeilaoDAO.Excluir(leilao);
            }
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            var leilao = _LeilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Pregao)
            {
                leilao.Situacao = SituacaoLeilao.Finalizado;
                leilao.Termino = DateTime.Now;
                _LeilaoDAO.Alterar(leilao);
            }
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            var leilao = _LeilaoDAO.BuscarPorId(id);
            if (leilao != null && leilao.Situacao == SituacaoLeilao.Rascunho)
            {
                leilao.Situacao = SituacaoLeilao.Pregao;
                leilao.Inicio = DateTime.Now;
                _LeilaoDAO.Alterar(leilao);
            }
        }
    }
}
