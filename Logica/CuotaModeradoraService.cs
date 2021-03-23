using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
namespace Logica
{
    public class CuotaModeradoraService
    {

        private CuotaModeradoraRepository cuotaModeradoraRepository;

        public CuotaModeradoraService()
        {
            cuotaModeradoraRepository = new CuotaModeradoraRepository();
        }

        public string Guardar(LiquidacionDeCuotaModeradora liquidacion)
        {
            try
            {
                cuotaModeradoraRepository.Guardar(liquidacion);
                return "PERSONA GUARDADA";
            }
            catch (Exception e)
            {
                return "Error al momento de guardar la persona " + e.Message;
            }
        }

        public ConsultaRespuesta Consultar()
        {
            try
            {
                return new ConsultaRespuesta(cuotaModeradoraRepository.Consultar());
            }
            catch (Exception e)
            {

                return new ConsultaRespuesta("Error " + e.Message);
            }
        }

        public ConsultaRespuesta ConsultarPorAfiliacion(string afiliacion)
        {
            try
            {
                return new ConsultaRespuesta(cuotaModeradoraRepository.ConsultaPorAfiliacion(afiliacion));
            }
            catch (Exception e)
            {
                return new ConsultaRespuesta("Error " + e.Message);
            }
        }

        public string Eliminar(string cedula)
        {
            try
            {
                cuotaModeradoraRepository.Eliminar(cedula);
                return "Persona eliminada";
            }
            catch (Exception e)
            {
                return "Error al eliminar la persona, el error fue " + e.Message;
            }
        }

        public string Modificar(LiquidacionDeCuotaModeradora numeroLiquidacionNuevo, string numeroLiquidacion)
        {
            try
            {
                if (cuotaModeradoraRepository.buscarPorNumeroLiquidacion(numeroLiquidacion) != null)
                {
                    cuotaModeradoraRepository.Modificar(numeroLiquidacionNuevo, numeroLiquidacion);
                    return "Persona modificada correctamente";
                }
                return "Error, la persona no se encuentra registrada";
            }
            catch (Exception e)
            {
                return "Se presentó un error " + e.Message;
            }
        }

        public BuscarPorNumeroLiquidacionRespuesta BuscarPorNumeroLiquidacion(string numeroLiquidacion)
        {
            try
            {
                return new BuscarPorNumeroLiquidacionRespuesta(cuotaModeradoraRepository.buscarPorNumeroLiquidacion(numeroLiquidacion));
            }
            catch (Exception e)
            {
                return new BuscarPorNumeroLiquidacionRespuesta("Error, " + e.Message);
            }
        }
    }

    public class ConsultaRespuesta
    {
        public List<LiquidacionDeCuotaModeradora> Liquidaciones { get; set; }

        public string Mensaje { get; set; }

        public bool Error { get; set; }

        public ConsultaRespuesta(List<LiquidacionDeCuotaModeradora> liquidaciones)
        {
            Liquidaciones = liquidaciones;
            Error = false;
        }

        public ConsultaRespuesta(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }
    }

    public class BuscarPorNumeroLiquidacionRespuesta
    {

        public LiquidacionDeCuotaModeradora LiquidacionDeCuotaModeradora { get; set; }

        public bool Error { get; set; }

        public string Mensaje { get; set; }

        public BuscarPorNumeroLiquidacionRespuesta(string mensaje)
        {
            Mensaje = mensaje;
            Error = true;
        }

        public BuscarPorNumeroLiquidacionRespuesta(LiquidacionDeCuotaModeradora liquidacionDeCuotaModeradora)
        {
            LiquidacionDeCuotaModeradora = liquidacionDeCuotaModeradora;
            Error = false;
        }
    }
}
