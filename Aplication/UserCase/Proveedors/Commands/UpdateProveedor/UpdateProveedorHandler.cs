using Domain.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.UpdateProveedor
{
    public class UpdateProveedorHandler : IRequestHandler<UpdateProveedor, Unit>
    {
        private readonly ProveerdorServices _service;
        public UpdateProveedorHandler(ProveerdorServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Unit> Handle(UpdateProveedor request, CancellationToken cancellationToken)
        {
            var direccionProveedor = new DireccionProveedor();

            direccionProveedor.Direccion = request.Direccion;
            direccionProveedor.Ciudad = request.Ciudad;
            direccionProveedor.Departamento = request.Departamento;

            var buscarProveedor = await _service.GetSupplierById(request.ProveedorId);

            if (buscarProveedor == null)
                throw new ArgumentNullException($"No existe ningun proveedor con este Nit : {request.ProveedorId}");

            await _service.UpdateSupplier(
                request.ProveedorId,
                request.RazonSocial,
                direccionProveedor,
                request.Correo,
                request.Activo,
                request.NombreContacto,
                request.CorreoContacto
            );
            return Unit.Value;
        }
    }
}
