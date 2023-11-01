using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return orderService.Get();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(Guid id)
        {
            var order = orderService.Get(id);

            if(order == null)
            {
                return NotFound($"Order with id = {id} not found");
            }

            return order;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public ActionResult<Order> Post([FromBody] Order order)
        {
            if (order.Shakes == null || order.CustomerName == null || order.Discounts == null)
                return BadRequest("All properties are required!");
            else if (order.Shakes.Count() > 10 || order.Shakes.Count() < 0)
                return BadRequest("Shakes list invalid!");
            else if (!order.CustomerName.All(char.IsLetter))
                return BadRequest("Customer name invalid!");
            else
                foreach (var shake in order.Shakes) 
                    order.Sum += shake.price;
            order.Date = DateTime.Now;


            orderService.Create(order);
            return Ok($"Order with id = {order.Id} created successfully");
        }


        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Order order)
        {
            var existingOrder = orderService.Get(id);

            if(existingOrder == null)
            {
                return NotFound($"Order with id = {id} not found");
            }

            orderService.Update(id, order);

            return NoContent();
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var order = orderService.Get(id);

            if (order == null)
            {
                return NotFound($"Order with id = {id} not found");
            }

            orderService.Remove(order.Id);

            return Ok($"Order with id = {id} deleted");
        }

         
    }
}
