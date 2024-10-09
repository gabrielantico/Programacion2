using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Business
{
    public interface ITurnManager
    {
        //Turnos
        List<TTurno> GetTurns(string? date, string? time);

        TTurno? GetTurnById(int id);
        bool InsertTurn(TTurno turn);

        bool UpdateTurn(int id, TTurno turn);

        bool DeleteTurn(int id);

        //Servicios
        List<TServicio> GetServices();

        bool InsertService(TServicio service);

        bool UpdateService(int id, TServicio service);

        bool DeleteService(int id);
    }
}
