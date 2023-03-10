using Infraestructure.Models;
using Infraestructure.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class RepositoryLibro : IRepositoryLibro
    {
        public void DeleteLibro(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Libro> GetLibro()
        {
            IEnumerable<Libro> lista = null;
            try
            {


                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener todos los libros incluyendo el autor
                    lista = ctx.Libro.Include("Autor").ToList();

                    //lista = ctx.Libro.Include(x => x.Autor).ToList();

                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Libro> GetLibroByAutor(int idAutor)
        {
            IEnumerable<Libro> oLibro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libros por Autor
                    //oLibro = ctx.Libro.
                    //    Include("Autor").
                    //    Where(x => x.Equals(idAutor)).ToList();

                    oLibro = ctx.Libro.
                           Where(l => l.IdLibro == idAutor).Include("Autor").ToList();

                }
                return oLibro;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Libro> GetLibroByCategoria(int idCategoria)
        {
            IEnumerable<Libro> lista = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener los libros que pertenecen a una categoría
                    lista = ctx.Libro.Include(c => c.Categoria).
                        Where(c => c.Categoria.Any(o => o.IdCategoria == idCategoria))
                        .ToList();
                }
                return lista;
            }

            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Libro GetLibroByID(int id)
        {
            Libro oLibro = null;
            try
            {
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener libro por ID ibluyendo el autor y todas sus categorías
                    oLibro = ctx.Libro.Where(x => x.IdLibro == id)
                        .Include("Autor")
                        .Include("Categoria")
                        .FirstOrDefault();

                }
                return oLibro;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public IEnumerable<Libro> GetLibroByNombre(string nombre)
        {
            try
            {
                IEnumerable<Libro> oLibro = null;
                using (MyContext ctx = new MyContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;
                    //Obtener Libros por nombre
                    oLibro = ctx.Libro.ToList().FindAll(x => x.Nombre.ToLower().Contains(nombre.ToLower()));
                }
                return oLibro;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public Libro Save(Libro libro, string[] selectedCategorias)
        {
            throw new NotImplementedException();
        }
    }
}
