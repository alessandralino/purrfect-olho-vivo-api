using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace purrfect_olho_vivo_api.Interfaces
{
    public interface IVeiculoService
    {
        Task<IEnumerable<VeiculoGetAllResponse>> GetAll(VeiculoGetRequest request);
        Task<ActionResult<Veiculo>> GetVeiculoById(long id);
        Task<IEnumerable<Veiculo>> GetVeiculoByLinha(int idLinha);
        Task<VeiculoCreateResponse> Create(VeiculoCreateRequest request);
        Task<bool> Delete(int id);
        Task<VeiculoUpdateResponse>Update(long id, VeiculoUpdateRequest request);
    }
}
