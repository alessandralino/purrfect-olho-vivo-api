using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class LinhaUpdateRequest
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public List<long> Paradas { get; set; }
    }
}
