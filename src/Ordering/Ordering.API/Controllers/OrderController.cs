using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [Route("[action]/{userName}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponses>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponses>>> GetOrderByUserName(string userName)
        {
            var query = new GetOrderByUserNameQuery(userName);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [Route("[action]/{country}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderResponses>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponses>>> GetOrderByCountry(string country)
        {
            var query = new GetOrdersByCountryQuery(country);
            var orders = await _mediator.Send(query);
            return Ok(orders);
        }

        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<OrderResponses>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderResponses>> CheckoutOrder([FromBody] CheckoutOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
