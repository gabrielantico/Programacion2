using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Services
{
    public interface IService
    {
        Task<bool> InsertService(TServicio service);

        Task<bool> UpdateService(int id, TServicio updatingService);

        Task<bool> DeleteService(int id);

        Task<List<TServicio>> GetAllServices();

        Task<TServicio> GetServiceById(int id);
    }
}
