using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.UpdateProveedor;

public record UpdateProveedor
(
    string ProveedorId,
    string Nit,
    string? RazonSocial,
    string? Direccion,
    string? Ciudad,
    string? Departamento,
    string? Correo,
    bool? Activo,
    string? NombreContacto,
    string? CorreoContacto
) : IRequest<Unit>;