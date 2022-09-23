using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHook.Controllers;
using WebHook.Data;
using WebHook.DTO;
using WebHook.Mapper;
using WebHook.Models;

namespace WebHookTestProject
{
    public  class MockData : IDisposable
    {

        protected readonly WebhooksController _wbhc;
        protected readonly WebDbContext _context;
        protected IMapper _mapper;
        protected WebhookSubscription[] registed;
        protected WebHookTestDto inputfortest;
        public MockData()

        {

            var optionsBuilder = new DbContextOptionsBuilder<WebDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString());
            _context = new WebDbContext(optionsBuilder.Options);

            _context.Database.EnsureCreated();

            registed = new[]
            {
                new WebhookSubscription()
                {
                    URL="http://localhost:5000/CreateSubsription/Test888",
                    Token="123",
                    Id=1
                }
            };

            _context.WebhookSubscriptions.AddRange(registed);
            _context.SaveChanges();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new WebHookMappings());
            });
            _mapper = mappingConfig.CreateMapper();

            _wbhc = new WebhooksController(_mapper, _context);

            inputfortest = new WebHookTestDto()
            {
                Name = "WebHookTest",
                Id = "001",
                City = "Copenheagen"
            };
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
