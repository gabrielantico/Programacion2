using Microsoft.AspNetCore.Mvc;
using FacturaDLL.Business;
using FacturaDLL.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoPractica03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        Servicio oServicio = new Servicio();
        // GET: api/<FacturaController>
        [HttpGet]
        public IActionResult Get(DateTime? fecha, int? idFormaPago)
        {
            try
            {
                List<Factura> lst = oServicio.Consultar(fecha, idFormaPago);
                if(lst.Count > 0)
                {
                    return Ok(lst);
                }
                else
                {
                    return NotFound("No hay registros");
                }
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
            
        }

        // POST api/<FacturaController>
        [HttpPost]
        public IActionResult Post([FromBody] Factura factura)
        {
            try
            {
                if (factura != null)
                {
                    if (oServicio.Registrar(factura))
                    {
                        return Ok("Factura registrada");
                    }
                    else
                    {
                        return BadRequest("Error al ingresar la factura");
                    }
                }
                else
                {
                    return BadRequest("Factura con datos incorrectos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
            
            
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Factura factura)
        {
            try
            {
                if (factura != null && id > 0 && id != null)
                {
                    if (oServicio.Actualizar(id, factura))
                    {
                        return Ok("Factura actualizada");
                    }
                    else
                    {
                        return BadRequest("Error al actualizar la factura");
                    }
                }
                else
                {
                    return BadRequest("Factura o Id incorrectos");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
