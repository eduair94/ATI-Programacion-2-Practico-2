using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CitaMedica
    {
        int id;
        DateTime fecha;
        string cedula;
        string lugar;
        decimal s_precioBase;
        bool urgente;

        public CitaMedica()
        {

        }
        public CitaMedica(int id, DateTime fecha, string cedula, string lugar, decimal precioBase, bool urgente)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Cedula = cedula;
            this.Lugar = lugar;
            S_precioBase = precioBase;
            this.Urgente = urgente;
        }

        public int Id { get => id; set => id = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Cedula { get => cedula; set => cedula = value; }
        public string Lugar { get => lugar; set => lugar = value; }
        public decimal S_precioBase { get => s_precioBase; set => s_precioBase = value; }
        public bool Urgente { get => urgente; set => urgente = value; }

        public decimal CalcularCosto()
        {
            return urgente ? s_precioBase * 2 : s_precioBase;
        }

        public override string ToString()
        {
            string urgenteTexto = urgente ? "urgente" : "no urgente";
            string fechaTexto = fecha.ToString("dd/MM/yyyy");
            return $"ID: {id}, fecha: {fechaTexto}, cedula: {cedula}, lugar: {lugar}, precio base: {s_precioBase}, {urgenteTexto}";
        }
    }
}
