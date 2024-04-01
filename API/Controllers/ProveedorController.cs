using Api.Examples.SupplierExamples;
using Aplication.UserCase.Proveedors.Commands.CreateProveedor;
using Aplication.UserCase.Proveedors.Commands.Deleteproveedor;
using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit;
using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriProveedores;
using Aplication.UserCase.Proveedors.Commands.UpdateProveedor;
using Aplication.UserCase.Proveedors.Dto;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]

public class ProveedorController : ControllerBase
{
    private  IMediator _mediator;

    public ProveedorController(IMediator mediator) => _mediator = mediator;
    public IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;

    [HttpPost]
    [Authorize]
    [SwaggerRequestExample(typeof(CreateProveedor), typeof(SupplierCreateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status409Conflict, typeof(SupplierCreateCommandNitDuplicate))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateProveedor command) => Ok(await Mediator.Send(command));


    [HttpGet]
    [Authorize]
    [SwaggerRequestExample(typeof(GetAllProveedores), typeof(GetSupplierQueryExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(GetAllProveedores), StatusCodes.Status200OK)]
    public async Task<IEnumerable<ProveedorDto>> GetAll()  
    {
        return await Mediator.Send(new GetAllProveedores());
    }

    [HttpGet("{id}")]
    [Authorize]
    [SwaggerRequestExample(typeof(GetProveedorByNit), typeof(GetProveedorByNitHandler))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(GetSupplierByIdResponseExample))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ProveedorDto> GetById(string id)
    {
        return await Mediator.Send(new GetProveedorByNit(id));
    }

    [HttpPut("{id}")]
    [Authorize]
    [SwaggerRequestExample(typeof(UpdateProveedor), typeof(SupplierUpdateCommandExample))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Update(UpdateProveedor command, string id)
    {
        if (id != command.ProveedorId)
        {
            throw new Exception("El Id no concuerdan");
        }

        return Ok(await Mediator.Send(command));
    }

    [HttpDelete("{id}")]
    [Authorize]
    [SwaggerResponseExample(StatusCodes.Status400BadRequest, typeof(Response<string>))]
    [SwaggerResponseExample(StatusCodes.Status404NotFound, typeof(SupplierByIdNoFound))]
    [SwaggerResponseExample(StatusCodes.Status200OK, typeof(StatusCodes))]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(Response<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(string id) => Ok(await Mediator.Send(new DeleteProveedor(id)));
}
