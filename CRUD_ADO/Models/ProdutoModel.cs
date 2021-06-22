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
        [DisplayName("CÓDIGO")]
        public int Id { get; set; }

        [DisplayName("NOME DO PRODUTO")]
        [Required(ErrorMessage = "INFORME O NOME DO PRODUTO")]
        public string NomeProduto { get; set; }

        [DisplayName("PREÇO")]
        [Required(ErrorMessage = "INFORME O PREÇO DO PRODUTO")]
        public double Preco { get; set; }

    }
}
