using Microsoft.AspNetCore.Mvc;
using Patronage2018.Application.Rooms.Commands.CreateRoom;
using Patronage2018.Application.Rooms.Commands.UpdateRoom;
using Patronage2018.Application.Rooms.Queries.GetAllRooms;
using System.Threading.Tasks;
using Patronage2018.Application.Rooms.Queries.GetRoom;
using Patronage2018.Application.Rooms.Commands.DeleteRoom;
using Patronage2018.WebAPI.Middleware.Models;

namespace Patronage2018.WebAPI.Controllers
{

    public class RoomController : BaseController
    {
        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <remarks>
        /// Return list of rooms
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        /// <response code="500">
        /// Internal error
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(RoomsListViewModel), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        [HttpGet]
        public async Task<ActionResult<RoomsListViewModel>> GetAllRooms()
        {
            return Ok(await Mediator.Send(new GetAllRoomsQuery()));
        }

        /// <summary>
        /// Get detail about room
        /// </summary>
        /// <remarks>
        /// Return detail of room with ID from parameter
        /// </remarks>
        /// <param name="id">
        /// Room ID
        /// </param>
        /// <response code="200">
        /// Successful operation
        /// </response>
        /// <response code="404">
        /// Not found
        /// </response>
        /// <response code="500">
        /// Internal error
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(RoomDetailModel), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailModel>> GetRoom([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new GetRoomQuery { Id = id }));
        }

        /// <summary>
        /// Create new room
        /// </summary>
        /// <remarks>
        /// Create new room
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        /// <response code="500">
        /// Internal error
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]CreateRoomCommand room)
        {
            var roomId = await Mediator.Send(room);

            return Ok(roomId);
        }

        /// <summary>
        /// Update room
        /// </summary>
        /// <remarks>
        /// Update room
        /// </remarks>
        /// <response code="200">
        /// Successful operation
        /// </response>
        /// <response code="404">
        /// Not found
        /// </response>
        /// <response code="500">
        /// Internal error
        /// </response>
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateRoomCommand room)
        {
            return Ok(await Mediator.Send(room));
        }

        /// <summary>
        /// Delete room
        /// </summary>
        /// <remarks>
        /// Delete room with ID from parameter
        /// </remarks>
        /// <param name="id">
        /// Room ID
        /// </param>
        /// <response code="204">
        /// Successful operation
        /// </response>
        /// <response code="404">
        /// Not found
        /// </response>
        /// <response code="500">
        /// Internal error
        /// </response>
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorDetails), 404)]
        [ProducesResponseType(typeof(ErrorDetails), 500)]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            await Mediator.Send(new DeleteRoomCommand() { Id = id });

            return Ok();
        }
    }
}