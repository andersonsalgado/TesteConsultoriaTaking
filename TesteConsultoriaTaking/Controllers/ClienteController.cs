using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        [Route("listarTodos")]
        public RetornoCliente Get()
        {
            return new RetornoCliente()
            {
                ListaEntidade = LimparLista<ClienteModel>( _clienteRepository.retornaListaCompleta()),
                Sucesso = true
            };
        }

        [HttpGet]
        [Route("buscarcliente/{id}")]
        public RetornoCliente Get([FromRoute] Guid id)
        {
            return new RetornoCliente()
            {
                Entidade = _clienteRepository.retornaEntityPorChave(id),
                Sucesso = true
            };
        }

        [HttpPost]
        [Route("adicionar")]
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


        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult Put(Guid id, [FromBody] EntradaCliente entradaCliente)
        {

            if (id != entradaCliente.Id)
            {
                var retorno = new RetornoCliente()
                {
                    Sucesso = false,
                    ListaErros = new List<string>() { "Não foi possível validar o código do cliente." }
                };

                return StatusCode(StatusCodes.Status406NotAcceptable, retorno);
            }

            if (!ModelState.IsValid)
            {
                var retorno = new RetornoCliente()
                {
                    Sucesso = false,
                    ListaErros = RetornarEntradaComErro(ModelState)
                };

                return StatusCode(StatusCodes.Status406NotAcceptable, retorno);
            }

            var clienteModel = entradaCliente.ToModel(id);
            var clienteAtualizado = _clienteRepository.AtualizarCliente(clienteModel);

            if (clienteAtualizado == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            var retornoCliente = new RetornoCliente()
            {
                Sucesso = true,
                Entidade = clienteAtualizado
            };

            return StatusCode(StatusCodes.Status202Accepted, retornoCliente);
        }

        
        [HttpDelete]
        [Route("remover/{id}")]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                var retorno = new RetornoCliente()
                {
                    Sucesso = false,
                    ListaErros = RetornarEntradaComErro(ModelState)
                };

                return StatusCode(StatusCodes.Status406NotAcceptable, retorno);
            }

            var clienteRemovido = _clienteRepository.excluir(x => x.Id == id);

            if (!clienteRemovido)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            var retornoCliente = new RetornoCliente()
            {
                Sucesso = true,
            };

            return StatusCode(StatusCodes.Status202Accepted , retornoCliente);
        }
    }
}
