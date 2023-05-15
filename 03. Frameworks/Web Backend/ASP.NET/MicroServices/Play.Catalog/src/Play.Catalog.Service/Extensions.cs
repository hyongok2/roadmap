using Paly.Catalog.Service.Dtos;
using Paly.Catalog.Service.Entities;

namespace Paly.Catalog.Service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto(item.Id, item.Name, item.Description, item.Price, item.CreatedDate);
        }
    }
}