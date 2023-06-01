using AutoMapper;
using EventBusRabbitMQ.Events;
using Ordering.Application.Commands.OrderCreate;

namespace ESourcing.Orders.Mapping
{
    public class OrderMapping : Profile
    {
        public OrderMapping() {
            CreateMap<OrderCreateEvent, OrderCreateCommand>().ReverseMap() ;
        }
    }
}
