using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Subsidiado : LiquidacionDeCuotaModeradora
    {
        public override void CuotaModeradora()
        {
            TotalCuotaModeradora = Tope();
        }

        public double Tope()
        {
            Tarifa = 5; 
            TotalCuotaModeradora = ValorServicio-(ValorServicio * Tarifa/100);
            if (TotalCuotaModeradora >= 200000)
            {
                TopeMaximo = true; 
                return 200000; 
            }
            TopeMaximo = false; 
            return TotalCuotaModeradora; 
        }
    }
}
