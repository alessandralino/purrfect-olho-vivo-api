using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace purrfect_olho_vivo_api.Models.Requests
{
    public abstract class FiltroRequest
    {
        [Required(ErrorMessage = "A página é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "O número da página deve ser maior que zero.")]
        public int pageNumber { get; set; }

        [Required(ErrorMessage = "A quantidade de itens por página é obrigatória")]
        [Range(1, 50, ErrorMessage = "O tamanho da página deve estar entre 1 e 50.")]
        public int pageSize { get; set; }
    }
}
