﻿using AssessmentTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;

namespace AssessmentTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionResponseController : ControllerBase
    {
        private readonly IRepository<QuestionTemplateResponse> _repo;
        public QuestionResponseController(IRepository<QuestionTemplateResponse> repo)
        {
            _repo = repo;
        }
        // GET api/items
        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await _repo.GetByQueryAsync("SELECT * FROM c"));
        }


        // GET api/items/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _repo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstAsync());
        }
        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] QuestionTemplateResponse item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _repo.CreateAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        // PUT api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] QuestionTemplateResponse item)
        {
            await _repo.UpdateAsync(item);
            return NoContent();
        }
        // DELETE api/items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }
    }
}
