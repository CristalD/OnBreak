using System;
using System.Collections.Generic;
using System.Linq;
using Onbreak.Datos;
namespace OnBreak.Negocio
{
    public class Cliente
    {
        string _DescripcionActividad;
        string _DescripcionTipo;

        public String RutCliente { get; set; }
        public String RazonSocial { get; set; }
        public String NombreContacto { get; set; }
        public String MailContacto { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }
        public String DescripcionActividad { get { return _DescripcionActividad; } }
        public String DescripcionTipo { get { return _DescripcionTipo; } }


        public Cliente()
        {
            this.Init();
        }

        public void Init()
        {
            RutCliente = String.Empty;
            RazonSocial = String.Empty;
            NombreContacto = String.Empty;
            MailContacto = String.Empty;
            Direccion = String.Empty;
            Telefono = String.Empty;
            IdActividadEmpresa = 0;
            IdTipoEmpresa = 0;
            _DescripcionActividad = String.Empty;
            _DescripcionTipo = String.Empty;
        }

        // Metodo Crear un Cliente
        public bool Crear()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var cliente = new Onbreak.Datos.Cliente();


                CommonBC.Syncronize(this, cliente);
                bbdd.Cliente.Add(cliente);
                bbdd.SaveChanges();

                return true;

        }


        //mostrar datos del cliente por su rut
        public bool Mostrar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var cliente = new Onbreak.Datos.Cliente();

            try
            {
                cliente = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                CommonBC.Syncronize(cliente, this);
                ObtenerDescripcionAct();
                ObtenerDescripcionTipo();
                return true;

            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool Actualizar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var cliente = new Onbreak.Datos.Cliente();

            try
            {
                cliente = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                CommonBC.Syncronize(this, cliente);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool Eliminar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var cliente = new Onbreak.Datos.Cliente();


            try
            {
                cliente = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                bbdd.Cliente.Remove(cliente);
                bbdd.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<Cliente> Buscar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Cliente> datos = bbdd.Cliente.Where(c => c.RutCliente == this.RutCliente).ToList<Onbreak.Datos.Cliente>();
            List<Cliente> listaNegocio = GenerarLista(datos);
            return listaNegocio;


        }

        public List<Cliente> LeerTodos()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Cliente> datos = bbdd.Cliente.ToList<Onbreak.Datos.Cliente>();
            List<Cliente> ListaNegocio = GenerarLista(datos);
            return ListaNegocio;

        }

        private List<Cliente> GenerarLista(List<Onbreak.Datos.Cliente> listaAConvertir)
        {
            List<Cliente> listaNegocio = new List<Cliente>();
            foreach (Onbreak.Datos.Cliente datos in listaAConvertir)
            {
                Cliente negocio = new Cliente();
                CommonBC.Syncronize(datos, negocio);
                negocio.ObtenerDescripcionAct();
                negocio.ObtenerDescripcionTipo();
                listaNegocio.Add(negocio);
            }

            return listaNegocio;
        }

        public List<Cliente> FiltrarPorTipo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            try
            {
                List<Onbreak.Datos.Cliente> datos = bbdd.Cliente.Where(c => c.IdTipoEmpresa == this.IdTipoEmpresa).ToList<Onbreak.Datos.Cliente>();
                List<Cliente> listaNegocio = GenerarLista(datos);
                return listaNegocio;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message, ex);
                return new List<Cliente>();
            }
        }

        public List<Cliente> FiltrarPorActividad()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            try
            {
                List<Onbreak.Datos.Cliente> datos = bbdd.Cliente.Where(c => c.IdActividadEmpresa == this.IdActividadEmpresa).ToList<Onbreak.Datos.Cliente>();
                List<Cliente> listaNegocio = GenerarLista(datos);
                return listaNegocio;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message, ex);
                Console.ReadLine();
                return new List<Cliente>();
            }
        }

        private void ObtenerDescripcionAct()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var actividad = new Onbreak.Datos.ActividadEmpresa();
            actividad = bbdd.ActividadEmpresa.First(a => a.IdActividadEmpresa == IdActividadEmpresa);
            _DescripcionActividad = actividad.Descripcion;
        }
        
        private void ObtenerDescripcionTipo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var tipo = new Onbreak.Datos.TipoEmpresa();
            tipo = bbdd.TipoEmpresa.First(t => t.IdTipoEmpresa == IdTipoEmpresa);
            _DescripcionTipo = tipo.Descripcion;
        }
    }

}
