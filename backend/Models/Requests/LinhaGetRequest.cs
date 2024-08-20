using purrfect_olho_vivo_api.Models.Requests;
using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class LinhaGetRequest : FiltroRequest
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public long? IdParada { get; set; }
    }
}
