using Microsoft.EntityFrameworkCore;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses;

namespace purrfect_olho_vivo_api.Services
{
    public class LinhaService : ILinhaService
    {
        private readonly AppDbContext _context;

        public LinhaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Linha> CreateLinha(LinhaCreateRequest request)
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

        public async Task<bool> DeleteLinha(long id)
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

        public async Task<LinhaGetAllResponse> GetAll()
        {
            var linhas = await _context.Linha.Include(l => l.Paradas).ToListAsync();

            var options = linhas.Select(l => new LinhaResponse
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

            LinhaGetAllResponse resultado = new LinhaGetAllResponse
            {
                Linhas = options
            };

            return resultado;
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

        public async Task<Linha> UpdateLinha(int id, LinhaUpdateRequest request)
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
