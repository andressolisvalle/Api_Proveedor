using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UserCase.Proveedors.Commands.Deleteproveedor;

public record DeleteProveedor(string id) : IRequest<Unit>;
