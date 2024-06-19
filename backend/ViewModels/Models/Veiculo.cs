
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class Veiculo
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Modelo { get; set; }

        // Chave estrangeira para Linha
        public long LinhaId { get; set; }
        public Linha Linha { get; set; }

        // Relação um-para-muitos com PosicaoVeiculo
        public ICollection<PosicaoVeiculo> PosicoesVeiculo { get; set; } = new List<PosicaoVeiculo>();
    }
}