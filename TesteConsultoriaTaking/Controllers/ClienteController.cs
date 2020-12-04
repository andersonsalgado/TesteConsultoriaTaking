using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using TesteConsultoriaTaking.Dto.Cliente;
using TesteConsultoriaTaking.Helpers;
using TesteConsultoriaTaking.Models;
using TesteConsultoriaTaking.Repository;

namespace TesteConsultoriaTaking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBaseEspec
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteController(ClienteRepository clienteRepository)
        {
            
            _clienteRepository = clienteRepository;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public RetornoCliente Get()
        {
            return new RetornoCliente()
            {
                ListaEntidade = LimparLista<ClienteModel>( _clienteRepository.retornaListaCompleta()),
                Sucesso = true
            };
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public RetornoCliente Get([FromQuery] Guid id)
        {
            return new RetornoCliente()
            {
                Entidade = _clienteRepository.retornaEntityPorChave(id),
                Sucesso = true
            };
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] EntradaCliente entradaCliente)
        {
            if (!ModelState.IsValid)
            {
                var retorno = new RetornoCliente() {
                    Sucesso = false,
                    ListaErros = RetornarEntradaComErro(ModelState)
                };
                
                return StatusCode(StatusCodes.Status406NotAcceptable, retorno);
            }

            var clienteModel = entradaCliente.ToModel();
            var clienteAdicionado = _clienteRepository.AdicionarCliente(clienteModel);

            if (clienteAdicionado == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            var retornoCliente = new RetornoCliente()
            {
                Sucesso = true,
                Entidade = clienteAdicionado
            };

            return StatusCode(StatusCodes.Status201Created, retornoCliente);

        }

        

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
