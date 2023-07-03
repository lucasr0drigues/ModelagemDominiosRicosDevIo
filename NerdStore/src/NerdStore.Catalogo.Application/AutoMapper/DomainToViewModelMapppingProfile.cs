using AutoMapper;
using NerdStore.Catalogo.Application.ViewModels;
using NerdStore.Catalogo.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Application.AutoMapper
{
    public class DomainToViewModelMapppingProfile : Profile
    {
        public DomainToViewModelMapppingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(x => x.Largura, m => m.MapFrom(e => e.Dimensoes.Largura))
                .ForMember(x => x.Altura, m => m.MapFrom(e => e.Dimensoes.Altura))
                .ForMember(x => x.Profundidade, m => m.MapFrom(e => e.Dimensoes.Profundidade));
            CreateMap<Categoria, CategoriaViewModel>();
        }
    }
}
