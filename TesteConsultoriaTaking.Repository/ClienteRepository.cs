using System;
using TesteConsultoriaTaking.Migrations;
using TesteConsultoriaTaking.Models;
using TesteConsultoriaTaking.Shared;

namespace TesteConsultoriaTaking.Repository
{
    public class ClienteRepository : RepositoryGeneric<ClienteModel>
    {
        private readonly DatabaseContext contexto;

        public ClienteRepository(DatabaseContext _context) : base(_context)
        {
            contexto = _context;
        }

        public ClienteModel AdicionarCliente(ClienteModel clienteModel)
        {
            try
            {
                contexto.Add<ClienteModel>(clienteModel);
                var save = contexto.SaveChanges();

                if (save > 0)
                {
                    return clienteModel;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ClienteRepository - Ocorreu um erro no metodo AdicionarCliente. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }

            

            return null;
        }

        public ClienteModel AtualizarCliente(ClienteModel clienteModel)
        {
            try
            {
                var retorno = this.atualizar(clienteModel);

                if (retorno)
                {
                    return clienteModel;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ClienteRepository - Ocorreu um erro no metodo AdicionarCliente. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }



            return null;
        }

    }
}
