using Microsoft.AspNetCore.Mvc;
using LibreriaDLL.Business;

using LibreriaDLL.Domain;
using System.Security.Cryptography;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoPractica02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private Servicio oServicio = new Servicio();

        // GET: api/<ArticuloController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Articulo> lst = oServicio.GetAll();

                if(lst.Count > 0) 
                {
                    return Ok(lst);
                }
                else
                {
                    return NotFound("Lista de artículos vacía");
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
            
        }

        // GET api/<ArticuloController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Articulo a = oServicio.GetById(id);

                if(a.Codigo != 0)
                {
                    return Ok(a.ToString());
                }
                else
                {
                    return NotFound("Objeto no encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // POST api/<ArticuloController>
        [HttpPost]
        public IActionResult Post([FromBody] Articulo a)
        {
            try
            {
                List<Articulo> lst = oServicio.GetAll();

                foreach(Articulo a2 in lst)
                {
                    if (a2.Codigo.Equals(a.Codigo))
                    {
                        return BadRequest("El objeto que desea ingresar tiene un código que ya existe");
                    }
                }

                bool resultado = oServicio.Insert(a);

                if (resultado)
                {
                    return Ok("Objeto ingresado correctamente");
                }
                else
                {
                    return BadRequest("Error al ingresar el objeto");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
            

        }

        // PUT api/<ArticuloController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Articulo a)
        {
            try
            {
                bool existe = false;

                List<Articulo> lst = oServicio.GetAll();
                foreach (Articulo a2 in lst)
                {
                    if (a2.Codigo.Equals(id))
                    {
                        existe = true;
                    }
                }

                if (existe)
                {
                    bool actualizado = oServicio.Update(a, id);
                    return Ok("Objeto actualizado");
                }
                else
                {
                    return NotFound("Objeto no encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }

        // DELETE api/<ArticuloController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                bool existe = false;
                List<Articulo> lst = oServicio.GetAll();
                foreach (Articulo a2 in lst)
                {
                    if (a2.Codigo.Equals(id))
                    {
                        existe = true;
                    }
                }

                if (existe)
                {
                    bool resultado = oServicio.Delete(id);
                    return Ok("Objeto eliminado");
                }
                else
                {
                    return NotFound("Objeto no encontrado");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
