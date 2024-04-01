using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DireccionProveedor
    {
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public string Departamento { get; set; }

        public DireccionProveedor()
        {
            
        }
        public DireccionProveedor(string ciudad, string direccion, string departamento)
        {
            Ciudad = ciudad;
            Direccion = direccion;
            Departamento = departamento;
        }

        public void Update(string? ciudad, string? direccion, string? departamento)
        {
            if (direccion != null && !Direccion.Equals(direccion)) Direccion = direccion;
            if (ciudad != null && !Ciudad.Equals(ciudad)) Ciudad = ciudad;
            if (departamento != null && !Departamento.Equals(departamento)) Departamento = departamento;
        }


    }
}
