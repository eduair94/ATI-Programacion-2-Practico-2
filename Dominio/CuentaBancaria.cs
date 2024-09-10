using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class CuentaBancaria
    {
        string titular;
        decimal saldoActual;
        Enums.TipoDeCuenta tipoCuenta;
        Enums.Moneda moneda;
        int id;
        int contadorRetiros = 0;
        int numeroCuenta;
        static List<int> nroCuentas = new List<int>();

        public CuentaBancaria()
        {

        }

        public CuentaBancaria(string titular, decimal saldoActual, Enums.TipoDeCuenta tipoCuenta, Enums.Moneda moneda, int numeroCuenta)
        {
            this.titular = titular;
            this.saldoActual = saldoActual;
            this.tipoCuenta = tipoCuenta;
            this.moneda = moneda;
            this.numeroCuenta = numeroCuenta;
        }

        public string Titular { get => titular; }
        public decimal SaldoActual { get => saldoActual; }
        public int NumeroCuenta { get => numeroCuenta; }
        internal Enums.TipoDeCuenta TipoCuenta { get => tipoCuenta; }
        internal Enums.Moneda Moneda { get => moneda; }

        public void Validar()
        {
            ValidarNroCuenta();
        }

        public void ValidarNroCuenta()
        {
            bool nroCuentaExiste = nroCuentas.Contains(numeroCuenta);
            if(nroCuentaExiste) throw new Exception("El número de cuenta ya existe");
            nroCuentas.Add(numeroCuenta);
        }

        public void HacerDeposito(decimal monto, Enums.Moneda monedaEntrante)
        {
            /**
             * Se podrá hacer un depósito a la cuenta, se debe controlar que sea de la misma moneda y que no supere los $ 50000 o u$s 1000. Este método debe indicar si fue posible realizar la
                operación.
             * */
            bool esMonedaValida = monedaEntrante == this.moneda;
            if (!esMonedaValida) throw new Exception($"Los depósitos deben realizarse en {moneda}");
            int montoMax = GetMaxDeposito();
            bool esMontoValido = monto <= montoMax;
            if (!esMontoValido) throw new Exception($"Él depósito debe ser inferior a {montoMax}");
            // Sumar monto al saldo actual. 
            saldoActual += monto;
        }

        int GetMaxDeposito()
        {
            int maxDeposito = 0;
            switch(moneda)
            {
                case Enums.Moneda.USD:
                    maxDeposito = 1000;
                    break;
                case Enums.Moneda.UYU:
                    maxDeposito = 50000;
                    break;
            }
            return maxDeposito;
        }

        decimal AgregarComision(decimal monto)
        {
            /*  
             * Agregue la siguiente regla, después del quinto retiro el banco va a cobra una comisión
                de $50 a las cuentas en $ y u$s1 a las cuentas en dólares
             * */
            if (contadorRetiros >= 5)
            {
                if (moneda == Enums.Moneda.USD)
                {
                    monto += 1;
                }
                else
                {
                    monto += 50;
                }
            }
            return monto;
        }

        public void HacerRetiro(decimal monto)
        {
            monto = AgregarComision(monto);
            // Verificar que el monto no supere el saldo actual.
            bool puedeRetirar = monto <= saldoActual;
            // Se resta el monto al saldo de la cuenta.
            if (!puedeRetirar) throw new Exception($"Saldo insuficiente para realizar el retiro, faltan {saldoActual - monto} {moneda}");
            saldoActual -= monto;
            contadorRetiros++;
        }

        public override string ToString()
        {
            return $"Titular: {titular}, Saldo actual: {saldoActual}, Tipo de cuenta: {tipoCuenta}, Moneda: {moneda}, Id: {id}";
        }
    }
}
