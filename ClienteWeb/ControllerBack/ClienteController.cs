using Microsoft.AspNetCore.Mvc;
using projetoWebPuc;

namespace ClienteWeb.ControllerBack
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly InterfaceCliente _repostorio;
        public ClienteController(InterfaceCliente repositorio) 
        {
            _repostorio = repositorio;
        }

        [HttpGet]
        public IActionResult OberTodos()
        {
            try
            {
                var clientes = _repostorio.obterTodos();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
