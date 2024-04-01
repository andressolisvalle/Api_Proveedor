using Aplication.UserCase.Proveedors.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriProveedores
{
    public class GetAllProveedores : IRequest<IEnumerable<ProveedorDto>>
    {
    }
}
