using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [MaxLength(180)]
        public string Nome { get; set; }

        [Column(name: "idade")]
        [Range(0, 120, ErrorMessage = "Informe uma idade entre 0 e 120 anos.")]
        public int Idade { get; set; }

        public ClienteModel()
        {
        }

        public ClienteModel(string nome, int idade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Idade = idade;
        }

        public ClienteModel(Guid id, string nome, int idade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
        }
    }
}
