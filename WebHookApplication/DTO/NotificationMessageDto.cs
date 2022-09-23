using System;
using WebHook.DTO;

namespace WebHook.DTO
{
    public class NotificationMessageDto
    {      
        public string Token { get; set; }
        public WebHookTestDto WebhookPayLoad { get; set; }
        
    }
}