using CRUD_ADO.DAL.ProdutoDAL;
using CRUD_ADO.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.Controllers
{
    public class CrudProdutoController : PrincipalController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeletarProduto(int id)
        {
            ProdutoModel prod = new ReadProdutoDAL().listarPorId(id);
            return View(prod);
        }

        [HttpPost,ActionName("DeletarProduto")] //FAZENDO DESSA FORMA ELE EXCLUI USANDO O ID USANDO NO METODO DELETARPRODUTO
        [HttpPost]
        public IActionResult DeletarProdutoEfetivamente(int id)
        {
            DeleteProdutoDAL deleteProdutoDAL = new DeleteProdutoDAL();
            deleteProdutoDAL.DeletarProdutoEfetivamente(id);
            return RedirectToAction("Listar");
        }

        [Authorize]

        public IActionResult Listar()
        {
            List<ProdutoModel> prod = new ReadProdutoDAL().ListarTodos();

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
        [HttpPost]
        public IActionResult InserirEfetivamente(ProdutoModel produto)
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

        [HttpPost, ActionName("Editar")]
        public IActionResult Editar(ProdutoModel produto)
        {
            UpdateProdutoDAL updateProdutoDAL = new UpdateProdutoDAL();
            updateProdutoDAL.EditarProduto(produto);
            return RedirectToAction("Listar");
        }


        



    }
}
