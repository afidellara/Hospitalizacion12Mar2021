
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Entidad;

namespace Datos
{
    public class CuotaModeradoraRepository
    {

        string ubicacion = "liquidacion.txt";
        public void Guardar(LiquidacionDeCuotaModeradora liquidacion)
        {
            FileStream file = new FileStream(ubicacion, FileMode.Append);
            StreamWriter escritor = new StreamWriter(file);
            escritor.WriteLine($"{liquidacion.NumeroLiquidacion};{liquidacion.Cedula};{liquidacion.Nombre};" +
                $"{liquidacion.Salario};{liquidacion.Servicio};{liquidacion.ValorServicio};{liquidacion.Tarifa};" +
                $"{liquidacion.Afiliacion};{liquidacion.TotalCuotaModeradora}");
            escritor.Close();
            file.Close();
        }



        public List<LiquidacionDeCuotaModeradora> Consultar()
        {
            List<LiquidacionDeCuotaModeradora> liquidaciones = new List<LiquidacionDeCuotaModeradora>();
            FileStream file = new FileStream(ubicacion, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;

            while ((linea = reader.ReadLine()) != null)
            {
                LiquidacionDeCuotaModeradora liquidacion = MapearLiquidacion(linea);
                liquidaciones.Add(liquidacion);
            }
            reader.Close();
            file.Close();
            return liquidaciones;

        }
        private LiquidacionDeCuotaModeradora MapearLiquidacion(string linea)
        {
            LiquidacionDeCuotaModeradora liquidacion;
            
             string[] posicion = linea.Split(';');

            if (posicion[7].Equals("CON"))
            {
                liquidacion = new Contributivo();
            }
            else
            {
                liquidacion = new Subsidiado(); 
            }

            liquidacion.NumeroLiquidacion = posicion[0]; 
            liquidacion.Cedula = posicion[1];
            liquidacion.Nombre = posicion[2];
            liquidacion.Salario = double.Parse(posicion[3]); 
            liquidacion.Servicio = posicion[4];
            liquidacion.ValorServicio = double.Parse(posicion[5]);
            liquidacion.Tarifa = Int32.Parse(posicion[6]); 
            liquidacion.Afiliacion = posicion[7];
            liquidacion.TotalCuotaModeradora = double.Parse(posicion[8]); 
            return liquidacion;
        }

        public List<LiquidacionDeCuotaModeradora> ConsultarPorAfiliacion(string afiliacion)
        {
            List<LiquidacionDeCuotaModeradora> liquidaciones = new List<LiquidacionDeCuotaModeradora>();
            FileStream file = new FileStream(ubicacion, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;  

            while ((linea = reader.ReadLine()) != null)
            {
                if (afiliacion.Equals("CON"))
                {
                    LiquidacionDeCuotaModeradora liquidacion = MapearLiquidacion(linea);
                    liquidaciones.Add(liquidacion);
                }
                else 
                {
                    LiquidacionDeCuotaModeradora liquidacion = MapearLiquidacion(linea);
                    liquidaciones.Add(liquidacion);
                }
            }
            reader.Close();
            file.Close();
            return liquidaciones;

        }

        public void Eliminar(string cedula)
        {
            List<LiquidacionDeCuotaModeradora> liquidaciones = Consultar();
            FileStream file = new FileStream(ubicacion, FileMode.Create);
            file.Close();
            foreach (var p in liquidaciones)
            {
                if (!p.Cedula.Equals(cedula))
                {
                    Guardar(p);
                }
            }

        }

        public void Modificar(LiquidacionDeCuotaModeradora LiquidacionNueva, string numeroLiquidacion)
        {
            List<LiquidacionDeCuotaModeradora> liquidaciones = Consultar();
            FileStream file = new FileStream(ubicacion, FileMode.Create);
            file.Close();
            foreach (var l in liquidaciones)
            {
                if (!l.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    Guardar(l);
                }
                else
                {
                    Guardar(LiquidacionNueva);
                }
            }
        }

        public LiquidacionDeCuotaModeradora buscarPorNumeroLiquidacion(string numeroLiquidacion)
        {
            foreach (var l in Consultar())
            {
                if (l.NumeroLiquidacion.Equals(numeroLiquidacion))
                {
                    return l;
                }
            }
            return null;
        }

    }

}
