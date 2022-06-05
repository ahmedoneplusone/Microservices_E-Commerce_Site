using MediatR;
using Ordering.Application.Mapper;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handlers
{
    public class GetOrdersByCountryHandler : IRequestHandler<GetOrdersByCountryQuery, IEnumerable<OrderResponses>>
    {
        private readonly IOrderRepo _repo;
            public GetOrdersByCountryHandler(IOrderRepo Repo)
        {
            _repo = Repo;
        }
        public async Task<IEnumerable<OrderResponses>> Handle(GetOrdersByCountryQuery request, CancellationToken cancellationToken)
        {
            var OrdersList = await _repo.GetOrdersByCountry(request.Country);
            var orderResponsesList = OrderMapper.Mapper.Map<IEnumerable<OrderResponses>>(OrdersList);
            return orderResponsesList;
        }
    }
}
