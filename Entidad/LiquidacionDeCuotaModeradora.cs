using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public abstract class LiquidacionDeCuotaModeradora
    {
     
        public LiquidacionDeCuotaModeradora()
        {
            this.Cedula = Cedula;
            this.Nombre = Nombre;
            this.NumeroLiquidacion = NumeroLiquidacion;
            this.Afiliacion = Afiliacion;
            this.Salario = Salario;
            this.Servicio = Servicio;
            this.ValorServicio = ValorServicio;
        }

        public string Nombre { set; get; }

        public string Cedula { set; get; }

        public string NumeroLiquidacion { get; set; }

        public string Afiliacion { get; set; } 

        public double Salario { get; set; }

        public string Servicio { get; set; }

        public double ValorServicio { get; set; }

        public double TotalCuotaModeradora { get; set; }

        public int Tarifa { get; set; }

        public bool TopeMaximo { get; set; }
        
        public abstract void CuotaModeradora(); 

        public override string ToString()
        {
            return $"CEDULA: {Cedula} | NOMBRE: {Nombre} | NUMERO AFILIACION: {NumeroLiquidacion} | AFILIACION: {Afiliacion} | SALARIO: {Salario}|" +
                $"VALOR SERVICIO: {ValorServicio} | TARIFA: {Tarifa} | TOPE: {TopeMaximo} | CUOTA REAL: {ValorServicio} |CUOTA TOTAL: {TotalCuotaModeradora}"; 
        }
    }
}
