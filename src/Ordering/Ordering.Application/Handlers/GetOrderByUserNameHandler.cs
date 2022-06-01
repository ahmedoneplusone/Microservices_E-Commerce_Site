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
    public class GetOrderByUserNameHandler : IRequestHandler<GetOrderByUserNameQuery,IEnumerable<OrderResponses>>
    {
        private readonly IOrderRepo _repo;

        public GetOrderByUserNameHandler(IOrderRepo repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public async Task<IEnumerable<OrderResponses>> Handle(GetOrderByUserNameQuery request, CancellationToken cancellationToken)
        {
            var orderList = await _repo.GetOrdersByUserName(request.UserName);
            var orderResponseList = OrderMapper.Mapper.Map<IEnumerable<OrderResponses>>(orderList);
            return orderResponseList;
        }
    }
}
