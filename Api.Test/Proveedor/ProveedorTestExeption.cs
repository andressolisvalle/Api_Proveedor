using API.Controllers;
using Aplication.Common.Exceptions;
using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit;
using Aplication.UserCase.Proveedors.Dto;
using Application.UseCases.Auth.Commands.Authentication;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Api.Test.Proveedor
{
    public class ProveedorTestExeption
    {
        private readonly ProveedorController _proveedorController;
        private readonly Mock<IMediator> _mediator;


        public ProveedorTestExeption()
        {
            _mediator = new Mock<IMediator>();
            _proveedorController = new ProveedorController(_mediator.Object);
        }

        [Fact]
        public async Task Get_By_Id_Proveedor()
        {
            // Arrange
            //var direccionProveedor = new DireccionProveedor("Calle 1", "Ciudad 1", "Departamento 1");
            //var proveedorEsperado = new ProveedorDto("657d04a8192e26f65f3906a8", "12345678", "Bussiness", direccionProveedor,
            //    "Email@example.com", true, "Name Contact", "contactemail@example.com");

            var id = "123";

            _mediator.Setup(x => x.Send(It.IsAny<GetProveedorByNit>(), CancellationToken.None)).ThrowsAsync(new EntityNotFundException());

            //// Act
            //var result = await _proveedorController.GetById(id);

            var exception = await Xunit.Assert.ThrowsAsync<EntityNotFundException>(async () =>
            {
                await _proveedorController.GetById(id);
            });
            // Assert

            Xunit.Assert.IsType<EntityNotFundException>(exception);
            //Xunit.Assert.NotEqual(result.Id, id);
        }

    }
    
}
