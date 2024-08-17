using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Interfaces
{
    public interface ILinhaService
    {
        Task<LinhaGetAllResponse> GetAll(LinhaGetRequest request);
        Task<Linha> Create(LinhaCreateRequest request);
        Task<Linha> Update(int id, LinhaUpdateRequest request);
        Task<bool> Delete(long id);
        Task<Linha> GetLinhaById(int id);
        Task<IEnumerable<Linha>> GetLinhaPorParada(int idParada);
    }
}
