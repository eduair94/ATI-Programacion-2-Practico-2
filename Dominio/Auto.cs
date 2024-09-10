using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Auto
    {
        string marca;
        string modelo;
        bool exoneraImpuestos;
        string matricula;
        int anio;

        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public bool ExoneraImpuestos { get => exoneraImpuestos; set => exoneraImpuestos = value; } 
        public string Matricula { get => matricula; set => matricula = value; }
        public int Anio { get => anio; set => anio = value; }

        public Auto ()
        {

        }

        public Auto(string marca, string modelo, bool exoneraImpuestos, string matricula, int anio)
        {
            this.marca = marca;
            this.modelo = modelo;
            this.exoneraImpuestos = exoneraImpuestos;
            this.matricula = matricula;
            this.anio = anio;
        }

        public void Validar()
        {
            ValidarMatricula();
            ValidarMarca();
        }

        private void ValidarMatricula()
        {
            if(Matricula.Length != 7) throw new Exception("Matrícula inválida");
        }

        /** 
         * Los autos anteriores a 2015 si exoneran impuestos pagan
            $10.000, sino pagan $12.000. Y los posteriores a 2015 pagan $17.000
         */
        public decimal CalcularPatente()
        {
            decimal resultado = 17000;
            if (anio < 2015)
            {
                resultado = exoneraImpuestos ? 10000 : 12000;
            }  
            return resultado;
        }

        public override string ToString()
        {
            string exoneraTxt = exoneraImpuestos ? "exonera impuestos" : "NO exonera impuestos";
            return $"Este auto es de marca: {marca}, modelo: {modelo}, matrícula: {matricula}, año: {anio} y {exoneraTxt}";
        }

        public void ValidarMarca()
        {
            if(marca.Length < 3) throw new Exception("Marca inválida");
        }

    }
}
