using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Responses
{
    public class LinhaGetAllResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<Parada> Paradas { get; set; } = new List<Parada>();
    }
}
