using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using LeilaoOnline.WebApp.Services;

namespace LeilaoOnline.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IProdutoService _service;

        public HomeController(IProdutoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var categorias = _service.ConsultaCategoriasComTotalDeLeiloesEmPregao();
            return View(categorias);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoria}")]
        public IActionResult Categoria(int categoriaId)
        {
            var categoria = _service.ConsultaCategoriaPorIdComLeiloesEmPregao(categoriaId);
            return View(categoria);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string termo)
        {
            ViewData["termo"] = termo; 
            var leiloes = _service.PesquisaLeiloesEmPregaoPorTermo(termo);
            return View(leiloes);
        }
    }
}
