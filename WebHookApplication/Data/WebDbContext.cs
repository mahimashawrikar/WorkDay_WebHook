using WebHook.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WebHook.Data
{
    public class WebDbContext : DbContext
    {
       
        public WebDbContext(DbContextOptions<WebDbContext> opt) :base(opt)
        {
            
        }

        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }
       
    }
}