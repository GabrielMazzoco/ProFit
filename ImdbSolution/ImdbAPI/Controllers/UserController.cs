using IronFit.Domain.AuthAggregate.Dtos;
using IronFit.Domain.AuthAggregate.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IronFit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Registra um usuario no Sistema
        /// </summary>
        /// <response code="201"></response>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult RegisterUser([FromBody] UserForRegisterDto userForRegisterDto)
        {
            var admin = VerificarAdmin();

            if (!admin) return Forbid();

            _userService.RegisterUser(userForRegisterDto);

            return Created($"{nameof(UserController)}", new {});
        }

        /// <summary>
        /// Atualiza o usuario no Sistema
        /// </summary>
        /// <response code="200"></response>
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserForUpdateDto userForUpdateDto)
        {
            _userService.UpdateUser(userForUpdateDto);

            return Ok();
        }

        /// <summary>
        /// Desativa o usuario logado.
        /// </summary>
        /// <response code="200"></response>
        [HttpDelete("inativar")]
        public IActionResult InactivateUser()
        {
            _userService.InactivateUser();

            return Ok();
        }

        private bool VerificarAdmin()
        {
            var admin = bool.Parse(User.FindFirst("Admin").Value);

            return admin;
        }
    }
}
