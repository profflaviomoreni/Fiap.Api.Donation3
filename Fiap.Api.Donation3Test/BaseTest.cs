using AutoMapper;
using Fiap.Api.Donation3.ViewModel;
using Fiap.Api.Donation3.Models;

namespace Fiap.Api.Donation3Test
{
    public class BaseTest
    {
        protected readonly IMapper _mapper;

        public BaseTest()
        {
            var configMapper = new MapperConfiguration(m =>
            {
                m.AllowNullDestinationValues = true;
                m.AllowNullCollections = true;

                m.CreateMap<UsuarioModel, LoginRequestVM>();
                m.CreateMap<LoginRequestVM, UsuarioModel>();

                m.CreateMap<UsuarioModel, LoginResponseVM>();
                m.CreateMap<LoginResponseVM, UsuarioModel>();

                m.CreateMap<CategoriaModel, CategoriaResponseViewModel>();
                m.CreateMap<CategoriaRequestViewModel, CategoriaModel>();

                m.CreateMap<UsuarioModel, UsuarioResponseViewModel>();
                m.CreateMap<UsuarioRequestViewModel, UsuarioModel>();

                m.CreateMap<UsuarioModel, UsuarioPatchViewModel>();
                m.CreateMap<UsuarioPatchViewModel, UsuarioModel>();


                m.CreateMap<ProdutoRequestViewModel, ProdutoModel>();

                m.CreateMap<ProdutoPatchViewModel, ProdutoModel>()
                        .ForAllMembers(opts =>
                                            opts.Condition((src, dest, srcMember) => srcMember != null)
                                       );
                m.CreateMap<ProdutoModel, ProdutoPatchViewModel>();

                m.CreateMap<ProdutoModel, ProdutoResponseViewModel>()
                        .ForMember(dest => dest.NomeCategoria, opt => opt.MapFrom(src => src.Categoria != null ? src.Categoria.NomeCategoria : string.Empty))
                        .ForMember(dest => dest.NomeUsuario, opt => opt.MapFrom(src => src.Usuario != null ? src.Usuario.NomeUsuario : string.Empty));

            });

            _mapper = configMapper.CreateMapper();
        }
    }
}
