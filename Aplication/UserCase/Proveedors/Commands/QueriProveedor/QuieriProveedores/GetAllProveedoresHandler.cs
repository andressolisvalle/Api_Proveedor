using Aplication.UserCase.Proveedors.Dto;
using AutoMapper;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriProveedores
{
    public class GetAllProveedoresHandler : IRequestHandler<GetAllProveedores, IEnumerable<ProveedorDto>>
    {
        private readonly ProveerdorServices _service;
        private readonly IMapper _mapper;

        public GetAllProveedoresHandler(ProveerdorServices service, IMapper mapper) => (_service, _mapper) = (service, mapper);

        public async Task<IEnumerable<ProveedorDto>> Handle(GetAllProveedores request, CancellationToken cancellationToken)
        {
            var buscarProveedor = _mapper.Map<List<ProveedorDto>>(await _service.GetAllSupplier());
            return buscarProveedor;
        }
    }
}
