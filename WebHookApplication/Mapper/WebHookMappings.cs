using AutoMapper;
using WebHook.DTO;
using WebHook.DTO;
using WebHook.Models;

namespace WebHook.Mapper
{
    public class WebHookMappings:Profile
    {
        public WebHookMappings()
        {
            CreateMap<WebhookSubscriptionCreateDto, WebhookSubscription>().ReverseMap();
            CreateMap<WebhookSubscription, WebhookSubscriptionReadDto>().ReverseMap();
        }
    }
}
