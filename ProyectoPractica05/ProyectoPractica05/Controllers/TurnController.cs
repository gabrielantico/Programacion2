using Microsoft.AspNetCore.Mvc;
using RepositoryDLL.Business;
using RepositoryDLL.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoPractica05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnController : ControllerBase
    {
        private ITurnManager _turnManager;

        public TurnController(ITurnManager turnManager)
        {
            _turnManager = turnManager;
        }
        // GET: api/<TurnController>
        [HttpGet]
        public IActionResult Get(string? date, string? time)
        {
            try
            {
                var lst = _turnManager.GetTurns(date, time);
                if (lst.Count > 0)
                {
                    return Ok(lst);
                }
                else
                {
                    return NotFound("Lista vacía");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "¡Error interno!");
            }
            
        }

        // POST api/<TurnController>
        [HttpPost]
        public IActionResult Post([FromBody] TTurno turn)
        {
            try
            {
                var result = _turnManager.InsertTurn(turn);
                if (result)
                {
                    var turnInserted = _turnManager.GetTurnById(turn.Id);
                    return Ok(turnInserted);
                }
                else
                {
                    return BadRequest("Objeto ya existente o no validado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "¡Error interno!");
            }
        }

        // PUT api/<TurnController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TTurno turn)
        {
            try
            {
                if (_turnManager.UpdateTurn(id, turn))
                {
                    return Ok("¡Turno actualizado!");
                }
                else
                {
                    return NotFound("¡Turno no encontrado!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "¡Error interno!");
            }
        }

        // DELETE api/<TurnController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_turnManager.DeleteTurn(id))
                {
                    return Ok("¡Turno cancelado!");
                }
                else
                {
                    return NotFound("¡Turno inexistente!");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "¡Error interno!");
            }
        }
    }
}
