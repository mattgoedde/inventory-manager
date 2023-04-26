using AutoMapper;
using Inventory.Domain.DataTransferObjects;
using Inventory.Domain.Entities;

namespace Inventory.Logic;
internal class AutomapperProfile : Profile
{
	public AutomapperProfile()
	{
		CreateMap<ItemEntity, ItemDto>().ReverseMap();
		CreateMap<TrackedItemEntity, TrackedItemDto>().ReverseMap();
		CreateMap<UntrackedItemEntity, UntrackedItemDto>().ReverseMap();
		CreateMap<LocationEntity, LocationDto>().ReverseMap();
		CreateMap<LocationTypeEntity, LocationTypeDto>().ReverseMap();
		CreateMap<TenantEntity, TenantDto>().ReverseMap();
		CreateMap<TagEntity, TagDto>().ReverseMap();
	}
}
