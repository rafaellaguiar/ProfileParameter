using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Service.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController(IProfileParameterService profileParameterService) : ControllerBase
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todos os perfis e seus parâmetros.")]
        public IActionResult ListProfiles()
        {
            try
            {
                return Ok(profileParameterService.ListProfiles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{profileName}")]
        [SwaggerOperation(Summary = "Retorna os parâmetros de um perfil especifico.")]
        public IActionResult GetProfileByName(string profileName)
        {
            try
            {
                return Ok(profileParameterService.GetProfile(profileName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Adiciona um novo perfil com seus parâmetros.")]
        public IActionResult AddProfile([FromBody] ProfileParameter profileParameter)
        {
            try
            {
                return Ok(profileParameterService.AddProfile(profileParameter));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{profileName}")]
        [SwaggerOperation(Summary = "Atualiza os parametros de um perfil existente")]
        public IActionResult UpdateProfile([FromBody] Dictionary<string, bool> profileParameter, string profileName)
        {
            try
            {
                return Ok(profileParameterService.UpdateProfile(profileName, profileParameter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{profileName}")]
        [SwaggerOperation(Summary = "Remove um perfil")]
        public IActionResult DeleteProfile(string profileName)
        {
            try
            {
                return Ok(profileParameterService.DeleteProfile(profileName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{profileName}/validate/{parameterName}")]
        [SwaggerOperation(Summary = "Valida se um perfil tem permissão para uma ação especifica.")]
        public IActionResult ValidateProfile(string profileName, string parameterName)
        {
            try
            {
                return Ok(profileParameterService.ValidatePerfil(profileName, parameterName));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
