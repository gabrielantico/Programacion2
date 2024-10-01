using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Services
{
    public class Service : IService
    {
        private IServiceRepository _repository;

        public Service(IServiceRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> DeleteService(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<List<TServicio>> GetAllServices()
        {
            return await _repository.GetAll();
        }

        public async Task<TServicio> GetServiceById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> InsertService(TServicio service)
        {
            return await _repository.Insert(service);
        }

        public Task<bool> UpdateService(int id, TServicio updatingService)
        {
            return _repository.Update(id, updatingService);
        }
    }
}
