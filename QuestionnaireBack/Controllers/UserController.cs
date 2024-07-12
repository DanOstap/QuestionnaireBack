using Microsoft.AspNetCore.Mvc;
using QuestionnaireBack.Models;
using QuestionnaireBack.Service;

namespace QuestionnaireBack.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUsers service;
        public UserController(IUsers service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {

            return Ok(await service.FindAll());
        }
        [HttpPost]
        public async Task<ActionResult<Users>> AddUser([FromBody] Users _model) {
            var user = await service.Create(_model);
            return Ok(user);
        }
        [HttpGet("/byName")]
        public async Task<IActionResult> GetByName(string name) {
            return Ok(await service.FindOneByName(name));
        }
    }
}
