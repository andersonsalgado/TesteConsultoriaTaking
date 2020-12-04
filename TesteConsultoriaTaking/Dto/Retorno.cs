using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteConsultoriaTaking.Dto
{
    public abstract class Retorno<TEntity> where TEntity : class
    {
        public bool Sucesso { get; set; }
        public TEntity Entidade { get; set; }
        public List<TEntity> ListaEntidade { get; set; }
        public List<string> ListaErros { get; set; }
    }
}
