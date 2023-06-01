using MediatR;
using Ordering.Application.Responses;
using System.Collections.Generic;

namespace Ordering.Application.Queries
{
    public class GetOrdersBySellerUsernameQuery : IRequest<IEnumerable<OrderResponse>>
    {
        public string Username { get; set; }

        public GetOrdersBySellerUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
