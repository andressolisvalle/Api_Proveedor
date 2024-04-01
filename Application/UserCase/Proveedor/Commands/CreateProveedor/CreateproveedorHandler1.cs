
using Domain.Entities;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserCase.Proveedor.Commands.CreateProveedor
{
    public class CreateproveedorHandler : IRequestHandler<CreateProveedor>
    {
        private readonly ProveerdorServices _service;

        public CreateproveedorHandler(ProveerdorServices service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task<Unit> Handle(CreateProveedor request, CancellationToken cancellationToken)
        {
            var direccionPorveedor = new DireccionProveedor(request.Ciudad, request.Direccion, request.Departamento);

            var proveedor = new Proveedor
        }
    }
}
