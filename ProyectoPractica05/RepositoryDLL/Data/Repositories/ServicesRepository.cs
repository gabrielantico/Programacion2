using Microsoft.EntityFrameworkCore;
using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public class ServicesRepository : IServicesRepository
    {
        private TurnosDbContext _context;

        public ServicesRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public bool DeleteService(int id)
        {
            var service = GetById(id);

            if (service == null)
            {
                return false;
            }

            _context.Remove(service);
            _context.SaveChanges();
            return true;
        }

        public List<TServicio> GetServices()
        {
            return _context.TServicios.ToList();
        }

        public bool InsertService(TServicio service)
        {
            if (GetById(service.Id) != null)
            {
                return false;
            }

            _context.TServicios.Add(service);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateService(int id, TServicio updatingService)
        {
            var service = GetById(id);
            bool exists;

            if (service != null)
            {
                exists = true;

                service.Id = id;
                if (updatingService.Nombre != null)
                    service.Nombre = updatingService.Nombre;
                if (updatingService.Costo != 0)
                    service.Costo = updatingService.Costo;
                if (updatingService.EnPromocion != null)
                    service.EnPromocion = updatingService.EnPromocion;
            }
            else
            {
                exists = false;
            }

            if (exists)
            {
                _context.TServicios.Update(service);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public TServicio? GetById(int id)
        {
            return _context.TServicios.Find(id);
        }
    }
}
