using Aplication.UserCase.Proveedors.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication
{
    public class MaperProfile : Profile
    {
        public MaperProfile()
        {
            CreateMap<Proveedor, ProveedorDto>().ReverseMap();
        }

    }
}
