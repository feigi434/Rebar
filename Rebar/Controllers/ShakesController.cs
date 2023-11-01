using Microsoft.AspNetCore.Mvc;
using Rebar.Models;
using Rebar.Services;

namespace Rebar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShakesController : ControllerBase
    {
        private readonly IShakeService shakeService;
        public ShakesController(IShakeService shakeService)
        {
            this.shakeService = shakeService;
        }

        // GET: api/<ShakesController>
        [HttpGet]
        public ActionResult<List<Shake>> Get()
        {
            return shakeService.Get();
        }

        // GET api/<ShakesController>/5
        [HttpGet("{id}")]
        public ActionResult<Shake> Get(Guid id)
        {
            var shake = shakeService.Get(id);

            if (shake == null)
            {
                return NotFound($"Shake with id = {id} not found");
            }

            return shake;
        }

        // POST api/<ShakesController>
        [HttpPost]
        public ActionResult<Shake> Post([FromBody] Shake shake)
        {
            if(!shake.Name.All(char.IsLetter) || shake.Name == "")
                return BadRequest("Shake name is invalid!");
            if (shake.Description == "")
                return BadRequest("shake description is invalid!");
           
            shakeService.Create(shake);

            return CreatedAtAction(nameof(Get), new { id = shake.Id }, shake);
        }

        // PUT api/<ShakesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Shake shake)
        {
            var existingShake = shakeService.Get(id);

            if (existingShake == null)
            {
                return NotFound($"Shake with id = {id} not found");
            }

            shakeService.Update(id, shake);

            return NoContent();
        }

        // DELETE api/<ShakesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var shake = shakeService.Get(id);

            if (shake == null)
            {
                return NotFound($"Shake with id = {id} not found");
            }

            shakeService.Remove(shake.Id);

            return Ok($"Shake with id = {id} deleted");
        }
    }
}
