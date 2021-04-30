using System.Threading.Tasks;
using Application.StudentCourseStatuses.Commands.DeleteStudentCourseStatus;
using Application.StudentCourseStatuses.Commands.UpsertStudentCourseStatus;
using Application.StudentCourseStatuses.Queries.GetStudentCourseStatusesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize]
    public class StudentCourseStatusesController : BaseController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<StudentCourseStatusesListVm>> GetAll()
        {
            return Ok(await Mediator.Send(new GetStudentCourseStatusesListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Upsert(UpsertStudentCourseStatusCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteStudentCourseStatusCommand() { Id = id });

            return NoContent();
        }
    }
}