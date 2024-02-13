using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1
{
    internal class ClsPagos
    {
        #region  Atributos
        // variables para indicar si se inicializaron los vectores o no en el menú
        static bool vectoresInicializados = false;
        static bool pagosRealizados = false;
        // Atributos 
        static int[] numeropago = new int[10];
        static DateTime fecha = DateTime.Now;
        static DateTime hora = DateTime.Now;
        static int[] cedula = new int[10];
        static string[] nombre = new string[10];
        static string[] apellido1 = new string[10];
        static string[] apellido2 = new string[10];
        static int[] numerocaja = new int[10];
        static int[] tipoServicio = new int[10];
        static int[] numerofactura = new int[10];
        static double[] montoPagar = new double[10];
        static double[] montoComision = new double[10];
        static double[] montoDeducido = new double[10];
        static double[] montoPagaCliente = new double[10];
        static double[] vuelto = new double[10];
        // variable para registrar pagos 
        public static int Registropagos = 0;
        // lista
        public static List<ClsPagos> pagos = new List<ClsPagos>();
        // constructor
        public ClsPagos() { }
        #endregion
        //Metodo para hacer que el sistema se detenga unos milesegundos 
        public static void MensajeEspera(int milisegundos)
        {
            Console.WriteLine("Espere mientras se inicializan los arreglos");
            for (int i = 0; i < 10; i++)
            {
                // utiliza el metodo sleep para hacer que haya una pausa en la ejecusion 
                System.Threading.Thread.Sleep(milisegundos / 10);
            }
        }
        // Metodo para inicializar los arreglos 
        public static void InicializarVectores()
        {
            var valores = Enumerable.Range(1, 10);
            // mensaje del metodo MensajeEspera
            MensajeEspera(500);
            // Copiar los valores a los arreglos correspondientes
            //valores.Select(_ => DateTime.Now).ToArray().CopyTo(hora, 0);
            Console.WriteLine("Los vectores se entan inicializando" + "\n" + "Por favor espere...");
            valores.ToArray().CopyTo(numeropago, 0);
            valores.ToArray().CopyTo(cedula, 0);
            valores.Select(_ => "Nombre").ToArray().CopyTo(nombre, 0);
            valores.Select(_ => "Apellido1").ToArray().CopyTo(apellido1, 0);
            valores.Select(_ => "Apellido2").ToArray().CopyTo(apellido2, 0);
            valores.ToArray().CopyTo(numerocaja, 0);
            valores.ToArray().CopyTo(tipoServicio, 0);
            valores.ToArray().CopyTo(numerofactura, 0);
            valores.Select(_ => 0.0).ToArray().CopyTo(montoPagar, 0);
            valores.Select(_ => 0.0).ToArray().CopyTo(montoComision, 0);
            valores.Select(_ => 0.0).ToArray().CopyTo(montoDeducido, 0);
            valores.Select(_ => 0.0).ToArray().CopyTo(montoPagaCliente, 0);
            valores.Select(_ => 0.0).ToArray().CopyTo(vuelto, 0);

            vectoresInicializados = true;
            Console.WriteLine("Los arreglos han sido inicializados correctamente");

        }
        // Metodo para realizar los pagos 
        public static void RealizarPagos()
        {
            char respuesta = 'n';
            // condicional para verificar que los arreglos ya esten inicializados
            if (!vectoresInicializados)
            {
                Console.WriteLine("Error: Los Vectores no han sido inicializados. Por favor, inicialícelos primero.");
                return;
            }
            else
            {
                do
                {
                    if (Registropagos <= 10)
                    {
                        Console.WriteLine("Ingrese los siguientes datos para el pago:");
                        numeropago[Registropagos] = Registropagos + 1;
                        DateTime fecha = DateTime.Now;

                        Console.Write("Cédula: ");
                        /* con este while se valida que el usuario solo 
                          pueda digitar datos de tipo int ya que es una cedula */
                        while (!int.TryParse(Console.ReadLine(), out cedula[Registropagos]))
                        {
                            Console.WriteLine("Por favor, ingrese un número de cédula válido.");
                            Console.Write("Cédula: ");
                        }

                        Console.Write("Nombre: ");
                        // bucle para validar que no se digiten letras en este espacio y tampoco permita un espacio en blanco
                        while (true)
                        {
                            nombre[Registropagos] = Console.ReadLine();
                            // out _ se entiende que hay una variable pero que no le interesa usarla
                            if (int.TryParse(nombre[Registropagos], out _))
                            {
                                // si se digita un numero el sistema lo detecta y envia los siguientes datos 
                                Console.WriteLine("Por favor, ingrese un nombre válido, solo puede digitar letras.");
                                Console.Write("Nombre: ");
                            }
                            else if (string.IsNullOrWhiteSpace(nombre[Registropagos]))
                            {
                                Console.WriteLine("No puede dejar el espacio en blanco");
                                Console.Write("Nombre: ");
                            }
                            else
                            {
                                // si el dato que se digito no es int entonces se cierra 
                                break;
                            }
                        }

                        Console.Write("Apellido 1: ");
                        // bucle para validar que no se digiten numeros en este espacio 
                        while (true)
                        {
                            apellido1[Registropagos] = Console.ReadLine();

                            if (int.TryParse(apellido1[Registropagos], out _))
                            {
                                // si se digita un numero el sistema lo detecta y envia los siguientes datos 
                                Console.WriteLine("Por favor, ingrese un apellido válido, solo puede digitar letras).");
                                Console.Write("Apellido 1: ");
                            }
                            else if (string.IsNullOrWhiteSpace(apellido1[Registropagos]))
                            {
                                Console.WriteLine("No puede dejar el espacio en blanco");
                                Console.Write("Apellido 1: ");
                            }
                            else
                            {
                                // si el dato que se digito no es int entonces se cierra 
                                break;
                            }
                        }

                        Console.Write("Apellido 2: ");
                        // bucle para validar que no se digiten numeros en este espacio 
                        while (true)
                        {
                            apellido2[Registropagos] = Console.ReadLine();

                            if (int.TryParse(apellido2[Registropagos], out _))
                            {
                                // si se digita un numero el sistema lo detecta y envia los siguientes datos 
                                Console.WriteLine("Por favor, ingrese un apellido válido, solo puede digitar letras.");
                                Console.Write("Apellido 2: ");
                            }
                            else if (string.IsNullOrWhiteSpace(apellido2[Registropagos]))
                            {
                                Console.WriteLine("No puede dejar el espacio en blanco");
                                Console.Write("Apellido 2: ");
                            }
                            else
                            {
                                // si el dato que se digito no es int entonces se cierra 
                                break;
                            }
                        }

                        numerocaja[Registropagos] = new Random().Next(1, 4);

                        // variable para ingresar el dato
                        int tipodeservicioInput;
                        // Bucle para validar que el usuario digite un dato tipo int
                        do
                        {
                            Console.Write("Tipo de Servicio (1.Recibo de Luz, 2.Recibo Teléfono, 3.Recibo de Agua): ");

                            if (!int.TryParse(Console.ReadLine(), out tipodeservicioInput) || tipodeservicioInput < 1 || tipodeservicioInput > 3)
                            {
                                Console.WriteLine("Por favor, ingrese un número válido (1, 2, 3) para el tipo de servicio. ");
                            }
                            else
                            {
                                tipoServicio[Registropagos] = tipodeservicioInput;
                                break; // Salir del bucle si la entrada es válida
                            }

                        } while (true);

                        Console.Write("Número de Factura: ");
                        // Bucle para validar que el usuario digite un dato tipo int
                        while (!int.TryParse(Console.ReadLine(), out numerofactura[Registropagos]))
                        {
                            Console.WriteLine("Por favor, ingrese un número de factura válido.");
                            Console.Write("Numero de Factura: ");
                        }

                        Console.Write("Monto a Pagar: ");
                        while (!double.TryParse(Console.ReadLine(), out montoPagar[Registropagos]))
                        {
                            Console.WriteLine("Por favor, ingrese un monto válido.");
                            Console.Write("Monto a Pagar: ");
                        }

                        switch (tipoServicio[Registropagos])
                        {
                            case 1:
                                montoComision[Registropagos] = montoPagar[Registropagos] * 0.04;
                                break;
                            case 2:
                                montoComision[Registropagos] = montoPagar[Registropagos] * 0.055;
                                break;
                            case 3:
                                montoComision[Registropagos] = montoPagar[Registropagos] * 0.065;
                                break;
                            default:
                                Console.WriteLine("Tipo de Servicio no válido.");
                                break;
                        }

                        montoDeducido[Registropagos] = montoPagar[Registropagos] - montoComision[Registropagos];
                        do
                        {
                            Console.Write("Monto con lo que paga el cliente: ");

                            // Bucle para validar que el usuario digite un dato tipo double
                            while (!double.TryParse(Console.ReadLine(), out montoPagaCliente[Registropagos]))
                            {
                                Console.WriteLine("Por favor, ingrese un número de factura válido.");
                                Console.Write("Monto con lo que paga el cliente: ");
                            }

                            if (montoPagaCliente[Registropagos] < montoPagar[Registropagos])
                            {
                                Console.WriteLine("El monto pagado no puede ser menor al monto a pagar");
                            }

                        } while (montoPagaCliente[Registropagos] < montoPagar[Registropagos]);

                        vuelto[Registropagos] = montoPagaCliente[Registropagos] - montoPagar[Registropagos];

                        pagosRealizados = true;


                        Console.WriteLine("Se realizo el pago correctamente");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Número de Caja: {numerocaja[Registropagos]}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Número de Pago: {numeropago[Registropagos]}");
                        Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
                        Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
                        Console.WriteLine($"Cedula: {cedula[Registropagos]}");
                        Console.WriteLine($"Nombre: {nombre[Registropagos]}");
                        Console.WriteLine($"Apellido #1: {apellido1[Registropagos]}");
                        Console.WriteLine($"Apellido #2: {apellido2[Registropagos]}");
                        Console.WriteLine($"Tipo de Servicio: {tipoServicio[Registropagos]}");
                        Console.WriteLine($"Número de Factura: {numerofactura[Registropagos]}");
                        Console.WriteLine($"Monto a Pagar: {montoPagar[Registropagos]}");
                        Console.WriteLine($"Monto Comisión: {montoComision[Registropagos]}");
                        Console.WriteLine($"Monto Deducido: {montoDeducido[Registropagos]}");
                        Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[Registropagos]}");
                        Console.WriteLine($"Vuelto: {vuelto[Registropagos]}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        Console.Write("¿Desea realizar otro pago s/n? ");
                        Registropagos++;
                        respuesta = Char.Parse(Console.ReadLine().ToString());


                    }
                    else
                    {
                        Console.WriteLine("Vectores Llenos. No se pueden ingresar más pagos.");
                    }
                } while (respuesta != 'n');
            }


        }
        // Metodoo para consultar los pagos 
        public static void ConsultarPagos()
        {
            if (!pagosRealizados)
            {
                Console.WriteLine("Aun no se han registrado pagos");
                return;
            }
            else
            {
                Console.WriteLine("Digite el número de pago");
                int numeroPago = int.Parse(Console.ReadLine());

                if (numeroPago <= 0 || numeroPago > Registropagos || numeropago[numeroPago - 1] == 0)
                {
                    Console.WriteLine("El pago no se encuentra registrado");
                    return;
                }

                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine($"Número de Pago: {numeropago[numeroPago - 1]}");
                Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
                Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
                Console.WriteLine($"Cédula: {cedula[numeroPago - 1]}");
                Console.WriteLine($"Nombre: {nombre[numeroPago - 1]}");
                Console.WriteLine($"Apellido #1: {apellido1[numeroPago - 1]}");
                Console.WriteLine($"Apellido #2: {apellido2[numeroPago - 1]}");
                Console.WriteLine($"Tipo de Servicio: {tipoServicio[numeroPago - 1]}");
                Console.WriteLine($"Número de Factura: {numerofactura[numeroPago - 1]}");
                Console.WriteLine($"Monto a Pagar: {montoPagar[numeroPago - 1]}");
                Console.WriteLine($"Monto Comisión: {montoComision[numeroPago - 1]}");
                Console.WriteLine($"Monto Deducido: {montoDeducido[numeroPago - 1]}");
                Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[numeroPago - 1]}");
                Console.WriteLine($"Vuelto: {vuelto[numeroPago - 1]}");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------");
            }
        }

        public static void ModificarFactura(int[] numeroPago)
        {

            if (!pagosRealizados)
            {
                Console.WriteLine("No hay pagos registrados.");
                return;
            }

            foreach (var numPago in numeroPago)
            {
                int indice = BuscarPago(numPago);

                if (indice == -1)
                {
                    Console.WriteLine($"No se encontró el pago con el número de pago {numPago}.");
                    continue;
                }

                Console.WriteLine("Datos actuales del pago:");
                MostrarPago(indice);

                Console.WriteLine("Seleccione el dato que desea modificar:");
                Console.WriteLine("1. Fecha");
                Console.WriteLine("2. Hora");
                Console.WriteLine("3. Cédula");
                Console.WriteLine("4. Nombre");
                Console.WriteLine("5. Primer Apellido");
                Console.WriteLine("6. Segundo Apellido");
                Console.WriteLine("7. Número de caja");
                Console.WriteLine("8. Tipo de servicio");
                Console.WriteLine("9. Número de factura");
                Console.WriteLine("10. Monto a pagar");
                Console.Write("Seleccione una opción:");

                if (!int.TryParse(Console.ReadLine(), out int opcion) || opcion < 1 || opcion > 8)
                {
                    Console.WriteLine("Opción no válida.");
                    return;
                }

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Fecha modificada: " + fecha.ToString("MM / dd / yyyy"));

                        break;

                    case 2:
                        Console.WriteLine("Hora modificada: " + hora.ToString("hh:mm tt"));

                        break;

                    case 3:
                        Console.WriteLine("Ingrese la nueva cédula:");
                        if (int.TryParse(Console.ReadLine(), out int nuevaCedula))
                        {
                            cedula[indice] = nuevaCedula;
                        }
                        else
                        {
                            Console.WriteLine("Cédula no válida.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Ingrese los números de pago que desea modificar, separados por espacios:");
                        string[] input = Console.ReadLine().Split();
                        int[] numerosPago = Array.ConvertAll(input, int.Parse);

                        if (numerosPago.Length == 0)
                        {
                            Console.WriteLine("No se han ingresado números de pago.");
                            break;
                        }
                        ClsPagos.ModificarFactura(numerosPago);
                        break;

                    case 5:
                        ModificarDato("Primer Apellido", indice, apellido1);
                        break;
                    case 6:
                        ModificarDato("Segundo Apellido", indice, apellido2);
                        break;
                    case 7:
                        ModificarNumero("Número de caja", indice, numerocaja);
                        break;
                    case 8:
                        ModificarTipoServicio(indice);
                        break;
                    case 9:
                        ModificarNumero("Número de factura", indice, numerofactura);
                        break;
                    case 10:
                        ModificarMonto(indice);
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

                // Mostrar los datos actualizados de la factura
                Console.WriteLine("Datos actualizados del pago:");
                MostrarPago(indice);
            }
        }
        private static void ModificarDato(string nombreDato, int indice, string[] arreglo)
        {
            Console.WriteLine($"Ingrese el nuevo {nombreDato}:");
            arreglo[indice] = Console.ReadLine();
        }

        private static void ModificarNumero(string nombreDato, int indice, int[] arreglo)
        {
            Console.WriteLine($"Ingrese el nuevo {nombreDato}:");
            if (int.TryParse(Console.ReadLine(), out int nuevoNumero))
            {
                arreglo[indice] = nuevoNumero;
            }
            else
            {
                Console.WriteLine($"Error: {nombreDato} no válido.");
            }
        }

        private static void ModificarTipoServicio(int indice)
        {
            Console.WriteLine("Ingrese el nuevo tipo de servicio (1, 2 o 3):");
            if (int.TryParse(Console.ReadLine(), out int nuevoTipoServicio) && nuevoTipoServicio >= 1 && nuevoTipoServicio <= 3)
            {
                tipoServicio[indice] = nuevoTipoServicio;
            }
            else
            {
                Console.WriteLine("Tipo de servicio no válido.");
            }
        }

        private static void ModificarMonto(int indice)
        {
            Console.WriteLine("Ingrese el nuevo monto a pagar:");
            if (double.TryParse(Console.ReadLine(), out double nuevoMontoPagar))
            {
                montoPagar[indice] = nuevoMontoPagar;
            }
            else
            {
                Console.WriteLine("Monto a pagar no válido.");
            }
        }

        public static void MostrarPago(int indice)
        {
            Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
            Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
            Console.WriteLine("Cédula: " + cedula[indice]);
            Console.WriteLine("Nombre: " + nombre[indice]);
            Console.WriteLine("Primer Apellido: " + apellido1[indice]);
            Console.WriteLine("Segundo Apellido: " + apellido2[indice]);
            Console.WriteLine("Número de caja: " + numerocaja[indice]);
            Console.WriteLine("Tipo de servicio: " + tipoServicio[indice]);
            Console.WriteLine("Número de factura: " + numerofactura[indice]);
            Console.WriteLine("Monto a pagar: " + montoPagar[indice]);
        }


        public static void VerTodoslosPagos()
{
    Console.WriteLine("Reporte de todos los pagos");

    for (int i = 0; i < Registropagos; i++)
    {
        if (numeropago[i] != 0)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine($"Número de Pago: {numeropago[i]}");
            Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
            Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
            Console.WriteLine($"Cédula: {cedula[i]}");
            Console.WriteLine($"Nombre: {nombre[i]}");
            Console.WriteLine($"Apellido #1: {apellido1[i]}");
            Console.WriteLine($"Apellido #2: {apellido2[i]}");
            Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
            Console.WriteLine($"Número de Factura: {numerofactura[i]}");
            Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
            Console.WriteLine($"Monto Comisión: {montoComision[i]}");
            Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
            Console.WriteLine($"Vuelto: {vuelto[i]}");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }
    }
}

        public static void VerPagosTipoDeServicio()
        {
            try
            {
                Console.Write("Ingrese el tipo de servicio (1.Recibo de Luz, 2.Recibo de Teléfono, 3.Recibo de Agua): ");

                if (int.TryParse(Console.ReadLine(), out int tiposervicio) && tiposervicio >= 1 && tiposervicio <= 3)
                {
                    Console.WriteLine($"Reporte de pagos por tipo de servicio {tiposervicio}: ");

                    for (int i = 0; i < Registropagos; i++)
                    {
                        if (tipoServicio[i] == tiposervicio)
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------------");
                            Console.WriteLine("--------------------------------------------------------------------------------------------");
                            Console.WriteLine($"Número de Pago: {numeropago[i]}");
                            Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
                            Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
                            Console.WriteLine($"Cédula: {cedula[i]}");
                            Console.WriteLine($"Nombre: {nombre[i]}");
                            Console.WriteLine($"Apellido #1: {apellido1[i]}");
                            Console.WriteLine($"Apellido #2: {apellido2[i]}");
                            Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                            Console.WriteLine($"Número de Factura: {numerofactura[i]}");
                            Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                            Console.WriteLine($"Monto Comisión: {montoComision[i]}");
                            Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                            Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                            Console.WriteLine($"Vuelto: {vuelto[i]}");
                            Console.WriteLine("--------------------------------------------------------------------------------------------");
                            Console.WriteLine("--------------------------------------------------------------------------------------------");
                            Console.WriteLine();
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"¡¡ Se produjo un error: {ex.Message} !!");

            }

        }

        // Metodo que muestra la informacion de cada caja, Submenu opcion 3
        public static void PagosCaja()
        {
            Console.WriteLine("Digite el numero de caja del cual desea ver el reporte ");
            /* este if obtiene la informacion dada por el usuario la vaida y verifica si es mayorigual 1 o menorigual 4
             ademas verifica que el dato dado sea un numero*/
            if (int.TryParse(Console.ReadLine(), out int numeroCaja) && numeroCaja >= 1 && numeroCaja <= 4)
            {
                Console.WriteLine($"Ventas para la caja {numeroCaja}: ");
                // bucle para recorrer el arreglo en busca de la opcion dada por el usuario
                for (int i = 0; i < Registropagos; i++)
                {
                    // esta condicion es si el numero de caja se encontro
                    if (numerocaja[i] == numeroCaja)
                    {
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine($"Número de Pago: {numeropago[i]}");
                        Console.WriteLine("Fecha: " + fecha.ToString("MM / dd / yyyy"));
                        Console.WriteLine("Hora: " + hora.ToString("hh:mm tt"));
                        Console.WriteLine($"Cédula: {cedula[i]}");
                        Console.WriteLine($"Nombre: {nombre[i]}");
                        Console.WriteLine($"Apellido #1: {apellido1[i]}");
                        Console.WriteLine($"Apellido #2: {apellido2[i]}");
                        Console.WriteLine($"Tipo de Servicio: {tipoServicio[i]}");
                        Console.WriteLine($"Número de Factura: {numerofactura[i]}");
                        Console.WriteLine($"Monto a Pagar: {montoPagar[i]}");
                        Console.WriteLine($"Monto Comisión: {montoComision[i]}");
                        Console.WriteLine($"Monto Deducido: {montoDeducido[i]}");
                        Console.WriteLine($"Monto Paga Cliente: {montoPagaCliente[i]}");
                        Console.WriteLine($"Vuelto: {vuelto[i]}");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un numero de caja valido (1-4)");
            }
        }

        public static void MostrarResumenPagos()
        {
            if (!pagosRealizados)
            {
                Console.WriteLine("No hay pagos registrados.");
                return;
            }
            Dictionary<int, double> comisionPorTipo = new Dictionary<int, double>();
            
            Dictionary<int, int> transaccionesPorTipo = new Dictionary<int, int>();

            
            foreach (int tipo in Enumerable.Range(1, 3))
            {
                comisionPorTipo.Add(tipo, 0.0);
                transaccionesPorTipo.Add(tipo, 0);
            }

            for (int i = 0; i < Registropagos; i++)
            {
                int tipoServicioActual = tipoServicio[i];
                double comisionActual = montoComision[i];

                
                comisionPorTipo[tipoServicioActual] += comisionActual;
                
                transaccionesPorTipo[tipoServicioActual]++;
            }

            Console.WriteLine("------ Reporte Dineros Comisionado - Desglose por tipo de Servicio ------");
            Console.WriteLine("==================================================================================");
            Console.WriteLine("ITEM                    Cant.Transacciones                   Total Comisionado ");
            Console.WriteLine("==================================================================================");
            foreach (var kvp in comisionPorTipo)
            {
                int tipoServicio = kvp.Key;
                double comisionTotal = kvp.Value;
                int transacciones = transaccionesPorTipo[tipoServicio];

                // Verificar si hay transacciones para este tipo de servicio
                if (transacciones > 0)
                {
                    Console.WriteLine($"{tipoServicio}          {transacciones}                  {comisionTotal}");
                }
            }
            Console.WriteLine("==================================================================================");
            Console.WriteLine();
            int totalTransacciones = transaccionesPorTipo.Values.Sum();
            double totalComisiones = comisionPorTipo.Values.Sum();
            
            Console.WriteLine($"Total                     {totalTransacciones}               {totalComisiones}   ");

        }

        public static int BuscarPago(int numeroFactura)
        {
            for (int i = 0; i < numeropago[i]; i++)
            {
                if (numeropago[i] == numeroFactura)
                {
                    return i;
                }
            }
            return -1;
        }
        public static void EliminarPago()
        {
            int numeroPago;
            do
            {
                Console.WriteLine("Ingrese el número de *Pago* que desea Eliminar o ingrese 'X' para salir):");

                try
                {
                    string input = Console.ReadLine().ToLower();

                    if (input == "x")
                    {
                        Console.WriteLine("***Volviendo al Menú Principal***");
                        return;
                    }

                    if (int.TryParse(input, out numeroPago))
                    {
                        int indice = BuscarPago(numeroPago);

                        if (indice != -1)
                        {
                            numeropago[indice] = 0;
                            cedula[indice] = 0;
                            nombre[indice] = null;
                            apellido1[indice] = null;
                            apellido2[indice] = null;
                            numerocaja[indice] = 0;
                            tipoServicio[indice] = 0;
                            numerofactura[indice] = 0;
                            montoPagar[indice] = 0;
                            montoComision[indice] = 0;
                            montoDeducido[indice] = 0;
                            montoPagaCliente[indice] = 0;
                            vuelto[indice] = 0;

                            Console.WriteLine($"¡¡ El Pago #{numeroPago} ha sido eliminado correctamente !!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"¡¡ El Pago #{numeroPago} no fue encontrado en el sistema !!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("**** Por favor ingrese un número de pago valido o 'X' para salir ****");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"¡¡ Se produjo un error: {ex.Message} !!");
                }

            } while (true);
        }
    }
}    