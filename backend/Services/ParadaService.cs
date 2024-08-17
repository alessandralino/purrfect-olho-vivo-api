using Microsoft.AspNetCore.Mvc;
using purrfect_olho_vivo_api.Context;
using purrfect_olho_vivo_api.Interfaces;
using purrfect_olho_vivo_api.ViewModels.Models;
using purrfect_olho_vivo_api.ViewModels.Requests;
using purrfect_olho_vivo_api.ViewModels.Responses; 
using Microsoft.EntityFrameworkCore;
using Azure.Core;
using System.Composition;

namespace purrfect_olho_vivo_api.Services
{
    public class ParadaService : IParadaService
    {
        private readonly AppDbContext _context;

        public ParadaService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Parada> Create(ParadaCreateRequest request)
        {
            var parada = new Parada
            {
                Name = request.Name,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
            };

            _context.Parada.Add(parada);

            _context.SaveChanges();

            return parada;
        }

        public async Task<bool> Delete(long id)
        {
            var parada = await _context.Parada.FindAsync(id);

            if (parada == null)
            {
                return false;
            }

            _context.Parada.Remove(parada);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Parada>> GetAll(ParadaGetRequest? request)
        {
            var query = _context.Parada.AsQueryable();

            if (request?.Id.HasValue == true)
            {
                query = query.Where(p => p.Id == request.Id.Value);
            }

            if (!string.IsNullOrEmpty(request?.Name))
            {
                query = query.Where(p => p.Name.Contains(request.Name));
            }

            if (request?.Latitude.HasValue == true)
            {
                query = query.Where(p => p.Latitude == request.Latitude.Value);
            }

            if (request?.Longitude.HasValue == true)
            {
                query = query.Where(p => p.Longitude == request.Longitude.Value);
            }

            var paradas = await query.ToListAsync();

            if (paradas == null || !paradas.Any())
            {
                throw new KeyNotFoundException("Nenhuma parada encontrada.");
            }

            return paradas;
        }


        public async Task<ActionResult<Parada>> GetParadaById(long id)
        {
            var parada = await _context.Parada.FindAsync(id);

            if (parada == null)
            {
                throw new KeyNotFoundException("Parada não encontrada.");
            }

            return parada;
        }

        public async Task<IEnumerable<Parada>> GetParadaByPosicao(ParadaGetByPosicaoRequest request)
        {
            var paradas = await _context.Parada
                .Where((p => p.Latitude == request.latitude && p.Longitude == request.longitude))
                .ToListAsync();

            if (paradas == null || !paradas.Any())
            {
                throw new KeyNotFoundException("Nenhuma parada encontrada.");
            }

            return paradas;
        }

        public async Task<ParadaUpdateResponse> Update(int id, Parada parada)
        {
            if (id != parada.Id)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(parada).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var paradaAtualizada = await _context.Parada.FirstOrDefaultAsync(v => v.Id == parada.Id);

            if (paradaAtualizada == null)
            {
                throw new KeyNotFoundException("Parada not found");
            }

            return new ParadaUpdateResponse()
            {
                Id = paradaAtualizada.Id,
                Latitude = paradaAtualizada.Latitude,
                Longitude = paradaAtualizada.Longitude,
                Name = paradaAtualizada.Name
            };
        }

        public bool ParadaExists(int id)
        {
            return _context.Parada.Any(e => e.Id == id);
        }
    }
}
