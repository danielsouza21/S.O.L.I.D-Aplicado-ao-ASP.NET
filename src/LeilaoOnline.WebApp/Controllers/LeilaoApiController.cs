using Microsoft.AspNetCore.Mvc;
using LeilaoOnline.WebApp.Models;
using LeilaoOnline.WebApp.Dados;

namespace LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        //AppDbContext _context;
        ILeilaoDAO _dao;

        public LeilaoApiController(ILeilaoDAO dao)
        {
            _dao = dao;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _dao.BuscarLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _dao.BurcarPorId(id);
            
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _dao.Incluir(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            _dao.Alterar(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _dao.BurcarPorId(id);

            if (leilao == null)
            {
                return NotFound();
            }

            _dao.Excluir(leilao);
            return NoContent();
        }


    }
}
