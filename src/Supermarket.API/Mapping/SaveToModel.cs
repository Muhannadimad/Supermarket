using AutoMapper;
using Supermarket.API.Domain.Models;
using Supermarket.API.Resources;

namespace Supermarket.API.Mapping
{
    public class SaveToModel : Profile
    {
        public SaveToModel()
        {
            CreateMap<SaveCategoryResource, Category>();
        }
    }
}