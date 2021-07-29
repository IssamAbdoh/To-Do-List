using AutoMapper;
using To_Do_Lists.Data.Entities;
using To_Do_Lists.Models;

namespace To_Do_Lists.Data
{
    public class ListOfListsProfile : Profile
    {
        public ListOfListsProfile()
        {
            this.CreateMap<ListOfLists, ListOfListsModel>()
                .ReverseMap();
        }
    }
}