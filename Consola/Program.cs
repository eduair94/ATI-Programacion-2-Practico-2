namespace Consola
{
    using Dominio;
    internal class Program
    {
        static void Main(string[] args)
        {
            Opciones();
        }

        static void Menu()
        {
            string[] titulos = { "Ejercicio 1", "Ejercicio 2", "Ejercicio 3", "Ejercicio 4" };

            int opcion = 1;
            foreach (string titulo in titulos)
            {
                Console.WriteLine($"{opcion} - {titulo}");
                opcion++;
            }
        }

        static int LeerEntero()
        {
            string? texto = Console.ReadLine();
            int resultado;
            while (!int.TryParse(texto, out resultado))
            {
                Console.Write("Error. Vuelva a ingresar el valor:");
                texto = Console.ReadLine();
            }
            return resultado;
        }

        static void Opciones()
        {
            int valor = -1;
            while (valor != 0)
            {
                Console.Clear();
                Menu();
                Console.Write("Ingrese opcion:");
                valor = LeerEntero();
                switch (valor)
                {
                    case 1:
                        Ejercicio1();
                        break;
                    case 2:
                        Ejercicio2();
                        break;
                    case 3:
                        Ejercicio3();
                        break;
                    case 4:
                        Ejercicio4();
                        break;
                    default:
                        break;
                }
                Console.ReadLine();
            }
            Console.WriteLine("Proceso terminado");
        }

        static void Ejercicio4()
        {
            try
            {
                CuentaBancaria cuentaBancaria = new("Juan", 100, Enums.TipoDeCuenta.CA, Enums.Moneda.USD, 1);
                cuentaBancaria.Validar();
                Console.WriteLine(cuentaBancaria.ToString());
                // Hacer un depósito
                cuentaBancaria.HacerDeposito(100, Enums.Moneda.USD);
                Console.WriteLine("Luego de depositar 100 USD:");
                Console.WriteLine(cuentaBancaria.ToString());
                cuentaBancaria.HacerRetiro(cuentaBancaria.SaldoActual);
                Console.WriteLine("Luego de retirar todo el saldo:");
                Console.Write(cuentaBancaria.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Ejercicio3()
        {
            CitaMedica citaMedica = new CitaMedica(1, DateTime.Now, "123456", "Hospital", 100, true);

            Console.WriteLine(citaMedica.ToString());
        }

        static void Ejercicio2()
        {
            string fechaNacimiento = "10/08/1994";
            DateTime fecha = DateTime.Parse(fechaNacimiento);
            Empleado empleado = new("Juan", "Perez", fecha, 100, 5, 160);
            Console.WriteLine(empleado.ToString());
            // Salario
            decimal salario = empleado.CalcularSalario();
            Console.WriteLine($"El salario del empleado es: {salario}");
            // Licencia
            int licencia = empleado.CalcularLicencia();
            Console.WriteLine($"La licencia del empleado es: {licencia}");
        }

        static void Ejercicio1()
        {
            Auto miAuto = new("Toyota", "Corolla", true, "ABC1234", 2010);
            try
            {
                miAuto.Validar();
                // Crear una instancia de Auto con datos reales

                // Mostrar la información del auto
                Console.WriteLine(miAuto.ToString());

                // Calcular y mostrar la patente
                decimal patente = miAuto.CalcularPatente();
                Console.WriteLine($"La patente del auto es: {patente}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
