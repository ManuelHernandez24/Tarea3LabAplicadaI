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

        public static List<Carrera> GetListaCarrera(Expression<Func<Carrera, bool>> criterio)
        {
            using (var contexto = new Contexto())
            {
                return contexto.Carrera.Where(criterio).ToList();
            }
        }
    }

    public class EstudianteBLL
    {

        public static bool Existe(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Estudiante.Any(l => l.EstudianteId == EstudianteId);
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

        public static bool Guardar(Estudiante estudiante)
        {
            if (!Existe(estudiante.EstudianteId))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

        private static bool Insertar(Estudiante estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Estudiante.Add(estudiante);
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

        private static bool Modificar(Estudiante estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
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

        public static bool Eliminar(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var estudiante = contexto.Carrera.Find(EstudianteId);
                if (estudiante != null)
                {
                    contexto.Carrera.Remove(estudiante);
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

        public static Estudiante? Buscar(int EstudianteId)
        {
            Contexto contexto = new Contexto();
            Estudiante? estudiante;
            try
            {
                estudiante = contexto.Estudiante.Find(EstudianteId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiante;
        }

        public static List<Estudiante> GetList(){
            using(var contexto = new Contexto()){
                return contexto.Estudiante.ToList();
            }
        }
    }
}
