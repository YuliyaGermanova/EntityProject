using EntityProject.DAL.Entities;
using EntityProject.Exceptions;
using EntityProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace EntityProject.Controllers
{
    /// <summary>
    /// Контроллер для управления сущностями.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityService _entityService;

        public EntityController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpPost]
        [Route("Insert")]
        public async Task<ActionResult> InsertAsync([FromBody] Entity entity)
        {
            try
            {
                await _entityService.InsertAsync(entity);

                return Ok();
            }
            catch (CastomException castomException)
            {
                return BadRequest(castomException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<string>> GetById(Guid id)
        {
            try
            {
                var result = await _entityService.GetByIdAsync(id);

                return result;
            }
            catch (CastomException castomException)
            {
                if (castomException.ExceptionType == CastomExceptionTypes.NotFoundException)
                {
                    return NotFound(castomException.Message);
                }

                return BadRequest(castomException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
