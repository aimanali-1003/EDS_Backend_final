using AutoMapper;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<CategoryViewModel, Category>();

        CreateMap<CategoryViewModel, Category>()
            .ForMember(dest => dest.CategoryID, opt => opt.Ignore()) // Assuming you want to ignore CategoryID
            .ReverseMap();

        // Assuming you have an OrgViewModel and Org model
        CreateMap<OrgVM, Org>()
            .ForMember(dest => dest.OrganizationID, opt => opt.Ignore()) // Assuming you want to ignore OrganizationID
            .ReverseMap();

        CreateMap<ClientViewModel, Client>()
           .ForMember(dest => dest.ClientID, opt => opt.Ignore()) // Assuming you want to ignore ClientID
           .ReverseMap();

        CreateMap<ColumnViewModel, Columns>()
           .ForMember(dest => dest.ColumnsID, opt => opt.Ignore()) // Assuming you want to ignore ColumnID
           .ReverseMap();

        CreateMap<TemplateViewModel, Template>()
          .ForMember(dest => dest.TemplateID, opt => opt.Ignore()) // Assuming you want to ignore ColumnID
          .ReverseMap();
        CreateMap<UpdateTemplateVM, Template>()
         .ForMember(dest => dest.TemplateID, opt => opt.Ignore()) // Assuming you want to ignore ColumnID
         .ReverseMap();

        CreateMap<UpdateClientVM, Client>()
         .ForMember(dest => dest.ClientID, opt => opt.Ignore()) // Assuming you want to ignore ColumnID
         .ReverseMap(); 
         
    }
}
