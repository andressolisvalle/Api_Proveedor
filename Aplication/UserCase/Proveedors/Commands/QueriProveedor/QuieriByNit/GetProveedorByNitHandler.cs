using Aplication.Common.Exceptions;
using Aplication.UserCase.Proveedors.Dto;
using AutoMapper;
using Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit
{
    public class GetProveedorByNitHandler : IRequestHandler<GetProveedorByNit, ProveedorDto>
    {
        private readonly ProveerdorServices _service;
        private readonly IMapper _mapper;

        public GetProveedorByNitHandler(ProveerdorServices service,
            IMapper mapper) =>
            (_service, _mapper) = (service, mapper);

        
        public async Task<ProveedorDto> Handle(GetProveedorByNit request, CancellationToken cancellationToken)
        {
            var buscarProveedor = await _service.GetSupplierById(request.Id);
            _ = buscarProveedor ?? throw new EntityNotFundException();
            //ArgumentNullException($"Este Id: {request.Id} No se encuentra registrado");
            return _mapper.Map<ProveedorDto>(buscarProveedor);
        }
    }
}
