using Aplication.UserCase.Proveedors.Commands.UpdateProveedor;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class SupplierUpdateCommandExample : IMultipleExamplesProvider<UpdateProveedor>
    {
        public IEnumerable<SwaggerExample<UpdateProveedor>> GetExamples()
        {
            var supplierCommand = new UpdateProveedor(
                ObjectId.GenerateNewId().ToString()!,
                "123",
                "BusinessName One",
                "Calle 1",
                "Ciudad 1",
                "Departamento 1",
                "Email@example.com",
                true,
                "Contact Name",
                "Contactemail@example.com"
            );
            yield return SwaggerExample.Create("supplierUpdateCommand", supplierCommand);
        }
    }
}