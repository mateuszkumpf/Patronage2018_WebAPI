using Microsoft.AspNetCore.Mvc;
using Patronage2018.Application.Abracadabra.Queries;
using Patronage2018.Application.FizzBuzz.Queries;
using Patronage2018.WebAPI.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Patronage2018.WebAPI.Controllers
{
    public class MainController : BaseController
    {
        /// <summary>
        /// Get Fizz, Buzz or FizzBuzz
        /// </summary>
        ///<remarks>
        /// Returns Fizz when number is divisible by 2,
        /// Buzz when number is divisible by 3 or
        /// FizzBuzz when number is divisible by both.
        /// </remarks>
        /// <param name="number">
        /// Number from 0 to 1000
        /// </param>
        /// <response code="200">
        /// Successful operation
        /// </response>
        /// <response code="201">
        /// Number is not divisible by 2 or 3.
        /// </response>
        /// <response code="400">
        /// Out of range (0-1000).
        /// </response> 
        [Produces("application/json")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(SuccessResponse), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpGet("{number}")]
        public async Task<ActionResult> FizzBuzz(int number)
        {
            var response = await Mediator.Send(new GetFizzBuzzQuery { Number = number });

            if (response.StatusCode != 400)
            {
                return StatusCode(response.StatusCode, new SuccessResponse { Result = response.Result });
            }
            else
            {
                return BadRequest(new ErrorResponse { Error = response.Error });
            }
        }


        /// <summary>
        /// Get text from external service.
        /// </summary>
        /// <response code="200">Successful operation</response>
        /// <response code="503">External service is unavaible</response>
        [Produces("application/json")]
        [ProducesResponseType(typeof(SuccessResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 503)]
        [HttpGet]
        public async Task<ActionResult> Abracadabra()
        {
            var response = await Mediator.Send(new GetAbracadabraQuery());

            if (response.IsSuccess)
            {
                return Ok(new SuccessResponse { Result = response.Result });
            }
            else
            {
                return StatusCode(503, new ErrorResponse { Error = response.Error });
            }
        }
    }
}
