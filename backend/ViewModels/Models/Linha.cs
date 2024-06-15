using System.ComponentModel.DataAnnotations;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class Linha
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Parada> Paradas { get; set; }
    }
}
