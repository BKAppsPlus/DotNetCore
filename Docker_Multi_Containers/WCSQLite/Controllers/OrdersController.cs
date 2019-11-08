using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WCSQLite.DAL;
using WCSQLite.Entities;

namespace WCSQLite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>  
        /// The orders database context  
        /// </summary>  
        private readonly SQLiteContext _ordersDbContext;

        /// <summary>  
        /// Initializes a new instance of the <see cref="OrdersController"/> class.  
        /// </summary>  
        /// <param name="ordersDbContext">The orders database context.</param>  
        public OrdersController(SQLiteContext ordersDbContext)
        {
            this._ordersDbContext = ordersDbContext;
        }

        //GET: api/Orders  
        /// <summary>  
        /// Gets the order.  
        /// </summary>  
        /// <returns>Task<ActionResult<IEnumerable<Order>>>.</returns>  
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return Ok(await _ordersDbContext.Orders.ToListAsync());
        }

        // GET: api/Orders/5  
        /// <summary>  
        /// Gets the order.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns>Task<ActionResult<Order>>.</returns>  
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _ordersDbContext.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/Orders/5  
        /// <summary>  
        /// Puts the order.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <param name="order">The order.</param>  
        /// <returns>Task<IActionResult>.</returns>  
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _ordersDbContext.Entry(order).State = EntityState.Modified;

            try
            {
                await _ordersDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IsOrderExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/Orders  
        /// <summary>  
        /// Posts the order.  
        /// </summary>  
        /// <param name="order">The order.</param>  
        /// <returns>Task<ActionResult<Order>>.</returns>  
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _ordersDbContext.Orders.Add(order);
            await _ordersDbContext.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Orders/5  
        /// <summary>  
        /// Deletes the order.  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns>Task<ActionResult<Order>>.</returns>  
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _ordersDbContext.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _ordersDbContext.Orders.Remove(order);
            await _ordersDbContext.SaveChangesAsync();

            return Ok(order);
        }

        /// <summary>  
        /// Determines whether [is order exists] [the specified identifier].  
        /// </summary>  
        /// <param name="id">The identifier.</param>  
        /// <returns><c>true</c> if [is order exists] [the specified identifier]; otherwise, <c>false</c>.</returns>  
        private bool IsOrderExists(int id)
        {
            return _ordersDbContext.Orders.Any(e => e.OrderId == id);
        }
    }
}