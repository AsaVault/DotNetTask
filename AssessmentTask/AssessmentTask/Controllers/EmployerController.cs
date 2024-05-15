using AssessmentTask.Common;
using AssessmentTask.DTO;
using AssessmentTask.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.CosmosRepository.Extensions;

namespace AssessmentTask.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IRepository<PersonalInfo> _personalInfoRepo;
        private readonly IRepository<QuestionTemplateRequest> _questionTemplateRepo;
        private readonly IRepository<CustomQuestion> _questionRepo;
        private readonly IRepository<ProgramModel> _programRepo;
        private readonly IMapper _mapper;
        public EmployerController(IRepository<PersonalInfo> personalInfoRepo, 
            IRepository<QuestionTemplateRequest> questionTemplateRepo, IRepository<CustomQuestion> questionRepo, 
            IRepository<ProgramModel> programRepo, IMapper mapper)
        {
            _personalInfoRepo = personalInfoRepo;
            _questionTemplateRepo = questionTemplateRepo;
            _questionRepo = questionRepo;
            _programRepo = programRepo;
            _mapper = mapper;
        }
        // GET api/items
        [HttpGet("application-form")]
        public async Task<IActionResult> GetApplicationForm()
        {
            var application = new ProgramModel();
            application.PersonalInfos = await _personalInfoRepo.GetByQueryAsync("SELECT * FROM c where c.isMandated = true").ToListAsync();
            application.CustomQuestions = await _questionRepo.GetByQueryAsync("SELECT * FROM c").ToListAsync();
            return Ok(_mapper.Map<ProgramModelDTO>(application));
        }


        // GET api/items/5
        [HttpGet("question-types")]
        public async Task<IActionResult> GetQuestionTypes()
        {
            return Ok(await _questionTemplateRepo.GetByQueryAsync($"SELECT * FROM c"));
        }

        [HttpGet("question-type-response/{id}")]
        public async Task<IActionResult> GetQuestionTypeResponse(string id)
        {
            var questionType = await _questionTemplateRepo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstOrDefaultAsync();
            var questionResponse = new QuestionTemplateResponse();

            if(questionType != null)
            {
                questionResponse = Mapping.MapQuestion(questionType);
            }

            return Ok(questionResponse);
        }

        [HttpGet("questions")]
        public async Task<IActionResult> GetQuestions()
        {
            var question = await _questionRepo.GetByQueryAsync($"SELECT * FROM c");

            return Ok(question);
        }

        [HttpGet("question/{id}")]
        public async Task<IActionResult> GetQuestion(string id)
        {
            var question = await _questionRepo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstOrDefaultAsync();
            
            return Ok(question);
        }

        [HttpPost("question")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionTemplateResponse item)
        {
            var question = Mapping.MapPersonalInfo(item);
            await _questionRepo.CreateAsync(question);

            return Created();
        }

        [HttpPut("question/{id}")]
        public async Task<IActionResult> Edit([FromRoute] string id, [FromBody] CustomQuestion item)
        {
            var question = await _questionRepo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstOrDefaultAsync();

            if( question == null )
            {
                return NotFound();
            }

            if( !item.Id.Equals( id ))
            {
                return BadRequest();
            }

            await _questionRepo.UpdateAsync(item);
            return NoContent();
        }

        // DELETE api/items/5
        [HttpDelete("question/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var question = await _questionRepo.GetByQueryAsync($"SELECT * FROM c where c.id = '{id}'").FirstOrDefaultAsync();

            if (question == null)
            {
                return NotFound();
            }
            
            await _questionRepo.DeleteAsync(id);
            return NoContent();
        }

        // POST api/items
        [HttpPost("program")]
        public async Task<IActionResult> CreateProgram([FromBody] ProgramModel item)
        {
            await _programRepo.CreateAsync(item);
            return Created();
        }
        
    }
}
