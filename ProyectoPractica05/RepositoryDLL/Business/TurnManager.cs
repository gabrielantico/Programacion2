using RepositoryDLL.Data.Models;
using RepositoryDLL.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Business
{
    public class TurnManager : ITurnManager
    {
        private IServicesRepository _serviceRepository;

        private ITurnRepository _turnRepository;

        public TurnManager(IServicesRepository serviceRepository, ITurnRepository turnRepository)
        {
            _serviceRepository = serviceRepository;
            _turnRepository = turnRepository;
        }

        //Acciones de turnos
        public List<TTurno> GetTurns(string? date, string? time)
        {
            return _turnRepository.GetTurns(date, time);
        }

        public TTurno? GetTurnById(int id)
        {
            return _turnRepository.GetTurnById(id);
        }
        public bool InsertTurn(TTurno turn)
        {
            return _turnRepository.InsertTurn(turn);
        }
        public bool UpdateTurn(int id, TTurno turn)
        {
            return _turnRepository.UpdateTurn(id, turn);
        }
        public bool DeleteTurn(int id)
        {
            return _turnRepository.DeleteTurn(id);
        }

        //Acciones de servicios
        public List<TServicio> GetServices()
        {
            return _serviceRepository.GetServices();
        }
        public bool InsertService(TServicio service)
        {
            return _serviceRepository.InsertService(service);
        }
        public bool UpdateService(int id, TServicio service)
        {
            return _serviceRepository.UpdateService(id, service);
        }
        public bool DeleteService(int id)
        {
            return _serviceRepository.DeleteService(id);
        }
    }
}
