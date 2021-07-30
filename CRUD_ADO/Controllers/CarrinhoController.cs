using CRUD_ADO.DAL.ProdutoDAL;
using CRUD_ADO.DAL.CarrinhoDAL;
using CRUD_ADO.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ADO.Controllers
{
    public class CarrinhoController : PrincipalController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarNoCarrinho(int id)
        {
            ProdutoModel prod = new ReadProdutoDAL().listarPorId(id);
            InsertProdutoCarrinhoDAL prodCarrinho = new InsertProdutoCarrinhoDAL();
            prodCarrinho.InsertProdutoCarrinho(id, "vicente");
            return View(prod);
        }

        public IActionResult ListarProdutosDoCarrinho()
        {
            ReadProdutoCarrinhoDAL prodCarrinho = new ReadProdutoCarrinhoDAL();
            var prods = prodCarrinho.GerarListaProdutosCarrinho();
            return View(prods);
        }

        public IActionResult RemoverDoCarrinho(int id)
        {
            DeleteProdutoCarrinhoDAL delProdCarrinhoDAL = new DeleteProdutoCarrinhoDAL();
            delProdCarrinhoDAL.RemoverProdutoCarrinho(id);
            return RedirectToAction(nameof(ListarProdutosDoCarrinho));
        }


        public IActionResult FinalizarCompraCarrinho()
        {
            ReadProdutoCarrinhoDAL prodCarrinho = new ReadProdutoCarrinhoDAL();
            UpdateProdutoDAL prodUpdateDAL = new UpdateProdutoDAL();
            
            prodUpdateDAL.AtualizarQuantidadeProdutos();
            DeleteProdutoCarrinhoDAL deleteProdutoCarrinhoDAL = new DeleteProdutoCarrinhoDAL();
            deleteProdutoCarrinhoDAL.RemoverTodosProdutosCarrinho();
            var prods = prodCarrinho.GerarListaProdutosCarrinho();
            return View(prods);
        }
    }
}
