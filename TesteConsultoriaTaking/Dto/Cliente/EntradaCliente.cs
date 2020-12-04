using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TesteConsultoriaTaking.Models;

namespace TesteConsultoriaTaking.Dto.Cliente
{
    public class EntradaCliente
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        public string Nome { get; set; }

        public int Idade { get; set; }

        public ClienteModel ToModel()
        {
            var model = new ClienteModel(this.Nome, this.Idade);
            return model;
        }
    }
}
