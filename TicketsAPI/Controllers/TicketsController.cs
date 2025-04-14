using Azure.Storage.Queues;

using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketsAPI;
using System.Text;

namespace TicketsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {

        private readonly ILogger<TicketsController> _logger;
        private readonly IConfiguration _configuration;



        public TicketsController(ILogger<TicketsController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            {
                return Ok("Hello from Tickets Controller - GET");

            }
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync(Ticket ticket)
        {


            if (ModelState.IsValid == false)
            {   
                return BadRequest(ModelState);
            }

            //post contact to queue

            string queueName = "tickets";
            // Get connection string from secrets.json
            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            // send string message to queue (must encode as base64 to work properly)
            var plainTextBytes = Encoding.UTF8.GetBytes(message);
            await queueClient.SendMessageAsync(Convert.ToBase64String(plainTextBytes));



            return Ok("success - message posted to Storage Queue");
        }

    }
}
