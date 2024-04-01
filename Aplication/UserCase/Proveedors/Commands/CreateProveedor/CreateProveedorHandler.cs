using Domain.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.CreateProveedor
{
    public class CreateProveedorHandler : IRequestHandler<CreateProveedor, Unit>
    {
        private readonly ProveerdorServices _service;

        public CreateProveedorHandler(ProveerdorServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));

        }

        public async Task<Unit> Handle(CreateProveedor request, CancellationToken cancellationToken)
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
            var buscarProveedor = await _service.Find(filter => filter.Nit == request.Nit);

            if (buscarProveedor.Any())
            {
                throw new ArgumentNullException($"Este Nit: {request.Nit} Ya esta registrado");
            }

            await _service.CreateSupplier(proveedor);

            return Unit.Value;

        }
    }
}
