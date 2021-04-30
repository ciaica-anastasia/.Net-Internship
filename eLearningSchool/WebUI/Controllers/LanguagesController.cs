using System.Threading.Tasks;
using Application.Languages.Commands.DeleteLanguage;
using Application.Languages.Commands.UpsertLanguage;
using Application.Languages.Queries.GetLanguagesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class LanguagesController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<LanguagesListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetLanguagesListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertLanguageCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLanguageCommand() { Id = id });

            return NoContent();
        }
    }
}