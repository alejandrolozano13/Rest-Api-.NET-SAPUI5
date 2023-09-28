using Microsoft.AspNetCore.Mvc;
using projetoWebPuc;

namespace we.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientePUCController : ControllerBase
    {
        private readonly InterfaceCliente _repostorio;
        public ClientePUCController(InterfaceCliente repositorio)
        {
            _repostorio = repositorio;
        }

        [HttpGet]
        public IActionResult OberTodos()
        {

            try
            {
                var clientes = _repostorio.obterTodos();
                Console.WriteLine(clientes);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
