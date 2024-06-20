using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
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

            return MapearParaVeiculoCreateResponse(veiculoWithLinha);

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

        private VeiculoCreateResponse MapearParaVeiculoCreateResponse(Veiculo veiculoWithLinha)
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


        public async Task<IEnumerable<VeiculoGetAllResponse>> GetAll()
        {
            var lista = await _context.Veiculo
                .Include(l => l.Linha)
                .ThenInclude(p => p.Paradas)
                .ToListAsync();

            var responseList = lista.Select(v => new VeiculoGetAllResponse
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

            return responseList;
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

                veiculoResponse = new VeiculoUpdateResponse
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

        private bool VeiculoExists(long id)
        {
            return _context.Veiculo.Any(e => e.Id == id);
        }
    }
}
