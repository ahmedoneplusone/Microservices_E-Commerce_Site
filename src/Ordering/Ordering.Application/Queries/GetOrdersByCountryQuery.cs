using MediatR;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Queries
{
    public class GetOrdersByCountryQuery: IRequest<IEnumerable<OrderResponses>>
    {
        public string Country { get; set; }
        public GetOrdersByCountryQuery(string country)
        {
            Country = country
?? throw new ArgumentNullException(nameof(country));   
}
    }
}
