using AssessmentTask.Common;
using AssessmentTask.DTO;
using AssessmentTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;

namespace AssessmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionTemplateController : ControllerBase
    {
        private readonly IRepository<QuestionTemplateRequest> _questionTemplateRepo;
        public QuestionTemplateController(IRepository<QuestionTemplateRequest> questionTemplateRepo)
        {
            _questionTemplateRepo = questionTemplateRepo;
        }
        // GET api/items
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _questionTemplateRepo.GetByQueryAsync("SELECT * FROM c"));
        }


        // GET api/items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _questionTemplateRepo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstAsync());
        }
        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionTemplateRequest item)
        {
            await _questionTemplateRepo.CreateAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        // PUT api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] QuestionTemplateRequest item)
        {
            await _questionTemplateRepo.UpdateAsync(item);
            return NoContent();
        }
        // DELETE api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _questionTemplateRepo.DeleteAsync(id);
            return NoContent();
        }
    }
}
