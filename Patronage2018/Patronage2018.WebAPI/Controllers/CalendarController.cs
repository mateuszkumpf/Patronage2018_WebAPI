using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Patronage2018.Application.Calendars.Commands.CreateCalendar;
using Patronage2018.Application.Calendars.Commands.DeleteCalendar;
using Patronage2018.Application.Calendars.Commands.UpdateCalendar;
using Patronage2018.Application.Calendars.Queries.GetAllCalendars;
using Patronage2018.Application.Calendars.Queries.GetRoomsCalendar;
using Patronage2018.Application.Calendars.Queries.Models;

namespace Patronage2018.WebAPI.Controllers
{
    public class CalendarController : BaseController
    {
        /// <summary>
        /// Get all calendars
        /// </summary>
        /// <remarks>
        /// Return list of calendars
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CalendarsListViewModel), 200)]
        [HttpGet]
        public async Task<ActionResult<CalendarsListViewModel>> GetAllCalendars()
        {
            return Ok(await Mediator.Send(new GetAllCalendarsQuery()));
        }

        /// <summary>
        /// Get calendars for room
        /// </summary>
        /// <remarks>
        /// Return list of calendars for specific room
        /// </remarks>
        /// /// <param name="id">
        /// Room ID
        /// </param>
        /// <response code="200">
        /// Successful operation
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(CalendarsListViewModel), 200)]
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarsListViewModel>> GetRoomsCalendar([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetRoomsCalendarQuery { Id = id }));
        }

        /// <summary>
        /// Create new calendar
        /// </summary>
        /// <remarks>
        /// Create new calendar
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), 200)]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]CreateCalendarCommand room)
        {
            var roomId = await Mediator.Send(room);

            return Ok(roomId);
        }

        /// <summary>
        /// Update calendar
        /// </summary>
        /// <remarks>
        /// Update room
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateCalendarCommand room)
        {
            return Ok(await Mediator.Send(room));
        }

        /// <summary>
        /// Delete calendar
        /// </summary>
        /// <remarks>
        /// Delete calendar with specific ID
        /// </remarks>
        /// <param name="id">
        /// Calendar ID
        /// </param>
        /// <response code="204">
        /// Successful operation
        /// </response>
        [ProducesResponseType(204)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteCalendarCommand() { Id = id });

            return Ok();
        }
    }
}