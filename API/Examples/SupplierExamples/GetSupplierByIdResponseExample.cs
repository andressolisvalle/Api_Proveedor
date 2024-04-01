
using Aplication.UserCase.Proveedors.Dto;
using Domain.Entities;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples;

public class GetSupplierByIdResponseExample : IMultipleExamplesProvider<ProveedorDto>
{
    public IEnumerable<SwaggerExample<ProveedorDto>> GetExamples()
    {
        var supplierDto = new ProveedorDto(
            ObjectId.GenerateNewId().ToString()!,
            "12345678",
            "Business One",
            new DireccionProveedor(
                "calle 1",
                "ciudad 1",
                "departamento 1"
            ),
            "email@example.com",
            true,
            "Contact Name 1",
            "Contactemail@example.com"
        );

        yield return SwaggerExample.Create("supplierDto", supplierDto);
    }
}