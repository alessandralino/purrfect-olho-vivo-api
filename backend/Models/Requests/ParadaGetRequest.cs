using purrfect_olho_vivo_api.Models.Requests;
using purrfect_olho_vivo_api.ViewModels.Models;
using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace purrfect_olho_vivo_api.ViewModels.Requests
{
    public class ParadaGetRequest : FiltroRequest
    {
        public long? Id { get; set; }
        public string? Name { get; set; }
        public long? Latitude { get; set; }
        public long? Longitude { get; set; }  
    }
}
