Instruction to use WebHookApplication :

1)In appsettings.json file replace WebHookConnection connection string, with your Azure cloud SQL DB(since it was written in the problem statement that data should not persist on disk).
  A bacpac file is attached with the solution for sample DB.

2)Run the WebHook Application.

3)Use Postman or ClientConsole application to test any of the Post methods:

a) http://localhost:9876/api/Webhooks/CreateSubsription

method accepts json in below format:
{
    "URL":"http://localhost:9878/CreateSubsription/Test333",
    "Token":"34512"
}

b)http://localhost:9876/api/Webhooks/Test

method accepts json in below format:
{
    "Name":"Martin",
    "Id":"123",
    "City":"London"
}

4) If you are using WebHook.Client for testing : Run WebHook and WebHook.Client application.Set both Projects as startup.

You can test CreateSubsription,Test Post-methods seperately by giving different values in json format.For now I have given a sample json.You can give new  values to json fields.
Please comment any of the method call in WebHook.Client application if you want to test CreateSubsription,Test Post-methods seperately.

5)Trigger method is written just to indicate that we can write any trigger logic inside this method once webhook is registered.

6)To Run WebHook.Test Project you need to open Test explorer and click on "Run All", it is written using in memory Database.


