using AutoMapper;
using Vega_API.Entities;
using Vega_API.Model.Response;

namespace Vega_API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<VegaMake, VegaMakeResponse>().ReverseMap();
            CreateMap<VegaModel, VegaModelResponse>().ReverseMap();
            CreateMap<VegaFeature, VegaFeatureResponse>().ReverseMap();
        }
    }
}
