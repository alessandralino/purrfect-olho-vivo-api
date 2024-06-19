using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class Parada
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonIgnore]
        public ICollection<Linha> Linhas { get; set; } = new List<Linha>();
    }
}
