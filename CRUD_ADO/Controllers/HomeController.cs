using CRUD_ADO.DAL.ProdutoDAL;
using CRUD_ADO.Models;
using CRUD_VICENTE.DAL;
using CRUD_VICENTE.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_VICENTE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
          
            return View();
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




        public IActionResult DeletarProduto(int id)
        {
            ProdutoModel prod = new ReadProdutoDAL().listarPorId(id);
            return View(prod);
        }

        
        public IActionResult DeletarProdutoEfetivamente(int id)
        {
            ReadProdutoDAL readProdutoDAL = new ReadProdutoDAL();
            DeleteProdutoDAL deleteProdutoDAL = new DeleteProdutoDAL();
            var produto = readProdutoDAL.listarPorId(id);
            deleteProdutoDAL.DeletarProdutoEfetivamente(produto);
            return RedirectToAction("Listar");
        }


        public IActionResult Listar()
        {
            List<ProdutoModel> prod = new ReadProdutoDAL().listarTodos();

            return View(prod);
        }

        public IActionResult Detalhar(int id)
        {
            ProdutoModel prod = new ReadProdutoDAL().listarPorId(id);
            return View(prod);
        }

        public IActionResult Inserir()
        {
            return View();
        }

        [HttpPost, ActionName("Inserir")]
        public IActionResult Inserir(ProdutoModel produto)
        {
            InsertProdutoDAL insertProdutoDAL = new InsertProdutoDAL();
            if (ModelState.IsValid)
            {
                insertProdutoDAL.InserirProduto(produto);

                return RedirectToAction("Listar");
            }

            return RedirectToAction("Listar");
        }


        public IActionResult Editar(int id)
        {
            ReadProdutoDAL readProdutoDAL = new ReadProdutoDAL();
            var produto = readProdutoDAL.listarPorId(id);
            return View(produto);
        }

        [HttpPost,ActionName("Editar")]
        public IActionResult Editar(ProdutoModel produto )
        {
            UpdateProdutoDAL updateProdutoDAL = new UpdateProdutoDAL();
            updateProdutoDAL.EditarProduto(produto);
            return RedirectToAction("Listar");
        }

      
    }
}


