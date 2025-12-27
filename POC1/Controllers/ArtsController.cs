using Microsoft.AspNetCore.Mvc;
using POC1.coreAPI.Delegates;
using POC1.Entities1;

namespace POC1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtController : ControllerBase
    {
        private readonly IArtDelegates artDelegates;

        public ArtController(IArtDelegates artDelegates)
        {
            this.artDelegates = artDelegates;
        }

        // GET: api/art
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await artDelegates.GetAllAsync();
            return Ok(list);
        }

        // GET: api/art/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var art = await artDelegates.GetByIdAsync(id);
            if (art == null)
                return NotFound();

            return Ok(art);
        }

        // POST: api/art
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Art model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await artDelegates.CreateAsync(model);
            return Ok(created);
        }

        // PUT: api/art/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Art model)
        {
            if (id != model.Id)
                return BadRequest("Id mismatch");

            var updated = await artDelegates.UpdateAsync(model);
            if (updated == null)
                return NotFound();

            return Ok(updated);
        }

        // DELETE: api/art/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await artDelegates.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
