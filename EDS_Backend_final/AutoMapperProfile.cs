using AutoMapper;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        //CreateMap<CategoryViewModel, Category>();

        CreateMap<CategoryViewModel, Category>()
            .ForMember(dest => dest.CategoryID, opt => opt.Ignore()) // Assuming you want to ignore CategoryID
            .ReverseMap();
        // Add other mappings as needed
    }
}
