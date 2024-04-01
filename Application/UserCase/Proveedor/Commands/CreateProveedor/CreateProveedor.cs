﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
 
namespace Application.UserCase.Proveedor.Commands.CreateProveedor;

    public record CreateProveedor(
        string Nit,
        string RazonSocial,
        string Direccion,
        string Ciudad,
        string Departamento,
        string Correo,
        string NombreContacto,
        string Correocontacto
        
     ):IRequest;


