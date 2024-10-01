using Microsoft.AspNetCore.Mvc;
using RepositoryDLL.Data.Models;
using RepositoryDLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ActividadPractica04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly IService service;

        public ServiciosController(IService s)
        {
            service = s;
        }
        // GET: api/<ServiciosController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var lst = await service.GetAllServices();
                if (lst.Count > 0)
                    return Ok(lst);
                else
                    return NotFound("Lista vacía");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var s = await service.GetServiceById(id);

                if (s != null)
                    return Ok(s);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error intenrno");
            }
            
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TServicio insertingService)
        {
            try
            {
                if (await service.InsertService(insertingService))
                    return Ok("Objeto insertado");
                else
                    return BadRequest("No se pudo insertar el objeto");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TServicio updatingService)
        {
            try
            {
                var s = await service.GetServiceById(id);
                bool updated = false;

                if(s != null)
                {
                    updated = await service.UpdateService(id, updatingService);
                    
                }
                else
                {
                    return NotFound("El objeto que desea actualizar no existe");
                }
                
                if (updated)
                    return Ok("Objeto actualizado");
                else
                    return BadRequest("El objeto no se pudo actualizar");
                    
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var s = await service.GetServiceById(id);
                bool deleted = false;

                if (s != null)
                {
                    deleted = await service.DeleteService(id);
                }
                else
                {
                    return NotFound("El objeto que desea elminar no existe");
                }

                if (deleted)
                    return Ok("Objeto eliminado");
                else
                    return BadRequest("El objeto no se pudo eliminar");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
            

        }
    }
}
