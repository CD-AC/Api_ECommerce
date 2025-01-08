using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api_ECommerce.Core.Entities;
using Api_ECommerce.Core.Interfaces;

namespace Api_ECommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemsController(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAll()
        {
            var orderItems = await _orderItemRepository.GetAllAsync();
            return Ok(orderItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetById(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
                return NotFound();

            return Ok(orderItem);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] OrderItem orderItem)
        {
            await _orderItemRepository.AddAsync(orderItem);
            return CreatedAtAction(nameof(GetById), new { id = orderItem.Id }, orderItem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] OrderItem orderItem)
        {
            if (id != orderItem.Id)
                return BadRequest("El ID del ítem de pedido no coincide con el ID de la solicitud.");

            var existingItem = await _orderItemRepository.GetByIdAsync(id);
            if (existingItem == null)
                return NotFound();

            existingItem.Cantidad = orderItem.Cantidad;
            existingItem.PrecioUnitario = orderItem.PrecioUnitario;
            existingItem.SubTotal = orderItem.SubTotal;
            existingItem.OrderId = orderItem.OrderId;
            existingItem.ProductId = orderItem.ProductId;

            await _orderItemRepository.UpdateAsync(existingItem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var orderItem = await _orderItemRepository.GetByIdAsync(id);
            if (orderItem == null)
                return NotFound();

            await _orderItemRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
