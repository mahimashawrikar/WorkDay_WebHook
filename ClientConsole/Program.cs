using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Program call = new Program();
            call.CallingWebHookRegistrationMethod();
            call.CallingTriggerMethod();
            Console.ReadLine();
        }
     
        public void CallingWebHookRegistrationMethod()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("http://localhost:9876/api/Webhooks/CreateSubsription");
                var newpost = new WebHookRegistationPost()
                {
                    URL="http://localhost:9807/CreateSubsription/Test789",
                    Token="34512"
                };
                var newPostJson = JsonConvert.SerializeObject(newpost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine("WebHook Registred with below details: \n{0}", result);
            }
        }

        public void CallingTriggerMethod()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri("http://localhost:9876/api/Webhooks/Test");
                var newpost = new TestPost()
                {
                    Name = "WebHookTest",
                    Id = "001",
                    City = "Copenheagen"
                };
                var newPostJson = JsonConvert.SerializeObject(newpost);
                var payload = new StringContent(newPostJson, Encoding.UTF8, "application/json");
                var result = client.PostAsync(endpoint, payload).Result.Content.ReadAsStringAsync().Result;
                Console.WriteLine("These are the WebHooks triggered: \n{0}", result);
            }
        }
    }
}
