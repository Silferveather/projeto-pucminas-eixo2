using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace projeto_pucminas_eixo2.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a marca.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o prazo de validade.")]
        [Display(Name = "Validade")]
        public int PrazoValidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor do produto.")]
        [Display(Name = "Valor do produto")]
        public decimal ValorProduto { get; set; }
    }
}
