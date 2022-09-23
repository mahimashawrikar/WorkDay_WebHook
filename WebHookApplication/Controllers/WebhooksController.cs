using WebHook.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Data;
using WebHook.Models;
using System.Text;
using WebHook.DTO;

namespace WebHook.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly WebDbContext _context;
        

        public WebhooksController( IMapper mapper, WebDbContext context)
        {

            _context = context;
            _mapper = mapper;
            
            
        }

        [HttpGet]
        public IActionResult Index()

        {
            string s = "WebHook Application";
            Console.WriteLine(s);
            return Ok(s);
        }

        [HttpPost("CreateSubsription")]
        public ActionResult<WebhookSubscriptionReadDto> CreateSubsription([FromBody] WebhookSubscriptionCreateDto webhookSubscriptionCreate)
        {
            try
            {
                var subscription = _context.WebhookSubscriptions.FirstOrDefault(s => s.URL == webhookSubscriptionCreate.URL);
                 
                if (subscription == null)
                {
                    subscription = _mapper.Map<WebhookSubscription>(webhookSubscriptionCreate);
                    _context.WebhookSubscriptions.Add(subscription);
                    _context.SaveChanges();
                }

                else
                {
                    return NoContent();
                }
               
                var webhookSubscriptionReadDto = _mapper.Map<WebhookSubscriptionReadDto>(subscription);

                return Ok(webhookSubscriptionReadDto);
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Test")]
        public ActionResult<String> Test([FromBody] WebHookTestDto webHookTest)
        {
            try
            {
                String resultValues = String.Empty;

                if (_context.WebhookSubscriptions.Count() == 0)
                {
                    Console.WriteLine("No WebHook Triggered");
                    return NoContent();
                }
                else
                {
                    foreach (var element in _context.WebhookSubscriptions)
                    {
                        

                        NotificationMessageDto message = new NotificationMessageDto
                        {
                            Token = element.Token.ToString(),
                            WebhookPayLoad = webHookTest
                        };
                        resultValues+=((ObjectResult)Trigger(message).Result).Value.ToString();
                        
                    }
                }
                return Ok(resultValues);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Trigger")]
        public ActionResult<String> Trigger([FromBody] NotificationMessageDto notificationMessageDto)
        {
            try
            {
                
                    string result = "WebHook Triggered for  Token :" + notificationMessageDto.Token.ToString() + "\n";
                    return Ok(result);
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
