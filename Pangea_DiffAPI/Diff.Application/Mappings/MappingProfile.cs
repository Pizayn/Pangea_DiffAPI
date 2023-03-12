using AutoMapper;
using Diff.Application.Features.Diff.Commands;
using Diff.Domain.Entities;
namespace Diff.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Difference, CreateDiffCommand>().ReverseMap();

        }
    }
}
