using API.Controllers;
using Aplication.UserCase.Proveedors.Commands.CreateProveedor;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace Api.Test
{
    public class ProveeedorTest
    {
        private readonly ProveedorController _proveedorController;
        private readonly Mock<IMediator> _mediator;


        public ProveeedorTest()
        {
            _mediator = new Mock<IMediator>();
            _proveedorController = new ProveedorController();
        }

        [Fact]
        public async Task Create_Provider_Without_Throwing_Exceptionss()
        {
            // Arrange
            var supplierCreateCommand = new CreateProveedor("1234578", "Bussiness one", "Calle 1", "Ciudad 1",
                "Departamento 1", "email@example.com", "Contact Name", "ContactEmail@mail.com");
            _mediator.Setup(m => m.Send(It.IsAny<CreateProveedor>(), default))
                .ReturnsAsync(Unit.Value);
            // Act

            var result = await _proveedorController.Create(supplierCreateCommand);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Xunit.Assert.IsType<OkObjectResult>(result);
        }
    }
}