using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.CreateProveedor
{
    public record CreateProveedor(
        string Nit,
        string RazonSocial,
        string Direccion,
        string Ciudad,
        string Departamento,
        string Correo,
        string NombreContacto,
        string Correocontacto

     ) : IRequest<Unit>;  
}
