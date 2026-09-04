// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using System.Text.Json;

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

JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

List<Board>? boards = JsonSerializer.Deserialize<List<Board>>(json, options);

if (boards is null)
{
    Console.WriteLine("Could not parse the response.");
    return 1;
}

foreach (Board board in boards)
{
    Console.WriteLine($"{board.Name} [{(board.Closed ? "Closed" : "Open").PadRight(30)}] ({board.Id})");
}

return 0;

public record Board(string Id, string Name, bool Closed, string Url);

