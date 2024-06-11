using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class PosicaoVeiculo
    {
        [Key]
        public string Id { get; set; }                  
        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public int VeiculoFkId { get; set; }

        [ForeignKey("VeiculoFkId")]
        public Veiculo Veiculo { get; set; }
         

        
    }
}
