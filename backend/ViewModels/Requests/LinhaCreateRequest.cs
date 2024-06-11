using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class LinhaCreateRequest
    {
        public string Name { get; set; }

        public List<Parada> Paradas { get; set; }
    }
}
