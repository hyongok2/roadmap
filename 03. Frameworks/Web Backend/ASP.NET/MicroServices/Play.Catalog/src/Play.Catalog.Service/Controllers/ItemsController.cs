using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Paly.Catalog.Service.Dtos;
using Paly.Catalog.Service.Entities;
using Play.Catalog.Contracts;
using Play.Common;

namespace Paly.Catalog.Service.Contollers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IRepository<Item> itemsRepository;
        private readonly IPublishEndpoint publishEndPoint;
        public ItemsController(IRepository<Item> itemsRepository, IPublishEndpoint publishEndPoint)
        {
            this.itemsRepository = itemsRepository;
            this.publishEndPoint = publishEndPoint;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetAsync()
        {
            var items = (await itemsRepository.GetAllAsync())
            .Select(item => item.AsDto());

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetByIdAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostAsync(CreateItemDto createItemDto)
        {
            var item = new Item
            {
                Name = createItemDto.Name,
                Description = createItemDto.Description,
                Price = createItemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };

            await itemsRepository.CreateAsync(item);

            await publishEndPoint.Publish(new CatalogItemCreated(item.Id, item.Name, item.Description));

            return CreatedAtAction(nameof(GetByIdAsync), new
            {
                id = item.Id
            }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateItemDto updateItemDto)
        {
            var existingItem = await itemsRepository.GetAsync(id);

            if (existingItem == null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDto.Name;
            existingItem.Description = updateItemDto.Description;
            existingItem.Price = updateItemDto.Price;

            await itemsRepository.UpdateAsync(existingItem);

            await publishEndPoint.Publish(new CatalogItemUpdated(existingItem.Id, existingItem.Name, existingItem.Description));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var item = await itemsRepository.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            await itemsRepository.RemoveAsync(id);

            await publishEndPoint.Publish(new CatalogItemDeleted(id));

            return NoContent();
        }
    }
}