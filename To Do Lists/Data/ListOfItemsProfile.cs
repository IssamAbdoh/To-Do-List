using AutoMapper;
using To_Do_Lists.Data.Entities;
using To_Do_Lists.Models;

namespace To_Do_Lists.Data
{
    public class ListOfItemsProfile : Profile
    {
        public ListOfItemsProfile()
        {
            this.CreateMap<ListOfItems, ListOfItemsModel>()
                .ReverseMap();
        }
    }
}
