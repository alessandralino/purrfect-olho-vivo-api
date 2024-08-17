using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class Linha
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Parada> Paradas { get; set; } = new List<Parada>(); 
    }
}
