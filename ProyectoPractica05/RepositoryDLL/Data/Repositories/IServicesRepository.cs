using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public interface IServicesRepository
    {
        List<TServicio> GetServices();

        bool InsertService(TServicio service);

        bool UpdateService(int id, TServicio service);

        bool DeleteService(int id);
    }
}
