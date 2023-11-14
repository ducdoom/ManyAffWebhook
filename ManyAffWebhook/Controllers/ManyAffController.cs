using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ManyAffWebhook.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ManyAffController : ControllerBase
    {
        [Route("test")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success cool!");
        }

        [Route("sendladisaledata")]
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            //read the body of the request as a string
            string postData = await new StreamReader(Request.Body).ReadToEndAsync();
            Models.CustomBotTextMsg payload = new Models.CustomBotTextMsg();
            payload.Content.Text = postData;
            string jsonString = JsonSerializer.Serialize(payload);

            //send post request to the webhook 
            string url = "https://open.larksuite.com/open-apis/bot/v2/hook/9aa0f257-55f5-45c8-ae6e-45640640616c";
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.SendAsync(request);
            return Ok("send message successfully!");
        }

        [Route("sendmessageasync")]
        [HttpGet]
        public async Task<IActionResult> SendMessageAsync()
        {
            string postData = @"{
    ""email"": ""pub1@gmail.com"",
    ""password"": ""123456"",
    ""values"": 1
}";

            Models.CustomBotTextMsg payload = new();
            payload.Content.Text = postData;
            string jsonString = JsonSerializer.Serialize(payload);

            //send post request to the webhook 
            string url = "https://open.larksuite.com/open-apis/bot/v2/hook/9aa0f257-55f5-45c8-ae6e-45640640616c";
            using HttpClient client = new();
            HttpRequestMessage request = new(HttpMethod.Post, url)
            {
                Content = new StringContent(jsonString, Encoding.UTF8, "application/json")
            };
            HttpResponseMessage response = await client.SendAsync(request);
            string content = await response.Content.ReadAsStringAsync();

            return Ok(content);
        }


    }
}
