using ContasApp.Data.Enums;

namespace ContasApp.Services.Models
{
    public class ContaGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataCriacao  { get; set; }
        public decimal? Valor { get; set; }
        public TipoConta? Tipo { get; set; }
        public string? Observacao { get; set; }
        public Categorias? Categoria { get; set; }
    }
}
