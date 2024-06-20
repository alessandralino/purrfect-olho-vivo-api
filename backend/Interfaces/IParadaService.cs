using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Interfaces
{
    public interface IParadaService
    {
        Task<IEnumerable<Parada>> GetAll();
        Task<ActionResult<Parada>> GetParadaById(long id);
        Task<IEnumerable<Parada>> GetParadaByPosicao(ParadaGetByPosicaoRequest request);
        Task<Parada> Create(ParadaCreateRequest request);        
        Task<ParadaUpdateResponse> Update(int id, Parada parada);
        Task<bool> Delete(long id);
        bool ParadaExists(int id);
    }
}
