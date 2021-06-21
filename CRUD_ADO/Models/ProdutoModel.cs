using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_VICENTE.Models
{
    public class ProdutoModel
    {
        [DisplayName("Código")]
        public int Id { get; set; }

        [DisplayName("Nome do Produto")]
        [Required(ErrorMessage = "Informe o nome do produto!")]
        public string NomeProduto { get; set; }

        [DisplayName("Preço")]
        [Required(ErrorMessage = "Informe o preço do produto!")]
        public double Preco { get; set; }

    }
}
