using OnBreak.Negocio.RespaldoContrato;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{

    public class Contrato
    {
        string _descripcionModalidad;
        string _descripcionTipoEvento;

        public String Numero { get; set; }
        public String RutCliente { get; set; }
        public String IdModalidad { get; set; }
        public String Observaciones { get; set; }
        public int IdTipoEvento { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraTermino { get; set; }
        public String DescripcionModalidad { get { return _descripcionModalidad; } }
        public String DescripcionTipoEvento { get { return _descripcionTipoEvento; } }

        public Contrato()
        {
            this.Init();
        }

        public void Init()
        {
            Numero = String.Empty;
            RutCliente = String.Empty;
            IdModalidad = String.Empty;
            Observaciones = String.Empty;
            IdTipoEvento = 0;
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado = false;
            ValorTotalContrato = 0;
            Creacion = DateTime.Now;
            Termino = Convert.ToDateTime("01/08/1998");
            FechaHoraInicio = System.DateTime.Today;
            FechaHoraTermino = System.DateTime.Today;
            _descripcionModalidad = String.Empty;
            _descripcionTipoEvento = String.Empty;
        }

        public bool Crear()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var contr = new Onbreak.Datos.Contrato();

                CommonBC.Syncronize(this, contr);
                bbdd.Contrato.Add(contr);
                bbdd.SaveChanges();
            return true;
        }

        public bool Actualizar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var contr = new Onbreak.Datos.Contrato();

                contr = bbdd.Contrato.First(c => c.Numero == Numero);
                CommonBC.Syncronize(this, contr);
                bbdd.SaveChanges();

                return true;


        }
        public bool Eliminar()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var contr = new Onbreak.Datos.Contrato();

            contr = bbdd.Contrato.First(c => c.Numero == Numero);
            this.Termino = DateTime.Now;
            this.Realizado = true;
            CommonBC.Syncronize(this, contr);
            bbdd.SaveChanges();
            return true;
        }
        public bool Leer()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var contr = new Onbreak.Datos.Contrato();

            try
            {
                contr = bbdd.Contrato.First(c => c.Numero == Numero);
                CommonBC.Syncronize(contr, this);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool LeerPorRut()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var contr = new Onbreak.Datos.Contrato();


                contr = bbdd.Contrato.First(c => c.RutCliente == RutCliente);
                CommonBC.Syncronize(contr, this);
                return true;

        }
        public List<Contrato> LeerTodos()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Contrato> datos = bbdd.Contrato.ToList();
            List<Contrato> listaContratos = ConvertirLista(datos);
            return listaContratos;
        }
        public List<Contrato> ConvertirLista(List<Onbreak.Datos.Contrato> ListaAConvertir)
        {
            List<Contrato> ListaContratos = new List<Contrato>();
            foreach (Onbreak.Datos.Contrato datos in ListaAConvertir)
            {
                var contrato = new Contrato();
                CommonBC.Syncronize(datos, contrato);
                contrato.ObtenerDescripModalidad();
                contrato.ObtenerDescripTipo();

                ListaContratos.Add(contrato);
            }
            return ListaContratos;
        } 
        public List<Contrato> ListarPorRut()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Contrato> datos = bbdd.Contrato.Where(c => c.RutCliente == this.RutCliente).ToList();
            List<Contrato> ListaContrato = ConvertirLista(datos);
            return ListaContrato;
        }

        public List<Contrato> ListarPorNumero()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Contrato> datos = bbdd.Contrato.Where(c => c.Numero == this.Numero).ToList();
            List<Contrato> ListaContrato = ConvertirLista(datos);
            return ListaContrato;
        }

        public List<Contrato> ListarPorTipo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Contrato> datos = bbdd.Contrato.Where(c => c.IdTipoEvento == this.IdTipoEvento).ToList();
            List<Contrato> ListaContrato = ConvertirLista(datos);
            return ListaContrato;
        }
        public List<Contrato> ListarPorModalidad()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            List<Onbreak.Datos.Contrato> datos = bbdd.Contrato.Where(c => c.IdModalidad == this.IdModalidad).ToList();
            List<Contrato> ListaContrato = ConvertirLista(datos);
            return ListaContrato;
        }
        public void ObtenerDescripModalidad()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var modal = new Onbreak.Datos.ModalidadServicio();
            modal = bbdd.ModalidadServicio.First(c => c.IdModalidad == this.IdModalidad);
            _descripcionModalidad = modal.Nombre.Trim();
        }

        public void ObtenerDescripTipo()
        {
            var bbdd = new Onbreak.Datos.OnBreakEntities();
            var tipo = new Onbreak.Datos.TipoEvento();
            tipo = bbdd.TipoEvento.First(c => c.IdTipoEvento == this.IdTipoEvento);
            _descripcionTipoEvento = tipo.Descripcion.Trim();
        }

    }
}
