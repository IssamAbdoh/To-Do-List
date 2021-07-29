using AutoMapper;
using To_Do_Lists.Data.Entities;
using To_Do_Lists.Models;

namespace To_Do_Lists.Data
{
    public class ItemProfile :Profile
    {
        public ItemProfile()
        {
            this.CreateMap<Item, ItemsModel>()
                .ReverseMap();
        }
    }
}