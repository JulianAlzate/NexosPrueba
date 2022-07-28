using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static BLL.Comunes.enums;

namespace pruebaNexos.Models
{
    public class MensajeUsuario 
    {
        protected static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public string NombreClaseCss { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public static string GetMessage(Accion Evento, TipoDeMensaje TypeMes = TipoDeMensaje.Exito, string OtherMenss = "", Exception ex = null)
        {
            MensajeUsuario msg = null;
            try
            {
                string MensajeUsr = string.IsNullOrEmpty(OtherMenss) ? MapMensajeUsuario(Evento, TypeMes) : OtherMenss;
                string Descripcion = MensajeUsr;
                Descripcion += ObtenerMensajeTecnico(ex);
                switch (TypeMes)
                {
                    case TipoDeMensaje.Error:
                        msg = new MensajeUsuario() { NombreClaseCss = "alert-danger", Titulo = "Error!", Mensaje = MensajeUsr };
                        break;
                    case TipoDeMensaje.Advertencia:
                        msg = new MensajeUsuario() { NombreClaseCss = "alert-warning", Titulo = "Advertencia!", Mensaje = MensajeUsr };
                        break;
                    case TipoDeMensaje.Informacion:
                        msg = new MensajeUsuario() { NombreClaseCss = "alert-info", Titulo = "Importante!", Mensaje = MensajeUsr };
                        break;
                    case TipoDeMensaje.Exito:
                        msg = new MensajeUsuario() { NombreClaseCss = "alert-success", Titulo = "Éxito!", Mensaje = MensajeUsr };
                        break;
                    default:
                        break;
                }
            }
            catch (Exception exgen)
            {
                Logger.Error(exgen, OtherMenss + ex.Message);
            }
            return JsonConvert.SerializeObject(msg);
        }

        protected static string ObtenerMensajeTecnico(Exception ex)
        {
            string Descripcion = string.Empty;
            if (ex != null)
            {
                Descripcion += "\n\n Mensaje técnico: \n" + ex.Message;
                Exception ExInnerException = ex.InnerException;
                while (ExInnerException != null)
                {
                    Descripcion += "\n InnerException: " + ExInnerException.Message;
                    ExInnerException = ExInnerException.InnerException;
                }
                if (ex.TargetSite != null)
                {
                    Descripcion += "\n TargetSite: " + ex.TargetSite.Name;
                }
                if (ex.StackTrace != null)
                {
                    Descripcion += "\n StackTrace: " + ex.StackTrace;
                }
            }
            return Descripcion;
        }

        protected static string MapMensajeUsuario(Accion Evento, TipoDeMensaje Acc)
        {
            string MensajeRet = string.Empty;
            if (Acc == TipoDeMensaje.Exito)
            {
                MensajeRet =
                    Evento == Accion.Adicionar ? "Registro creado"
                    : Evento == Accion.Consultar ? "Registros obtenidos"
                    : Evento == Accion.Eliminar ? "Registros eliminado"
                    : Evento == Accion.Modificar ? "Registros modificado"
                    : "Exíto";
            }
            else
            {
                MensajeRet =
                    Evento == Accion.Adicionar ? "No se logro adicionar el registro"
                    : Evento == Accion.Consultar ? "No se encontro el registro"
                    : Evento == Accion.Eliminar ? "No se logro eliminar el registro"
                    : Evento == Accion.Modificar ? "No se logro modificar el registro"
                    : Evento == Accion.Acceso ? "No logro acceder"
                    : "Error";
            }

            return MensajeRet;
        }

    }
}
