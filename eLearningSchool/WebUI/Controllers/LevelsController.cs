using System.Threading.Tasks;
using Application.Levels.Commands.DeleteLevel;
using Application.Levels.Commands.UpsertLevel;
using Application.Levels.Queries.GetLevelsList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class LevelsController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<LevelsListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetLevelsListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertLevelCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLevelCommand() { Id = id });

            return NoContent();
        }
    }
}