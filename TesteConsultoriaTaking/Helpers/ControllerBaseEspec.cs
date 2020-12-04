using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteConsultoriaTaking.Helpers
{
    public class ControllerBaseEspec : ControllerBase
    {
        public List<T> LimparLista<T>(object objetoEntrada)
        {
            if (objetoEntrada is ICollection<T>)
            {
                var lista = (List<T>)objetoEntrada;
                if (!(lista != null && lista.Count > 0) )
                {
                    objetoEntrada = null;
                }
            }

            return (List<T>) objetoEntrada;
        }


        public List<string> RetornarEntradaComErro(ModelStateDictionary modelState)
        {
            List<string> listaErros = new List<string>();

            foreach (var item in modelState.Values)
            {
                foreach (var itemErros in item.Errors)
                {
                    listaErros.Add(itemErros.ErrorMessage);
                }
            }

            return listaErros;
        }
    }
}
