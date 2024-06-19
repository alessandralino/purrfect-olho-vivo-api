using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class ParadaGetByPosicaoRequest
    { 
        public long latitude { get; set; }
        public long longitude { get; set; }
    }
}
