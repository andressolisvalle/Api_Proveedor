using API.Controllers;
using Aplication.UserCase.Proveedors.Commands.CreateProveedor;
using Aplication.UserCase.Proveedors.Commands.Deleteproveedor;
using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit;
using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriProveedores;
using Aplication.UserCase.Proveedors.Commands.UpdateProveedor;
using Aplication.UserCase.Proveedors.Dto;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
namespace Api.Test.Proveedor
{
    public class ProveeedorTestStatus200
    {
        private readonly ProveedorController _proveedorController;
        private readonly Mock<IMediator> _mediator;


        public ProveeedorTestStatus200()
        {
            _mediator = new Mock<IMediator>();
            _proveedorController = new ProveedorController(_mediator.Object);
        }

        [Fact]
        public async Task Create_Proveedor_status_200()
        {
            // Arrange
            var createProveedor = new CreateProveedor(
                "12345789",
                "Bussiness one",
                "Calle 1",
                "Ciudad 1",
                "Departamento 1",
                "email@example.com",
                "Contact Name",
                "ContactEmail@mail.com");

            _mediator.Setup(m => m.Send(It.IsAny<CreateProveedor>(), default)).ReturnsAsync(Unit.Value);

            // Act
            var result = await _proveedorController.Create(createProveedor);

            // Assert
            Xunit.Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Get_All_Proveedores()
        {
            // Arrange
            var returnSuppliers = new List<ProveedorDto>() { };

            _mediator.Setup(m => m.Send(It.IsAny<GetAllProveedores>(), default))
                .ReturnsAsync(returnSuppliers);
            // Act

            var result = await _proveedorController.GetAll();

            // Assert
            Xunit.Assert.IsAssignableFrom<IEnumerable<ProveedorDto>>(result);

        }

        [Fact]
        public async Task Get_By_Id_Proveedor()
        {
            // Arrange
            var direccionProveedor = new DireccionProveedor("Calle 1", "Ciudad 1", "Departamento 1");
            var proveedorEsperado = new ProveedorDto("657d04a8192e26f65f3906a8", "12345678", "Bussiness", direccionProveedor,
                "Email@example.com", true, "Name Contact", "contactemail@example.com");

            var id = "657d04a8192e26f65f3906a8";

            _mediator.Setup(x => x.Send(It.IsAny<GetProveedorByNit>(), CancellationToken.None))
                .ReturnsAsync(proveedorEsperado);

            // Act
            var result = await _proveedorController.GetById(id);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.IsType<ProveedorDto>(result);
            Xunit.Assert.Equal(result.Id, id);
        }

        [Fact]
        public async Task Modify_Proveedor_Status_200()
        {
            // Arrange
            var command = new UpdateProveedor(
                "657d04a8192e26f65f3906a8",
                "12345678",
                "Bussiness",
                "Calle1",
                "Ciudad 1",
                "Departamento 1",
                "Email@example.com",
                true,
                "Name Contact",
                "contactemail@example.com");

            var id = "657d04a8192e26f65f3906a8";

            _mediator.Setup(x => x.Send(It.IsAny<UpdateProveedor>(), CancellationToken.None))
                .ReturnsAsync(Unit.Value);
            ;

            // Act
            var result = await _proveedorController.Update(command, id);

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Proveedor_Status_200()
        {
            // Arrange
            var id = "657d04a8192e26f65f3906a8";

            _mediator.Setup(x => x.Send(It.IsAny<DeleteProveedor>(), CancellationToken.None))
                .ReturnsAsync(Unit.Value);

            // Act
            var result = await _proveedorController.Delete(id);

            // Assert
            //Xunit.Assert.NotNull(result);
            Xunit.Assert.IsType<OkObjectResult>(result);
        }
    }
}