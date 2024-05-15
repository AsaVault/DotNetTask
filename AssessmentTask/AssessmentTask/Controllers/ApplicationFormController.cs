using AssessmentTask.DTO;
using AssessmentTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;

namespace AssessmentTask.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IRepository<ProgramApplicationForm> _repo;
        private readonly IMapper _mapper;
        public ApplicationFormController(IRepository<ProgramApplicationForm> repo , IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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
            var result = await _repo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstOrDefaultAsync();
            return Ok(_mapper.Map<ProgramApplicationFormDTO>(result));
        }
        // POST api/items
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProgramApplicationFormDTO item)
        {
            item.Id = Guid.NewGuid().ToString();
            await _repo.CreateAsync(_mapper.Map<ProgramApplicationForm>(item));
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }
        // PUT api/items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromBody] ProgramApplicationFormDTO item)
        {
            var enity = _mapper.Map<ProgramApplicationForm>(item);
            await _repo.UpdateAsync(enity);
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
