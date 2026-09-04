// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

IConfiguration config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? apiKey = config["Trello:ApiKey"];
string? apiToken = config["Trello:ApiToken"];

if (string.IsNullOrWhiteSpace(apiKey))
{
    Console.WriteLine("Missing Trello:ApiKey");
    return 1;
}

if (string.IsNullOrWhiteSpace(apiToken))
{
    Console.WriteLine("Missing Trello:ApiToken");
    return 1;
}

string url = $"https://api.trello.com/1/members/me/boards?key={apiKey}&token={apiToken}";

using HttpClient client = new HttpClient();
string json = await client.GetStringAsync(url);

Console.WriteLine(json);

return 0;

