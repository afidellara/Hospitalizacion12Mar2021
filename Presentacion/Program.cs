using System;
using Entidad;
using Logica;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            string nombre, cedula;
            string numeroLiquidacion;
            string afiliacion;
            double salario;
            string servicio;
            double valorServicio;
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("VIDA Y SALUD");
                Console.WriteLine("M E N U");
                Console.WriteLine("1. Registrar pulsaciones");
                Console.WriteLine("2. Consultar lista de pacientes");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Ver informacion por persona");
                Console.WriteLine("5. Modificar");
                Console.WriteLine("6. Salir");
                do
                {
                    Console.Write("Seleccione: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                } while (opcion < 0 || opcion > 6);

                CuotaModeradoraService cuotaModeradoraService = new CuotaModeradoraService();

                switch (opcion)
                {
                    case 1:
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("REGISTRO");
                            Console.WriteLine("Cedula: ");
                            cedula = Console.ReadLine();

                            Console.WriteLine("Nombre: ");
                            nombre = Console.ReadLine();

                            Console.WriteLine("Numero de liquidacion");
                            numeroLiquidacion = Console.ReadLine(); 

                            Console.WriteLine("Tipo de afiliacion: ");
                            afiliacion = Console.ReadLine();

                            Console.WriteLine("Salario devengado");
                            salario = double.Parse(Console.ReadLine());

                            Console.WriteLine("Servicio prestado");
                            servicio = Console.ReadLine();

                            Console.WriteLine("Valor servicio prestado");
                            valorServicio = double.Parse(Console.ReadLine());

                            if (afiliacion.Equals("CON"))
                            {
                                LiquidacionDeCuotaModeradora liquidacion = new Contributivo()
                                {
                                    Cedula = cedula,
                                    Nombre = nombre,
                                    NumeroLiquidacion = numeroLiquidacion,
                                    Afiliacion = afiliacion,
                                    Salario = salario,
                                    Servicio = servicio,
                                    ValorServicio = valorServicio,
                                };
                                liquidacion.CuotaModeradora();
                                Console.WriteLine(cuotaModeradoraService.Guardar(liquidacion));
                            }
                            else if(afiliacion.Equals("SUB"))
                            {
                                LiquidacionDeCuotaModeradora liquidacion = new Subsidiado()
                                {
                                    Cedula = cedula,
                                    Nombre = nombre,
                                    NumeroLiquidacion = numeroLiquidacion,
                                    Afiliacion = afiliacion,
                                    Salario = 0,
                                    Servicio = servicio,
                                    ValorServicio = valorServicio,
                                };
                                liquidacion.CuotaModeradora();
                                Console.WriteLine(cuotaModeradoraService.Guardar(liquidacion));
                            }
                            
                        } while (DeseaContinuar().Equals("S"));
                        break;
                    case 2:
                        Console.WriteLine("CONSULTAR");
                        Console.WriteLine("LISTA DE PACIENTES");
                        ConsultaRespuesta consulta = cuotaModeradoraService.Consultar();
                        if (!consulta.Error)
                        {
                            foreach (var l in consulta.Liquidaciones)
                            {
                                Console.WriteLine(l.ToString());
                            }
                        }
                        else
                        {
                            Console.WriteLine(consulta.Error);
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        string afiliacionFiltro;
                        
                        Console.WriteLine("CONSULTAR POR AFILIACION");
                        Console.WriteLine("CON  O  SUB: ");
                        afiliacionFiltro = Console.ReadLine();
                        ConsultaRespuesta consulta1 = cuotaModeradoraService.ConsultarPorAfiliacion(afiliacionFiltro);
                        if (!consulta1.Error)
                        {
                            foreach (var l in consulta1.Liquidaciones)
                            {
                                if (afiliacionFiltro.Equals("CON"))
                                {
                                    Console.WriteLine(l.ToString());
                                }
                                else if (afiliacionFiltro.Equals("SUB"))
                                {
                                    Console.WriteLine(l.ToString());
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine(consulta1.Error);
                        }
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break; 
                }

            } while (opcion != 6);
        }

        private static string DeseaContinuar()
        {
            string repetir;
            Console.WriteLine("-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-");
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
            do
            {
                Console.WriteLine("Desea continuar? S/N ");
                repetir = Console.ReadLine();
            } while (repetir.ToUpper().Equals("S") && repetir.ToUpper().Equals("N"));

            return repetir;
        }
    }
}

