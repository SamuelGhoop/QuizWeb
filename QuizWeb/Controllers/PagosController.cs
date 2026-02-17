using Microsoft.AspNetCore.Mvc;
using QuizWeb.Interface;
using QuizWeb.Models;

namespace QuizWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagosController : ControllerBase
    {
        private readonly IPagosService _pagosService;

        public PagosController(IPagosService pagosService)
        {
            _pagosService = pagosService;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var pedido = _pagosService.GetAll();
            return Ok(pedido);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var pagos = _pagosService.GetById(id);

            if (pagos == null)
                return NotFound("No existe el pago para el id solicitado");

            return Ok(pagos);
        }

        [HttpPost]
           public IActionResult Create([FromBody] Pagos newPago)
        {
            var created = _pagosService.Create(newPago);

            return CreatedAtAction(nameof(GetById),
                new { Id = created.Id },
                created);
        }

        [HttpPatch("{id}/soft-delete")]
        public IActionResult SoftDelete(Guid id)
        {
            var result = _pagosService.SoftDelete(id);

            if (!result)
                return NotFound("No se encontró el pago a eliminar");

            return Ok($"El pago {id} fue desactivado");


        }

        [HttpPatch("{id}/pagar")]
        public IActionResult Pagar(Guid id)
        {
            try
            {
                var result = _pagosService.Pagar(id);

                if (!result)
                    return NotFound("No se encontró el pago a completar");
                
                return Ok($"El pago {id} fue completado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
