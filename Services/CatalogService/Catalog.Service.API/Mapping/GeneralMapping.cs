using AutoMapper;
using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;

namespace Catalog.Service.API.Mapping
{
    public class GeneralMapping:Profile
    {

        public GeneralMapping()
        {
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();

            CreateMap<Course, CourseCreatedDto>().ReverseMap();
            CreateMap<Course, CourseUpdatedDto>().ReverseMap();
        }
    }
}
