using APLICATION.ExtensionS;
using AutoMapper;
using DOMAIN.Dtos.Inventario;
using DOMAIN.Entities.Inventario;
using DOMAIN.Helper.Tools;
using DOMAIN.Interfaces.IExtensionR;
using DOMAIN.Interfaces.IExtensionR.Inventario;
using DOMAIN.Interfaces.IExtensionS;
using DOMAIN.Interfaces.IExtensionS.Inventario;
using DOMAIN.Interfaces.IServices.Inventario;
using DOMAIN.Interfaces.IServicesExternals.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APLICATION.AppServices.Inventario
{
    public class ProductoServices : IProductoServices
    {
        private IExtensionRepository<IExtensionInventarioR> services;
        private IExtensionServices<IAzureStorageService> Azure;
        private IMapper mapper;

        public ProductoServices(IExtensionRepository<IExtensionInventarioR> services, IExtensionServices<IAzureStorageService> azure, IMapper mapper)
        {
            this.services = services;
            Azure = azure;
            this.mapper = mapper;
        }

        public async Task<List<ProductoGetDto>> GetAllProduct()
        {
         List<Producto> products = new List<Producto>();
            products = await services.ExtensionR.productoR.GetAllProduct();
            return mapper.Map<List<ProductoGetDto>>(products);
        }

        public async Task<ProductoDto> GetProductForId(Guid guid)
        {
            Producto productoDto = await services.ExtensionR.productoR.GetProductForId(guid);

            return mapper.Map<ProductoDto>(productoDto);
        }

        public async Task<Producto> RegistrarProducto(ProductoDto entidad)
        {
            Producto producto= mapper.Map<Producto>(entidad);

            await entidad.Files.ForEachAsync(async file =>
            {
              
                producto.imagenes.Add(new DOMAIN.Entities.Archivos.ImagenesProducto
                {
                    name = await Azure.Extension.UploadAsync(file, DOMAIN.Helper.Enums.AppsExternals.ContainerEnum.IMAGENES),
                }) ;
            });
             producto = await services.ExtensionR.productoR.InsertarProducto(producto);

            return producto;
        }
    }
}
