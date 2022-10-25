using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EjApi.Models
{
    public class Cliente
    {
        public int Id_Cliente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public  string Sexo { get; set; }
        public int Cuenta { get; set; }

    }

    public class Tarjetas
    {
        public int Id_Tarjeta { get; set; }
        public int Id_Cliente { get; set; }

        public int Numero_tarjeta { get; set; }
        public decimal Compra { get; set; }
        public decimal Monto { get; set; }
        public string Tipo_tarjeta { get; set; }
        public string Tipo_produto { get; set; }


    }
}
