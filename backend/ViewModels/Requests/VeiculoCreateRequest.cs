
using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class VeiculoCreateRequest
    {
        public string Name { get; set; }
        public string Modelo { get; set; }
        public long linhaId { get; set; }

    }
}
