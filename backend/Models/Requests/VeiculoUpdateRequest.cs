using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class VeiculoUpdateRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Modelo { get; set; }
        public long LinhaId { get; set; }

    }
}
