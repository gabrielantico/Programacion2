using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public interface IServiceRepository
    {
        Task<List<TServicio>> GetAll();

        Task<TServicio> GetById(int id);

        Task<bool> Insert(TServicio service);

        Task<bool> Update(int id, TServicio updatingService);

        Task<bool> Delete(int id);
    }
}
