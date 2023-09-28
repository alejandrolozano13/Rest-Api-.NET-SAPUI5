using Microsoft.AspNetCore.Mvc;
using ConsoleApp1;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace we
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
                Console.WriteLine(clientes);
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Cliente cliente)
        {
            if (cliente == null) { return BadRequest(); }
            try
            {
                var novoCliente = cliente;
                _repostorio.adicionarCliente(novoCliente);

                return Ok(novoCliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{cpf}")]
        public IActionResult Remover(int cpf)
        {
            try
            {
                _repostorio.removerCliente(cpf);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{CPF}")]
        public IActionResult Atualizar([FromBody, Required()] Cliente cliente, int CPF)
        {
            try
            {
                cliente.Cpf = CPF;
                _repostorio.atualizarCliente(cliente);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{CPF}")]
        public IActionResult ObterPorId(int CPF)
        {
            try
            {
                var cliente = _repostorio.obterPorCpf(CPF);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
