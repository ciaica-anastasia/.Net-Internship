using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Teachers.Commands.CreateTeacher;
using Application.Teachers.Commands.DeleteTeacher;
using Application.Teachers.Commands.UpdateTeacher;
using Application.Teachers.Queries.GetTeacherDetail;
using Application.Teachers.Queries.GetTeachersList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TeachersController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IList<TeacherLookupDto>>> GetAll()
        {
            return Ok(await Mediator.Send(new GetTeachersListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeacherDetailVm>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTeacherDetailQuery() {Id = id}));
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateTeacherCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateTeacherCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTeacherCommand() {Id = id});

            return NoContent();
        }
    }
}