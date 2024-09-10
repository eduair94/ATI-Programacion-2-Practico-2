using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Empleado
    {
        string nombre;
        string apellido;
        DateTime fechaNacimiento;
        decimal valorHora;
        int antiguedad;
        int horasTrabajadas;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public decimal ValorHora { get => valorHora; set => valorHora = value; }
        public int Antiguedad { get => antiguedad; set => antiguedad = value; }
        public int HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }


        public Empleado()
        {

        }

        public Empleado(string nombre, string apellido, DateTime fechaNacimiento, decimal valorHora, int antiguedad, int horasTrabajadas)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.valorHora = valorHora;
            this.antiguedad = antiguedad;
            this.horasTrabajadas = horasTrabajadas;
        }

        public decimal CalcularSalario()
        {
            /*
             * El salario de un empleado se calcula multiplicando el valor de la hora por la cantidad de horas trabajadas
             */
            return valorHora * horasTrabajadas;
        }

        public int CalcularLicencia()
        {
            /*
             * El método calcular licencia debe retornar la cantidad de días de licencia que le corresponden sabiendo que, si tiene una antigüedad menor o igual a 5, le corresponden 20
                días, si esta entre 5 y 9 le corresponden 21 días, y más de 10 son 25 días
             * */
            int resultado;
            if( antiguedad <= 5)
            {
                resultado = 20;
            }
            else if (antiguedad <= 9)
            {
                resultado = 21;
            }
            else
            {
                resultado = 25;
            }
            return resultado;
        }

        public override string ToString()
        {
            string fechaNacimientoTexto = fechaNacimiento.ToString("dd/MM/yyyy");
            return $"Empleado: {nombre} {apellido}, nacido el {fechaNacimientoTexto}, valor hora: {valorHora} dólares, antiguedad: {antiguedad} años, horas trabajadas: {horasTrabajadas} hrs";
        }
    }


}
