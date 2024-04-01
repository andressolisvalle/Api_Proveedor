using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Dto
{
    public record ProveedorDto(
        string Id,
        string Nit,
        string RazonSocial,
        DireccionProveedor DireccionProveedor,
        string Correo,
        bool Activo,
        string NombreContacto,
        string CorreoContacto

    )
    {
    }
}
