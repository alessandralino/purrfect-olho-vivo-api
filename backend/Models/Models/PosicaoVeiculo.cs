using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class PosicaoVeiculo
    {
        [Key]
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // Chave estrangeira para Veiculo
        public long VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}
