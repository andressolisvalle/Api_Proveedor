using Aplication.UserCase.Proveedors.Commands.QueriProveedor.QuieriByNit;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Filters;

namespace Api.Examples.SupplierExamples
{
    public class GetSupplierByIdQueryExample : IMultipleExamplesProvider<GetProveedorByNit>
    {
        public IEnumerable<SwaggerExample<GetProveedorByNit>> GetExamples()
        {
            var supplierQuery = new GetProveedorByNit(
                ObjectId.GenerateNewId().ToString()!
            );
            yield return SwaggerExample.Create("supplierQuery", supplierQuery);
        }
    }
}