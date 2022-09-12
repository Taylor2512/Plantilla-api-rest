using AutoMapper;
using DOMAIN.Dtos.Archivos;
using DOMAIN.Dtos.Inventario;
using DOMAIN.Dtos.Persona;
using DOMAIN.Entities.Archivos;
using DOMAIN.Entities.Inventario;
using DOMAIN.Entities.Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMAIN.Helper.MapperConfig
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<UsuarioDo, Usuarios>().ForMember(e=>e.PasswordHash,y=>y.MapFrom(c=>c.Password)).ReverseMap();
            CreateMap<CredencialesUsuario, Usuarios>().ForMember(e=>e.PasswordHash,y=>y.MapFrom(c=>c.Password)).ReverseMap();
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, ProductoGetDto>().ReverseMap();
            CreateMap<ImagenesProductoDto, ImagenesProducto>().ReverseMap();

        }
    }
}
