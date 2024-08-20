using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.Domain;

namespace purrfect_olho_vivo_api.Services

{
    public class LinhaService : ILinhaService
    {
        private readonly AppDbContext _context;

        public LinhaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Linha> Create(LinhaCreateRequest request)
        {
            var linha = new Linha
            {
                Name = request.Name,
                Paradas = new List<Parada>()
            };

            foreach (var paradaRequest in request.Paradas)
            {
                var existingParada = await _context.Parada
                    .FirstOrDefaultAsync(p => p.Id == paradaRequest);

                if (existingParada != null)
                {
                    linha.Paradas.Add(existingParada);
                }
                else
                {
                    throw new KeyNotFoundException($"A parada '{paradaRequest}' não foi encontrada no sistema.");
                }
            }

            _context.Linha.Add(linha);

            await _context.SaveChangesAsync();

            return linha;
        }

        public async Task<bool> Delete(long id)
        {
            var linha = await _context.Linha.FindAsync(id);

            if (linha == null)
            {
                return false;
            }

            _context.Linha.Remove(linha);

            await _context.SaveChangesAsync();

            return true;
        } 
        public async  Task<PagedList<LinhaGetAllResponse>> GetAll(LinhaGetRequest request)
        {
            var query = _context.Linha.AsQueryable();

            if (request?.Id.HasValue == true)
            {
                query = query.Where(p => p.Id == request.Id.Value);
            }

            if (!string.IsNullOrEmpty(request?.Name))
            {
                query = query.Where(p => p.Name.Contains(request.Name));
            }

            if (request?.IdParada.HasValue == true)
            { 
                query = query.Where(l => l.Paradas.Any(p => p.Id == request.IdParada.Value));
            }

            // Total de itens antes da paginação
            var totalItems = await query.CountAsync();

            // Aplicar paginação
            var linhas = await query
                            .Include(l => l.Paradas)
                            .AsNoTracking()
                            .Skip((request.pageNumber - 1) * request.pageSize)
                            .Take(request.pageSize)
                            .ToListAsync();

          


            if (linhas.Any())
            {
                // Mapeando os dados de Linha para LinhaResponse
                var linhaResponses = linhas.Select(l => new LinhaResponse
                {
                    Id = l.Id,
                    Name = l.Name,
                    Paradas = l.Paradas.Select(p => new ParadaResponse
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Latitude = p.Latitude,
                        Longitude = p.Longitude
                    }).ToList()
                }).ToList();

                // Criando uma instância de LinhaGetAllResponse que encapsula a lista de LinhaResponse
                var linhaGetAllResponse = new LinhaGetAllResponse
                {
                    Linhas = linhaResponses
                };

                // Criando uma lista contendo o objeto LinhaGetAllResponse
                var responseList = new List<LinhaGetAllResponse> { linhaGetAllResponse };

                // Criando a PagedList de LinhaGetAllResponse
                var pagedResult = new PagedList<LinhaGetAllResponse>(
                    responseList,
                    request.pageNumber,
                    request.pageSize,
                    totalItems
                );

                return pagedResult;
            }
            else
            {
                throw new KeyNotFoundException();
            }
           
        }

        public async Task<Linha> GetLinhaById(int id)
        {
            var linha = await _context.Linha
                .Include(l => l.Paradas)
                .SingleOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                throw new KeyNotFoundException("Linha não encontrada.");
            }

            return linha;
        }

        public async Task<IEnumerable<Linha>> GetLinhaPorParada(int idParada)
        {
            return await _context.Linha
                .Include(l => l.Paradas)
                .Where(l => l.Paradas.Any(p => p.Id == idParada))
                .ToListAsync();
        }

        public async Task<Linha> Update(int id, LinhaUpdateRequest request)
        {
            if (id != request.Id)
            {
                throw new ArgumentException("ID mismatch.");
            }

            var linha = await _context.Linha.Include(l => l.Paradas).FirstOrDefaultAsync(l => l.Id == id);

            if (linha == null)
            {
                throw new KeyNotFoundException("Linha não encontrada.");
            }

            linha.Name = request.Name;

            var paradas = await _context.Parada.Where(p => request.Paradas.Contains(p.Id)).ToListAsync();

            linha.Paradas.Clear();
            foreach (var parada in paradas)
            {
                linha.Paradas.Add(parada);
            }

            _context.Linha.Update(linha);
            await _context.SaveChangesAsync();

            return linha;
        }
    }
}
