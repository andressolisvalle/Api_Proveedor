using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
namespace Application.UserCase.Proveedor.Dto
{
    public record ProveedorDto(
        string Id,
        string Nit,
        string BusinessName,
        DireccionProveedor DireccionProveedor,
        string Correo,
        bool Activo,
        string NombreContacro,
        string CorreoContacto
    )
    {

    }
}
