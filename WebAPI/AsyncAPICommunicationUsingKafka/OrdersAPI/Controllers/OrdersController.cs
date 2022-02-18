using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confluent.Kafka;
namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder(Order order)
        {
            //code to save order in database

            var data = new { ProductName = order.ProductName, Email = order.Email, Phone = order.PhoneNo };

            var json = JsonConvert.SerializeObject(data);

            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };
            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var message = new Message<Null, string>();
                message.Value = json;
                await producer.ProduceAsync("ordercreated", message);

                //producer.Dispose();
            }
            return StatusCode(201);
        }
    }
}
