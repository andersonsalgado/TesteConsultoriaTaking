using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteConsultoriaTaking.Migrations;

namespace TesteConsultoriaTaking.Shared
{
    public abstract class RepositoryGeneric<TEntity> : IAplicacaoInterface<TEntity> where TEntity : class
    {

        private DbContext _context;

        public RepositoryGeneric(DatabaseContext _context)
        {
            this._context = _context;
        }

        public DbContext getContext()
        {
            return _context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public bool adicionar(TEntity entidade)
        {
            bool retorno = false;
            try
            {
                if (entidade != null)
                {
                    _context.Set<TEntity>().Add(entidade);
                    int retornoSave = _context.SaveChanges();
                    if (retornoSave >= 0)
                    {
                        retorno = true;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo adicionar. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }

            return retorno;
        }


        public bool atualizar(TEntity entidade)
        {
            bool retorno = false;
            try
            {
                if (entidade != null)
                {
                    _context.Set<TEntity>().Attach(entidade);
                    _context.Entry(entidade).State = EntityState.Modified;
                    int retornoSave = _context.SaveChanges();
                    if (retornoSave >= 0)
                    {
                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo atualizar. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }

            return retorno;
        }

        public List<TEntity> retornaListaCompleta()
        {
            List<TEntity> retorno = new List<TEntity>();

            try
            {
                var lista = _context.Set<TEntity>().ToList();
                if (lista != null && lista.Count() > 0)
                {
                    retorno =  (List<TEntity>)lista;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo retornaListaCompleta. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }
            return retorno;
        }



        public List<TEntity> retornaLista(Func<TEntity, bool> predicate)
        {
            List<TEntity> retorno = new List<TEntity>();

            try
            {
                var lista = _context.Set<TEntity>().Where(predicate).ToList();

                if (lista != null && lista.Count() > 0)
                {
                    retorno = (List<TEntity>)lista;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo retornaLista. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }


            return retorno;
        }


        public bool excluir(TEntity entidade)
        {
            bool retorno = false;

            try
            {
                _context.Set<TEntity>().Remove(entidade);
                _context.Entry(entidade).State = EntityState.Deleted;

                int retornoSave = _context.SaveChanges();
                if (retornoSave >= 0)
                {
                    retorno = true;
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo excluir. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }


            return retorno;
        }


        public bool excluir(Func<TEntity, bool> predicate)
        {

            bool retorno = false;

            List<TEntity> retornoQuery = new List<TEntity>();

            try
            {
                var query = _context.Set<TEntity>().Where(predicate);
                var lista = query.ToList();
                if (lista != null && lista.Count() > 0)
                {
                    var listaQuery = (List<TEntity>)lista;
                    _context.Set<TEntity>().RemoveRange(listaQuery);

                    int retornoSave = _context.SaveChanges();
                    if (retornoSave >= 0)
                    {
                        retorno = true;
                    }

                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo excluir. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }


            return retorno;
        }

        public TEntity retornaEntityPorChave(params object[] chaves)
        {
            TEntity retorno = null;

            try
            {
                var lista = _context.Set<TEntity>().Find(chaves);
                if (lista != null)
                {
                    retorno = lista;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"RepositoryGeneric - Ocorreu um erro no metodo retornaEntityPorChave. Erro: {ExceptionHelper.RecuperarDescricaoErro(ex)}");
            }
            return retorno;
        }
    }
}