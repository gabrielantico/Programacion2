using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public interface ITurnRepository
    {
        List<TTurno> GetTurns(string? date, string? time);

        TTurno? GetTurnById(int id);

        bool InsertTurn(TTurno turn);

        bool UpdateTurn(int id, TTurno turn);

        bool DeleteTurn(int id);
    }
}
