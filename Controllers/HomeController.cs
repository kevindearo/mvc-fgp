using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdutosWeb.Models;

namespace ProdutosWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("/home/index")] --quando adicionado nao carrega pagina inicial
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacidade")]
        [Route("politicas-de-privacidade")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("sobre")]
        public IActionResult QuemSomos()
        {
            return View();
        }

        [Route("contatos")]
        [Route("/home/contatos")]
        public IActionResult Contatos()
        {
            return View();
        }

        public IActionResult Fornecedores()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
