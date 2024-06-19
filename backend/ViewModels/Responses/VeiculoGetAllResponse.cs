using purrfect_olho_vivo_api.ViewModels.Models;

namespace purrfect_olho_vivo_api.ViewModels.Responses
{
    public class VeiculoGetAllResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Modelo { get; set; }

        public Linha Linha { get; set; }

    }
}
