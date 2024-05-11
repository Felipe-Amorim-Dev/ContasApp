using ContasApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ContasApp.Services.Models
{
    public class ContaPutModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Informe o nome da conta.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Informe a data da conta.")]
        public DateTime? DataCriacao { get; set; }

        [Required(ErrorMessage = "Informe o valor da conta.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Informe o tipo da conta.")]
        public TipoConta? Tipo { get; set; }

        [Required(ErrorMessage = "Informe as observações da conta.")]
        public string? Observacao { get; set; }

        [Required(ErrorMessage = "Selecione a categoria da conta.")]
        public Categorias? Categorias { get; set; }
    }
}
