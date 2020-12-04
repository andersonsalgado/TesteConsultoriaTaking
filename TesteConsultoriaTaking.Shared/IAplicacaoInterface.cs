using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteConsultoriaTaking.Shared
{
    public interface IAplicacaoInterface<TEntity> where TEntity : class
    {
        bool adicionar(TEntity entidade);

        bool atualizar(TEntity entidade);

        List<TEntity> retornaListaCompleta();

        List<TEntity> retornaLista(Func<TEntity, bool> predicate);

        bool excluir(TEntity entidade);

        bool excluir(Func<TEntity, bool> predicate);

        TEntity retornaEntityPorChave(params object[] chaves);

    }
}