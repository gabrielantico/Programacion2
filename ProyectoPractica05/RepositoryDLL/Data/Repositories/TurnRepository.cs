using Microsoft.EntityFrameworkCore;
using RepositoryDLL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDLL.Data.Repositories
{
    public class TurnRepository : ITurnRepository
    {
        private TurnosDbContext _context;

        public TurnRepository(TurnosDbContext context)
        {
            _context = context;
        }
        public bool DeleteTurn(int id)
        {
            var turn = GetTurnById(id);

            if (turn == null)
            {
                return false;
            }

            turn.Estado = "Cancelado";

            _context.Update(turn);
            _context.SaveChanges();
            return true;
        }

        public List<TTurno> GetTurns(string? date, string? time)
        {
            if (string.IsNullOrEmpty(date) && string.IsNullOrEmpty(time))
            {
                return _context.TTurnos.ToList();
            }
            else if (!string.IsNullOrEmpty(date) && string.IsNullOrEmpty(time))
            {
                return _context.TTurnos.Where(x => x.Fecha.Equals(date)).ToList();
            }
            else if (string.IsNullOrEmpty(date) && !string.IsNullOrEmpty(time))
            {
                return _context.TTurnos.Where(y => y.Hora.Equals(time)).ToList();
            }
            else
            {
                return _context.TTurnos.Where(z => z.Fecha.Equals(date) && z.Hora.Equals(time)).ToList();
            }
        }

        public bool InsertTurn(TTurno turn)
        {
            if (GetTurnById(turn.Id) != null)
            {
                return false;
            }
            else
            {
                if (Validation(turn))
                {
                    _context.TTurnos.Add(turn);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdateTurn(int id, TTurno turn)
        {
            var turnUpdate = GetTurnById(id);

            if (turnUpdate == null)
            {
                return false;
            }
            
            if (turn.Fecha != null)
                turnUpdate.Fecha = turn.Fecha;
            if (turn.Hora != null)
                turnUpdate.Hora = turn.Hora;
            if (turn.Cliente != null)
                turnUpdate.Cliente = turn.Cliente;
            if (turn.Estado != null)
                turnUpdate.Estado = turn.Estado;
            _context.TTurnos.Update(turnUpdate);
            _context.SaveChanges();
            return true;
        }

        public TTurno? GetTurnById(int id)
        {
            return _context.TTurnos.Find(id);
        }

        public bool Validation(TTurno turn)
        {
            if(string.IsNullOrEmpty(turn.Fecha))
            {
                // Asignar la fecha de mañana en un formato consistente, por ejemplo, "yyyy-MM-dd"
                turn.Fecha = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

                // Asignar la hora actual en un formato consistente, por ejemplo, "HH:mm:ss"
                turn.Hora = DateTime.Now.ToString("HH:mm");
            }

            if(Convert.ToDateTime(turn.Fecha) > DateTime.Today.AddDays(45))
            {
                return false;
            }

            bool serviceCharged = false;
            foreach (var detail in turn.TDetallesTurnos)
            {
                if (detail.IdServicio > 0)
                {
                    serviceCharged = true;
                }
            }
            if (!serviceCharged)
            {
                return false;
            }

            HashSet<int> viewedValues = new HashSet<int>();
            foreach (var detail in turn.TDetallesTurnos)
            {
                if (!viewedValues.Add(detail.IdServicio))
                {
                    return false;
                }
            }

            var dateTurn = _context.TTurnos.Where(x => x.Fecha.Equals(turn.Fecha) && x.Hora.Equals(turn.Hora)).FirstOrDefault();
            if(dateTurn != null)
            {
                return false;
            }
           
            return true;
            
        }
    }
}
