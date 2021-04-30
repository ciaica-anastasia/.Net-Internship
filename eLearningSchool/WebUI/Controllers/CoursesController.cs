using System.Threading.Tasks;
using Application.Courses.Commands.CreateCourse;
using Application.Courses.Commands.DeleteCourse;
using Application.Courses.Commands.UpdateCourse;
using Application.Courses.Queries.GetCourseDetail;
using Application.Courses.Queries.GetCoursesList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Authorize] //role(Roles = )
    public class CoursesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CoursesListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetCoursesListQuery());

            return Ok(vm);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CourseDetailVm>> Get(string id)
        {
            var vm = await Mediator.Send(new GetCourseDetailQuery() { Id = id });

            return Ok(vm);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody]CreateCourseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateCourseCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteCourseCommand() { Id = id });

            return NoContent();
        }
    }
}