using AssessmentTask.Common;
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
    public class CandidateController : ControllerBase
    {
        private readonly IRepository<PersonalInfo> _personalInfoRepo;
        private readonly IRepository<QuestionTemplateRequest> _questionTemplateRepo;
        private readonly IRepository<CustomQuestion> _questionRepo;
        private readonly IRepository<ProgramModel> _programRepo;
        private readonly IRepository<ProgramApplicationForm> _programApplicationRepo;
        private readonly IMapper _mapper;
        public CandidateController(IRepository<PersonalInfo> personalInfoRepo, IRepository<QuestionTemplateRequest> questionTemplateRepo, 
            IRepository<CustomQuestion> questionRepo, IRepository<ProgramModel> programRepo, 
            IRepository<ProgramApplicationForm> programApplicationRepo, IMapper mapper)
        {
            _personalInfoRepo = personalInfoRepo;
            _questionTemplateRepo = questionTemplateRepo;
            _questionRepo = questionRepo;
            _programRepo = programRepo;
            _programApplicationRepo = programApplicationRepo;
            _mapper = mapper;
        }
        // GET api/items
        [HttpGet("application-form")]
        public async Task<IActionResult> GetApplicationForm()
        {
            var application = await _programRepo.GetByQueryAsync("SELECT * FROM c").FirstOrDefaultAsync();
            application.PersonalInfos = await _personalInfoRepo.GetByQueryAsync("SELECT * FROM c where c.isHidden = false").ToListAsync();
            application.CustomQuestions = await _questionRepo.GetByQueryAsync("SELECT * FROM c").ToListAsync();
            return Ok(_mapper.Map<ProgramModelDTO>(application));
        }

       
        [HttpPost("apply")]
        public async Task<IActionResult> CreateApplicationForm([FromBody] ProgramApplicationFormDTO item)
        {

            await _programApplicationRepo.CreateAsync(_mapper.Map<ProgramApplicationForm>(item));

            return Created();
        }

    }
}
