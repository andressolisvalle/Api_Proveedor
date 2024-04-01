using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.Deleteproveedor
{
    public class DeleteProveedorHandler : IRequestHandler<DeleteProveedor,Unit>
    {
        private readonly ProveerdorServices _service;


        public DeleteProveedorHandler(ProveerdorServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Unit> Handle(DeleteProveedor request, CancellationToken cancellationToken)
        {
            var buscarProveedor = await _service.GetSupplierById(request.id);

            if (buscarProveedor == null)
                throw new ArgumentNullException($"No existe ningun proveedor con este Id : {request.id}");

            await _service.DeleteSupplier(buscarProveedor);

            return Unit.Value;
        }
    }
}
