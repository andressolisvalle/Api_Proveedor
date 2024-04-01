using Aplication.UserCase.Proveedors.Dto;
using MediatR;
namespace Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit;

public record GetProveedorByNit(string Id) : IRequest<ProveedorDto>;