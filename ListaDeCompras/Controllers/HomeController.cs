using System.Diagnostics;
using ListaDeCompras.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompras.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ListaDeComprasDbContext _context;

        public HomeController(ILogger<HomeController> logger, ListaDeComprasDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListaDeCompras()
        {
            var listaDeComprasCompleta = _context.Items.ToList();

            var somatorioListaDeCompras = listaDeComprasCompleta.Sum(item => item.Valor);
            ViewBag.Items = somatorioListaDeCompras;

            return View(listaDeComprasCompleta);
        }

        public IActionResult CriarEditarItem(int? id)
        {
            if (id != null) 
            {
                var item = _context.Items.SingleOrDefault(item => item.Id == id);
                return View(item);
            }

            return View();
        }

        public IActionResult DeletarItem(int id)
        {
            var item = _context.Items.SingleOrDefault(item => item.Id == id);
            _context.Items.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("ListaDeCompras");
        }

        public IActionResult FormCriarEditarItem(Item item)
        {
            if (item.Id == 0)
            {
                _context.Items.Add(item);
            } else
            {
                _context.Items.Update(item);
            }
            _context.SaveChanges();

            return RedirectToAction("ListaDeCompras");
        }

        public IActionResult Privacy()
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
