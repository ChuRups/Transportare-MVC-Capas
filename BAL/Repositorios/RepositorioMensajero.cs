using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Interfaces;
using BAL.Modelos;
using DAL;

namespace BAL.Repositorios
{
    public class RepositorioMensajero : IRepositorioMensajeros
    {
        public void AgregarMensajero(ModeloMensajeros model)
        {
            using (var db = new TransportareContext())
            {
                db.Mensajero.Add(MapearMensajeroABaseDatos(model));
                db.SaveChanges();
            }
        }

        public void EditarMensajero(ModeloMensajeros model)
        {
            using (var db = new TransportareContext())
            {
                var editar = db.Mensajero.Find(model.IdMensajero);
                editar.Nombres = model.Nombres;
                editar.Apellidos = model.Apellidos;
                editar.Documento = model.Documento;
                editar.Direccion = model.Direccion;
                editar.FechaIngreso = model.FechaIngreso;
                editar.Estado = model.Estado;
                editar.IdSexo = model.IdSexo;
                editar.IdUbigeo = model.IdUbigeo;
                db.SaveChanges();
            }
        }

        public void EliminarMensajero(int id)
        {
            using (var db = new TransportareContext())
            {
                var eliminar = db.Mensajero.Find(id);
                db.Mensajero.Remove(eliminar);
                db.SaveChanges();
            }
        }


        public ModeloMensajeros ListarMensajeroId(int id)
        {
            using (var db = new TransportareContext())
            {
                return MapearAplicacion(db.Mensajero.Find(id));
            }
        }

        public List<ModeloMensajeros> ListarMensajeros()
        {
            using (var db = new TransportareContext())
            {
                return db.Mensajero.Select(MapearAplicacion).ToList();
            }
        }

        private Mensajero MapearMensajeroABaseDatos(ModeloMensajeros modelo)
        {
            return new Mensajero()
            {
                IdMensajero = modelo.IdMensajero,
                Nombres = modelo.Nombres,
                Apellidos = modelo.Apellidos,
                Documento = modelo.Documento,
                Direccion = modelo.Direccion,
                FechaIngreso = modelo.FechaIngreso,
                Estado = modelo.Estado,
                IdSexo = modelo.IdSexo,
                IdUbigeo = modelo.IdUbigeo                
            };
        }

        private ModeloMensajeros MapearAplicacion(Mensajero tabla)
        {
            return new ModeloMensajeros()
            {
                IdMensajero = tabla.IdMensajero,
                Nombres = tabla.Nombres,
                Apellidos = tabla.Apellidos,
                Documento = tabla.Documento,
                Direccion = tabla.Direccion,
                FechaIngreso = tabla.FechaIngreso,
                Estado = tabla.Estado,
                IdSexo = tabla.IdSexo,
                IdUbigeo = tabla.IdUbigeo
            };
        }


    }
}
