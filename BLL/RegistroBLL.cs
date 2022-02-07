using System;
using Registro.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Registro.BLL
{
    public class CarreraBLL
    {

        public static bool Existe(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Carrera.Any(l => l.CarreraId == CarreraId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Carrera carrera)
        {
            if (!Existe(carrera.CarreraId))
                return Insertar(carrera);
            else
                return Modificar(carrera);

        }

        private static bool Insertar(Carrera carrera)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Carrera.Add(carrera);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Carrera carrera)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(carrera).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var carrera = contexto.Carrera.Find(CarreraId);
                if (carrera != null)
                {
                    contexto.Carrera.Remove(carrera);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Carrera? Buscar(int CarreraId)
        {
            Contexto contexto = new Contexto();
            Carrera? carrera;
            try
            {
                carrera = contexto.Carrera.Find(CarreraId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return carrera;
        }

        public static List<Carrera> GetList(){
            using(var contexto = new Contexto()){
                return contexto.Carrera.ToList();
            }
        }

        public static List<Carrera> ListaCombobox(Expression<Func<Carrera, bool >> nombreCarrera)
    {
        using (var context = new Contexto())
        {
            try
            {
                return context.Carrera.Where(nombreCarrera).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    }

}