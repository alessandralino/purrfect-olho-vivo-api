
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace purrfect_olho_vivo_api.ViewModels.Models
{
    public class Veiculo
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Modelo { get; set; }
         
        public int LinhaFkId { get; set; }
         
        [ForeignKey("LinhaFkId")]
        public Linha Linha { get; set; }
    }
}