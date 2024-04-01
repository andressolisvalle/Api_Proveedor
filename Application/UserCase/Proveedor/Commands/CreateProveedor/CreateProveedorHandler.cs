using Domain.Entities;
using Domain.Services;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCase.Proveedor.Commands.CreateProveedor
{
    public class CreateProveedorHandler : IRequestHandler<CreateProveedor>
    {
         private readonly ProveerdorServices _service;

        public CreateProveedorHandler(ProveerdorServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
           
        }
        public Task<Unit> Handle(CreateProveedor request, CancellationToken cancellationToken)
        {
            var direccionPorveedor = new DireccionProveedor(request.Ciudad, request.Direccion, request.Departamento);

            var proveedor = new Proveedor
                (
                    request.Nit,
                    request.RazonSocial,
                    direccionPorveedor,
                    request.Correo,
                    request.NombreContacto,
                    request.Correocontacto
                );

            throw new NotImplementedException();
        }
    }
}
