using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TesteConsultoriaTaking.Models
{
    [Table("Cliente")]
    public class ClienteModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(name: "id")]
        public Guid Id { get; set; }
        
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório")]
        [Column(name: "nome")]
        public string Nome { get; set; }

        [Column(name: "idade")]
        public int Idade { get; set; }

        public ClienteModel() { }

        public ClienteModel(string nome, int idade)
        {
            this.Id = Guid.NewGuid();
            this.Nome = nome;
            this.Idade = idade;
        }

        public ClienteModel(Guid id, string nome, int idade)
        {
            this.Id = id;
            this.Nome = nome;
            this.Idade = idade;
        }

    }
}
