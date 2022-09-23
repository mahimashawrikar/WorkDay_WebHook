using System.ComponentModel.DataAnnotations;

namespace WebHook.Models
{
    public class WebhookSubscription
    {
        
        [Required]
        public string Token { get; set; }

        [Required]
        public string URL { get; set; }

        [Key]
        [Required]
        public int Id { get; set; }

        
    }
}