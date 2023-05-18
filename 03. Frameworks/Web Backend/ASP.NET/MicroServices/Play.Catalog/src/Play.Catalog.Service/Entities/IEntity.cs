using System;

namespace Paly.Catalog.Service.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}