using purrfect_olho_vivo_api.ViewModels.Models;
namespace purrfect_olho_vivo_api.ViewModels.Responses
{
    public class VeiculoCreateResponse
    { 
        public int Id { get; set; }

        public string Name { get; set; }

        public string Modelo { get; set; }  

        public Linha Linha { get; set; }

    }
}
