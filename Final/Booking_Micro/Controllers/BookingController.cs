using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking_Micro.Infra;
using Booking_Micro.ViewModel;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rabbitmq_message;
using rabbitmq_message.BusConfigurations;
using Hazelcast;
using Hazelcast.Config;
using Hazelcast.Client;

namespace Booking_Micro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly IBookingDataAccess _bookingDataAccess;
        public BookingController(
          ISendEndpointProvider sendEndpointProvider, IBookingDataAccess bookingDataAccess)
        {
            _sendEndpointProvider = sendEndpointProvider;
            _bookingDataAccess = bookingDataAccess;
        }

        [HttpPost]
        [Route("createbooking")]
        public async Task<IActionResult> CreateBookingUsingStateMachineInDb([FromBody] BookingModel bookingModel)
        {
            bookingModel.BookingId = Guid.NewGuid();
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:" + BusConstants.StartBookingTranastionQueue));
            //var clientconfig = new ClientConfig();

            //clientconfig.GetGroupConfig().SetName("prod");
            //clientconfig.GetNetworkConfig().AddAddress("localhost:44398");

            //var client = HazelcastClient.NewHazelcastClient(clientconfig);

            //var map = client.GetMap<string, BookingModel>("my-distributed-map");

            //map.Put("BookingDetails", bookingModel);

            _bookingDataAccess.SaveBooking(bookingModel);

            await endpoint.Send<IStartBooking>(new
            {
                BookingId = bookingModel.BookingId,
                CardDetails = bookingModel.CardDetails,
                FlightDetails = bookingModel.FlightDetails
            });

            return Ok("Success");
            }
    }
}