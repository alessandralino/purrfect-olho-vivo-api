using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class ParadaCreateRequest
    {
        public string Name { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
    }
}
