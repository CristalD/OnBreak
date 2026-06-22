using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace OnBreak.Negocio.RespaldoContrato
{
    [Serializable()]
    public class RespaldoControles : ISerializable
    {
        public string RutCliente { get; set; }
        public string Observaciones { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public int IdTipoEvento { get; set; }
        public String IdModalidad { get; set; }
        public System.DateTime? FechaInicio { get; set; }
        public System.DateTime? FechaTermino { get; set; }
        public System.DateTime HoraInicio { get; set; }
        public System.DateTime HoraTermino { get; set; }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("RutCliente", RutCliente);
            info.AddValue("IdModalidad", IdModalidad);
            info.AddValue("IdTipoEvento", IdTipoEvento);
            info.AddValue("Observaciones", Observaciones);
            info.AddValue("Asistentes", Asistentes);
            info.AddValue("PersonalAdicional", PersonalAdicional);
            info.AddValue("FechaInicio", FechaInicio);
            info.AddValue("FechaTermino", FechaTermino);
            info.AddValue("HoraInicio", HoraInicio);
            info.AddValue("HoraTermino", HoraTermino);
        }
        public RespaldoControles()
        {

        }
        public RespaldoControles(SerializationInfo info, StreamingContext context)
        {
            RutCliente = (string)info.GetValue("RutCliente", typeof(string));
            IdModalidad = (string)info.GetValue("IdModalidad", typeof(string));
            Observaciones = (string)info.GetValue("Observaciones", typeof(string));
            IdTipoEvento = (int)info.GetValue("IdTipoEvento", typeof(int));
            Asistentes = (int)info.GetValue("Asistentes", typeof(int));
            PersonalAdicional = (int)info.GetValue("PersonalAdicional", typeof(int));
            FechaInicio = (DateTime?)info.GetValue("FechaInicio", typeof(DateTime?));
            FechaTermino = (DateTime?)info.GetValue("FechaTermino", typeof(DateTime?));
            HoraInicio = (DateTime)info.GetValue("HoraInicio", typeof(DateTime));
            HoraTermino = (DateTime)info.GetValue("HoraTermino", typeof(DateTime));
        }
    }
}
