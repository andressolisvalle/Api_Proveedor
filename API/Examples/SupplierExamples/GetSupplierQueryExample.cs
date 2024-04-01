using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriProveedores;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class GetSupplierQueryExample : IMultipleExamplesProvider<GetAllProveedores>
    {
        public IEnumerable<SwaggerExample<GetAllProveedores>> GetExamples()
        {
            var supplierQuery = new GetAllProveedores(
                );
            yield return SwaggerExample.Create("supplierQuery", supplierQuery);
        }
    }
}