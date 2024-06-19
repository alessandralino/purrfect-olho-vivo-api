using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Services
{
    public interface ILinhaService
    {
        Task<LinhaGetAllResponse> GetAll();
        Task<Linha> GetLinhaById(int id);
        Task<Linha> CreateLinha(LinhaCreateRequest request);
        Task<Linha> UpdateLinha(int id, LinhaUpdateRequest request);
        Task<bool> DeleteLinha(long id);
        Task<IEnumerable<Linha>> GetLinhaPorParada(int idParada);
    }
}
