using Domain.Entities.Base;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Entities
{
    public class Proveedor: EntityBase<string>
    {

        public string Nit { get; set; }
        public string RazonSocial { get; set; }
        public DireccionProveedor DireccionProveedor { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public string NombreContacto { get; set; }
        public string CorreoContacto { get; set; }

        public Proveedor(string nit, string razonSocial, DireccionProveedor direccionProveedor, string correo, string nombreContacto, string correoContacto)
        {
            Nit = nit;
            RazonSocial = razonSocial;
            DireccionProveedor = direccionProveedor;
            Correo = correo;
            Activo = true;
            NombreContacto = nombreContacto;
            CorreoContacto = correoContacto;
        }

        public void Update(string? razonSocial, DireccionProveedor? direccionProveedor, string? correo, string? nombreContacto, string? correoContacto)
        {
            if (razonSocial != null && !RazonSocial.Equals(razonSocial)) RazonSocial = razonSocial;
            if (correo != null && !Correo.Equals(correo)) Correo = correo;
            if (nombreContacto != null && !NombreContacto.Equals(nombreContacto)) NombreContacto = nombreContacto;
            if (correoContacto != null && !CorreoContacto.Equals(correoContacto)) CorreoContacto = correoContacto;
            if (direccionProveedor != null)
            {
                direccionProveedor.Update(
                    direccionProveedor.Ciudad,
                    direccionProveedor.Direccion,
                    direccionProveedor.Departamento
                );
            }
        }

        public void CambioEstado(bool estado)
        {
            if(estado != Activo) Activo = estado;
        }

    }
}
