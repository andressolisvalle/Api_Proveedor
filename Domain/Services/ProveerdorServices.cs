using Domain.Entities;
using Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProveerdorServices
    {
        private readonly IGenericRepository<Proveedor> _proveedorRepository;
        public ProveerdorServices(IGenericRepository<Proveedor> proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<Proveedor> GetSupplierById(string proveerdorId)
        {
            return await _proveedorRepository.GetById(proveerdorId);
        }

        public async Task<IEnumerable<Proveedor>> Find(Expression<Func<Proveedor, bool>> filter)
        {
            return await _proveedorRepository.FindAsync(filter);
        }
        public async Task<IEnumerable<Proveedor>> GetAllSupplier()
        {
            return await _proveedorRepository.GetAll();
        }
        public async Task CreateSupplier(Proveedor proveedor)
        {
            await _proveedorRepository.Add(proveedor);
        }

        public async Task UpdateSupplier(
        string? proveedorId,
        string? razonSocial,
        DireccionProveedor? direccionProveedor,
        string? correo,
        bool? activo,
        string? nombreContacto,
        string? correoContacto
    )
        {
            var buscarProveedor = await _proveedorRepository.GetById(proveedorId);
            if (buscarProveedor.Activo != activo && activo != null)
            {
                buscarProveedor.CambioEstado(activo.Value);
            }

            buscarProveedor.Update(razonSocial,direccionProveedor,correo,nombreContacto,correoContacto);
            await _proveedorRepository.Update(buscarProveedor);
        }

        public async Task DeleteSupplier(Proveedor proveedor)
        {
            proveedor.CambioEstado(false);
            await _proveedorRepository.Delete(proveedor);
        }

        public async Task<bool> ExistsProveedor(string id)
        {
            return await _proveedorRepository.Exist(id);
        }
    }
}
