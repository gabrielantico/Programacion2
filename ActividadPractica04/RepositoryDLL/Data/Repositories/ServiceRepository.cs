using Microsoft.EntityFrameworkCore;
using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private DbTurnosContext _context;

        public ServiceRepository(DbTurnosContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var service = await GetById(id);

            if (service == null)
            {
                return false;
            }

            _context.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<TServicio>> GetAll()
        {
            return await _context.TServicios.ToListAsync();
        }

        public async Task<TServicio>? GetById(int id)
        {
            return await _context.TServicios.FindAsync(id);
        }

        public async Task<bool> Insert(TServicio service)
        {
            if(await GetById(service.Id) != null)
            {
                return false;
            }

            _context.TServicios.Add(service);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(int id, TServicio updatingService)
        {
            var service = await GetById(id);
            bool existe;

            if(service != null)
            {
                existe = true;
                
                service.Id = id;
                if (updatingService.Nombre != "string")
                    service.Nombre = updatingService.Nombre;
                if(updatingService.Costo != 0)
                    service.Costo = updatingService.Costo;
                if(updatingService.EnPromocion != "string")
                    service.EnPromocion = updatingService.EnPromocion;
            }
            else
            {
                existe = false;
            }

            if(existe)
            {
                _context.TServicios.Update(service);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
