using System.ComponentModel.DataAnnotations;

namespace ContasApp.Services.Models
{
    public class ContaPostModel
    {
        [Required(ErrorMessage = "Informe o nome da conta.")]
        public string? Nome { get; set; }
    
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "Informe o valor da conta.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe o tipo da conta.")]
        public string? Tipo { get; set; }
        
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Selecione a categoria da conta.")]
        public string? Categoria { get; set; }
    }
}
