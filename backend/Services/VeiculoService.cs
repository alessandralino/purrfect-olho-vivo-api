using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.Domain;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly AppDbContext _context;

        public VeiculoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<VeiculoCreateResponse> Create(VeiculoCreateRequest request)
        {
            var veiculo = await CriarVeiculo(request);

            await _context.SaveChangesAsync();

            var veiculoWithLinha = await BuscarVeiculo(veiculo.Id);

            if (veiculoWithLinha == null)
            {
                throw new Exception("Veículo não encontrado após criação");
            }

            return formatarVeiculoCreateResponse(veiculoWithLinha);

        }

        private async Task<Veiculo> CriarVeiculo(VeiculoCreateRequest request)
        {
            var veiculo = new Veiculo
            {
                Name = request.Name,
                Modelo = request.Modelo,
                LinhaId = request.linhaId
            };

            _context.Veiculo.Add(veiculo);

            return veiculo;
        }

        private async Task<Veiculo> BuscarVeiculo(long veiculoId)
        {
            return await _context.Veiculo
                .Include(v => v.Linha)
                .ThenInclude(l => l.Paradas)
                .FirstOrDefaultAsync(v => v.Id == veiculoId);
        }

        private VeiculoCreateResponse formatarVeiculoCreateResponse(Veiculo veiculoWithLinha)
        {
            return new VeiculoCreateResponse
            {
                Id = veiculoWithLinha.Id,
                Name = veiculoWithLinha.Name,
                Modelo = veiculoWithLinha.Modelo,
                Linha = new Linha
                {
                    Id = veiculoWithLinha.Linha.Id,
                    Name = veiculoWithLinha.Linha.Name,
                    Paradas = veiculoWithLinha.Linha.Paradas.Select(p => new Parada
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude,
                    }).ToList()
                }
            };
        }
        
        public async Task<bool> Delete(int id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);
            
            if (veiculo == null)
            {
                return false;
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return true;
        }


        public async Task<PagedList<VeiculoGetAllResponse>> GetAll(VeiculoGetRequest request)
        {
            var query = _context.Veiculo.AsQueryable();

            if (request?.Id.HasValue == true)
            {
                query = query.Where(v => v.Id == request.Id.Value);
            }

            if (!string.IsNullOrEmpty(request?.Name))
            {
                query = query.Where(v => v.Name.Contains(request.Name));
            }

            if (!string.IsNullOrEmpty(request?.Modelo))
            {
                query = query.Where(v => v.Modelo.Contains(request.Modelo));
            }

            if (request?.LinhaId.HasValue == true)
            {
                query = query.Where(v => v.LinhaId == request.LinhaId.Value);
            }

            // Total de itens antes da paginação
            var totalItems = await query.CountAsync();

            var lista = await query
                .Include(l => l.Linha)
                .ThenInclude(p => p.Paradas)
                .Skip((request!.pageNumber - 1) * request.pageSize)
                .Take(request.pageSize)
                .AsNoTracking()
                .ToListAsync();

            List<VeiculoGetAllResponse> responseList = formatarGetAllResponse (lista);

            if (responseList.Any())
            {
                var pagedResult = new PagedList<VeiculoGetAllResponse>(
                    responseList,
                    request!.pageNumber,
                    request.pageSize,
                    totalItems
                );

                return pagedResult;
            }
            else
            {
                throw new KeyNotFoundException("Nenhum Veículo encontrado.");
            } 
           
        }

        private static List<VeiculoGetAllResponse> formatarGetAllResponse(List<Veiculo> lista)
        {
            return lista.Select(v => new VeiculoGetAllResponse
            {
                Id = v.Id,
                Name = v.Name,
                Modelo = v.Modelo,
                Linha = new Linha
                {
                    Id = v.Linha.Id,
                    Name = v.Linha.Name,
                    Paradas = v.Linha.Paradas.Select(p => new Parada
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude,
                    }).ToList()
                }
            }).ToList();
        }

        public async Task<ActionResult<Veiculo>> GetVeiculoById(long id)
        {
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
               throw new KeyNotFoundException("Veiculo not found");
            }

            Veiculo? veiculoWithLinha = await BuscarVeiculoWithLinhaById(veiculo);

            return veiculoWithLinha;
        }

        private async Task<Veiculo?> BuscarVeiculoWithLinhaById(Veiculo? veiculo)
        {
            return await _context.Veiculo
            .Include(v => v.Linha)
            .FirstOrDefaultAsync(v => v.Id == veiculo.Id);
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculoByLinha(int idLinha)
        {
            return await _context.Veiculo
               .Where(v => v.LinhaId == idLinha)
               .ToListAsync();
        }

        public async Task<VeiculoUpdateResponse> Update(long id, VeiculoUpdateRequest request)
        {
            Veiculo veiculo = new Veiculo 
            {
                Id = id,
                Name = request.Name,
                LinhaId = request.LinhaId,
                Modelo = request.Modelo            
            };

            if (id != request.Id)
            {
                throw new ArgumentException("ID do veículo não corresponde ao ID fornecido.");
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            var veiculoResponse = new VeiculoUpdateResponse();

            try
            {
                await _context.SaveChangesAsync();

                var veiculoWithLinha = await _context.Veiculo
                .Include(v => v.Linha)
                .ThenInclude(p => p.Paradas)
                .FirstOrDefaultAsync(v => v.Id == veiculo.Id);

                if (veiculoWithLinha == null)
                {
                    throw new KeyNotFoundException("Veículo não encontrado após atualização.");
                }

                veiculoResponse = formatarUpdateResponse (veiculoWithLinha);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
                {
                    throw new KeyNotFoundException("Veículo não encontrado para atualização.");
                }
                else
                {
                    throw;
                }
            }

            return veiculoResponse;
            
        }

        private static VeiculoUpdateResponse formatarUpdateResponse(Veiculo? veiculoWithLinha)
        {
            return new VeiculoUpdateResponse
            {
                Id = veiculoWithLinha.Id,
                Name = veiculoWithLinha.Name,
                Modelo = veiculoWithLinha.Modelo,
                Linha = new Linha
                {
                    Id = veiculoWithLinha.Linha.Id,
                    Name = veiculoWithLinha.Linha.Name,
                    Paradas = veiculoWithLinha.Linha.Paradas.Select(p => new Parada
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude,
                    }).ToList()
                }
            };
        }

        private bool VeiculoExists(long id)
        {
            return _context.Veiculo.Any(e => e.Id == id);
        }
    }
}
