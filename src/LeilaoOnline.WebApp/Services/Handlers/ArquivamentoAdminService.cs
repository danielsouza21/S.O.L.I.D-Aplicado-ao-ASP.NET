using LeilaoOnline.WebApp.Dados;
using LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace LeilaoOnline.WebApp.Services.Handlers
{
    public class ArquivamentoAdminService : IAdminService
    {
        IAdminService _defaultService; //handler default 

        // Classe altera algumas implementações especificas, chamando 
        //serviço default em casos gerais

        public ArquivamentoAdminService(ILeilaoDAO LeilaoDAO)
        {
            _defaultService = new DefaultAdminService(LeilaoDAO);;
        }

        public void CadastraLeilao(Leilao leilao)
        {
            _defaultService.CadastraLeilao(leilao);
        }

        public IEnumerable<Categoria> ConsultaCategorias()
        {
            return _defaultService.ConsultaCategorias();
        }

        public Leilao ConsultaLeilaoPorId(int id)
        {
            return _defaultService.ConsultaLeilaoPorId(id);
        }

        public IEnumerable<Leilao> ConsultaLeiloes()
        {
            //Mudança de implementação
            return _defaultService.ConsultaLeiloes().Where(l => l.Situacao != SituacaoLeilao.Arquivado);
        }

        public void FinalizaPregaoDoLeilaoComId(int id)
        {
            _defaultService.FinalizaPregaoDoLeilaoComId(id);
        }

        public void IniciaPregaoDoLeilaoComId(int id)
        {
            _defaultService.IniciaPregaoDoLeilaoComId(id);
        }

        public void ModificaLeilao(Leilao leilao)
        {
            _defaultService.ModificaLeilao(leilao);
        }

        public void RemoveLeilao(Leilao leilao)
        {
            //Mudança de implementação
            if ((leilao != null) && (leilao.Situacao != SituacaoLeilao.Pregao))
            {
                leilao.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.ModificaLeilao(leilao);
            }
        }
    }
}
