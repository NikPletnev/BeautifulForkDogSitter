using AutoMapper;
using DogSitter.API.Attribute;
using DogSitter.API.Extensions;
using DogSitter.API.Models;
using DogSitter.API.Models.InputModels;
using DogSitter.BLL.Models;
using DogSitter.BLL.Services;
using DogSitter.DAL.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DogSitter.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SittersController : Controller
    {
        private readonly ISitterService _service;
        private readonly IMapper _mapper;

        public SittersController(ISitterService sitterService, IMapper mapper)
        {
            _service = sitterService;
            _mapper = mapper;
        }

        //api/sitters
        [AuthorizeRole(Role.Admin, Role.Customer)]
        [HttpGet("{id}")]
        public ActionResult<SitterOutputModel> GetSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitter = _service.GetById(id);
            var sitterModel = _mapper.Map<SitterOutputModel>(sitter);
            return Ok(sitterModel);
        }

        [HttpGet]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        public ActionResult<List<SitterOutputModel>> GetAllSitters()
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitters = _service.GetAll();
            var sittersModel = _mapper.Map<List<SitterOutputModel>>(sitters);
            return Ok(sittersModel);
        }

        [HttpPost]
        public ActionResult AddSitter([FromBody] SitterInsertInputModel sittetModel)
        {
            var sitter = _mapper.Map<SitterModel>(sittetModel);
            _service.Add(sitter);
            return StatusCode(StatusCodes.Status201Created, sitter);
        }

        [HttpPut("{id}")]
        [AuthorizeRole(Role.Sitter)]
        public ActionResult UpdateSitter([FromBody] SitterUpdateInputModel sitterModel)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitter = _mapper.Map<SitterModel>(sitterModel);
            _service.Update(userId.Value, sitter);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [AuthorizeRole(Role.Admin, Role.Sitter)]
        public ActionResult DeleteSitter(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.DeleteById(userId.Value, id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        [AuthorizeRole(Role.Admin)]
        public ActionResult RestoreSitter(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.Restore(id);
            return Ok();
        }

        [HttpPatch("confirm/{id}")]
        [AuthorizeRole(Role.Admin)]
        public ActionResult ConfirmProfileSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.ConfirmProfileSitterById(id);
            return Ok();
        }

        [HttpPatch("block/{id}")]
        [AuthorizeRole(Role.Admin)]
        public ActionResult BlockProfileSitterById(int id)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            _service.BlockProfileSitterById(id);
            return Ok();
        }

        [HttpGet("subwaystation/{id}")]
        [AuthorizeRole(Role.Admin, Role.Customer)]
        public ActionResult<List<SitterOutputModel>> GetAllSittersWithWorkTimeBySubwayStation([FromBody] SubwayStationInputModel subwayStation)
        {
            var userId = this.GetUserId();
            if (userId == null)
            {
                return Unauthorized("Invalid token, please try again");
            }

            var sitters = _service.GetAllSittersWithWorkTimeBySubwayStation(_mapper.Map<SubwayStationModel>(subwayStation));
            var sittersModel = _mapper.Map<SitterOutputModel>(sitters);
            return Ok(sittersModel);
        }
    }
}
