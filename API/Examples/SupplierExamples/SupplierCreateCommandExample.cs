using Aplication.UserCase.Proveedors.Commands.CreateProveedor;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class SupplierCreateCommandExample : IMultipleExamplesProvider<CreateProveedor>
    {
        public IEnumerable<SwaggerExample<CreateProveedor>> GetExamples()
        {
            var supplierCommand = new CreateProveedor(
                "12345678",
                    "Bussiness One",
                "Calle 1",
                "Ciudad 1",
                "Departamento 1",
                "Email@example.com0",
                "Name Contact",
                "contactemail@example.com"
            );
            yield return SwaggerExample.Create("supplierCreateCommand", supplierCommand);
        }
    }
}