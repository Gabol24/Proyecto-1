using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    public class ClsMenu
    {
        // variable
        public static int opcion;
        // metodo para desplegar un menu
        public static void menu()
        {
            
            do // bucle que se ejecuta almenos una vez 
            {
                Console.WriteLine("--Menú Principal--");
                Console.WriteLine("1. Inicializar Vectores");
                Console.WriteLine("2. Realizar Pagos");
                Console.WriteLine("3. Consultar Pagos");
                Console.WriteLine("4. Modificar Pagos");
                Console.WriteLine("5. Eliminar Pagos");
                Console.WriteLine("6. Submenú Reportes");
                Console.WriteLine("7. Salir");
                Console.WriteLine("Digite una opción...");


                string input = Console.ReadLine();

                if (int.TryParse(input, out opcion))
                {
                    switch (opcion) // condicional que dependiendo de la opcion dada por el usuario muestra diferentes metodos
                    {
                        case 1:  ClsPagos.InicializarVectores();break;

                        case 2:  ClsPagos.RealizarPagos();break;

                        case 3: ClsPagos.ConsultarPagos(); break;

                        case 4: ClsPagos.ModificarFactura(); break;

                        case 5: ClsPagos.EliminarPago(); break;

                        case 6: ClsMenu.Submenu();break;

                        case 7: Console.WriteLine("Saliendo..."); break;

                        default: Console.WriteLine("Digite una opción correcta");  break;
                    }
                }
                else 
                {
                    Console.WriteLine("La opción ingresada no es válida. Por favor, ingrese un número.");
                }

            } while (opcion != 7);
        }
        public static void Submenu()// metodo para mostrar submenu opcion 6
        {
            do
            {
                Console.WriteLine("1- Ver todos los pagos");
                Console.WriteLine("2- Ver pagos por tipo de servicio");
                Console.WriteLine("3- Ver pagos por código de caja");
                Console.WriteLine("4- Ver dinero comisionado por servicios");
                Console.WriteLine("5- Regresar al menú principal");
                Console.WriteLine("Digite una opción");

                string subInput = Console.ReadLine();
                if (int.TryParse(subInput, out int submenuOp))
                {
                    switch (submenuOp)
                    {
                        case 1: ClsPagos.VerTodoslosPagos(); break;
                        case 2: ClsPagos.VerPagosTipoDeServicio(); break;
                        case 3: ClsPagos.PagosCaja(); break;
                        case 4: ClsPagos.MostrarResumenPagos(); break;
                        case 5: Console.WriteLine("Volviendo al menú principal"); return;
                        default: Console.WriteLine("Digite una opcion valida"); break;
                    }
                }
                else
                {
                    Console.WriteLine("La opción no es correcta. Ingrese un numero ");
                }
            } while (true);
        }



    }

}