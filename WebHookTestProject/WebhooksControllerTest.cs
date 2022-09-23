using AutoMapper;
using Microsoft.EntityFrameworkCore.InMemory;
using WebHook.Controllers;
using WebHook.Data;
using WebHook.DTO;
using WebHook.Mapper;
using WebHook.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace WebHookTestProject
{
    public class WebhooksControllerTest : MockData
    {
          
        [Fact]
        public void CreateSubsription_ShouldReturn_AppropriateType_AndIsNotNull()
        {
            var result = _wbhc.CreateSubsription(_mapper.Map< WebhookSubscriptionCreateDto>(_context.WebhookSubscriptions.FirstOrDefault()));

            Assert.IsType<ActionResult<WebhookSubscriptionReadDto>>(result);
            Assert.NotNull(result);

        }

        [Fact]
        public void CreateSubsription_ShouldReturn_Null()
        {
          

            var result = _wbhc.CreateSubsription(_mapper.Map<WebhookSubscriptionCreateDto>(_context.WebhookSubscriptions.FirstOrDefault()));

            Assert.Null(result.Value);


        }

        [Fact]
        public void CreateSubsription_ShouldReturn_CorrectResult()
        {
            WebhookSubscriptionCreateDto input = new WebhookSubscriptionCreateDto()
            {
                URL = "http://localhost:50890/CreateSubsription/Test456",
                Token = "123",
            };
 

            ActionResult<WebhookSubscriptionReadDto> actionresult = _wbhc.CreateSubsription(input) ;
            OkObjectResult okresult = Assert.IsType<OkObjectResult> (actionresult.Result);
            WebhookSubscriptionReadDto result = Assert.IsType<WebhookSubscriptionReadDto>(okresult.Value);
            
            
            Assert.Equal(result.Token, input.Token);
            Assert.Equal(result.URL, input.URL);


        }

        [Fact]
        public void Test_ShouldReturn_AppropriateType_AndIsNotNull()
        {
            var result = _wbhc.Test(inputfortest);

            Assert.IsType<ActionResult<String>>(result);
            Assert.NotNull(result);

        }

        [Fact]
        public void Test_ShouldReturn_Null()
        {
            _context.WebhookSubscriptions = null;

            var result = _wbhc.Test(inputfortest);

            Assert.Null(result.Value);


        }
        [Fact]
        public void Test_ShouldReturn_CorrectResult()
        {
            
            var result = _wbhc.Test(inputfortest);

            ActionResult<String> actionresult = _wbhc.Test(inputfortest);
            OkObjectResult okresult = Assert.IsType<OkObjectResult>(actionresult.Result);
         

            Assert.Equal("WebHook Triggered for  Token :123\n", okresult.Value);
           
        }

        [Fact]
        public void Trigger_ShouldReturn_CorrectResult()
        {
            NotificationMessageDto inputfortrigger = new NotificationMessageDto()
            {
                Token = "567",

                WebhookPayLoad=inputfortest

            };
            
            ActionResult<String> actionresult = _wbhc.Trigger(inputfortrigger);
            OkObjectResult okresult = Assert.IsType<OkObjectResult>(actionresult.Result);

            Assert.Equal("WebHook Triggered for  Token :567\n", okresult.Value);

        }

       
    }
    
}