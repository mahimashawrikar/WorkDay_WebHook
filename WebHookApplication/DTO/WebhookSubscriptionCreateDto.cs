using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebHook.DTO
{
    public class WebhookSubscriptionCreateDto
    {        
        public string URL { get; set; }
        public string Token { get; set; }
    }
}
