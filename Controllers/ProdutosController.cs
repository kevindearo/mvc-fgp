using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProdutosWeb.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: /<controller>/
        [Route("/produtos/index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/categoria/{id:int?}")]
        public IActionResult Categoria(int id)
        {
            ViewData["id"] = id;
            return View();
        }

        [Route("/produtos/listagem/{id:int?}")]
        public IActionResult Listagem(int id)
        {
            ViewData["id"] = id;
            return View();
            //return Content("Listagem de produtos do fornecedor: "
            //    + id.ToString()
            //    );
        }

        [Route("/produtos/catalogo")]
        public IActionResult Catalogo()
        {
            var conteudo = System.IO.File.ReadAllBytes(@"c:/TEMP/Catalogo.txt");
            var nome = "CatalogoDeProdutos.txt";
            return File(conteudo,
                System.Net.Mime.MediaTypeNames.Application.Octet, nome);

        }

    }
}
