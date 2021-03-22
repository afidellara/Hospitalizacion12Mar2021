using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Contributivo : LiquidacionDeCuotaModeradora
    {
        string estrato; 
        public override void CuotaModeradora()
        {
            TotalCuotaModeradora = Tope();
        }

        public int CalcularTarifa()
        {
            double SM = 800000;
            if (Salario < SM * 2)
            {
                estrato = "1"; 
                return 15;
            }
            else if ((Salario >= SM * 2)&& (Salario <= SM * 5))
            {
                estrato = "2";
                return 20;
            }
            else if (Salario > SM * 5)
            {
                estrato = "3";
                return 25;
            }
            return 0; 
        }
        public double Tope()
        {
            Tarifa = CalcularTarifa();
            TotalCuotaModeradora = (ValorServicio - ((ValorServicio * Tarifa) / 100));
            if (TotalCuotaModeradora >= 250000 && estrato.Equals("1"))
            {
                TopeMaximo = true; 
                return 250000;
            }
            else if (TotalCuotaModeradora >= 900000 && estrato.Equals("2"))
            {
                TopeMaximo = true;
                return 900000;
            }
            else if (TotalCuotaModeradora >= 900000 && estrato.Equals("3"))
            {
                TopeMaximo = true;
                return 1500000;
            }
            TopeMaximo = false;
            return TotalCuotaModeradora;
        }
    }
}
