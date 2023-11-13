using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ManyAffWebhook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManyAffController : ControllerBase
    {
        [Route("test")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success cool!");
        }

        [Route("send")]
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


            //try
            //{
            //    JsonDocument jsonDocument;
            //    jsonDocument = await JsonDocument.ParseAsync(Request.Body);
            //    return Ok(jsonDocument);
            //}
            //catch (Exception ex)
            //{
            //    return BadRequest(ex.Message);
            //}
        }


    }
}
