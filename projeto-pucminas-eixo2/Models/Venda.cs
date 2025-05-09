using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace projeto_pucminas_eixo2.Models
{
    [Table("Vendas")]
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o cliente.")]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a data.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o valor.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade.")]
        [Display(Name = "Quantidade")]
        public int QuantidadeVenda { get; set; }

        [Display(Name = "Tipo de pagamento")]
        public TipoPagamento Tipo { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o produto.")]
        [Display(Name = "Produto")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto Produto { get; set; }
    }

    public enum TipoPagamento
    {
        Crédito,
        Débito,
        Dinheiro,
        PIX
    }
}
