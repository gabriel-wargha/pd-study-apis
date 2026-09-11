using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

IConfiguration config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? token = config["Canvas:Token"];
string? baseUrl = config["Canvas:BaseUrl"];

if (string.IsNullOrWhiteSpace(token))
{
    Console.WriteLine("Missing Canvas:Token");
    return 1;
}

if (string.IsNullOrWhiteSpace(baseUrl))
{
    Console.WriteLine("Missing Canvas:BaseUrl");
    return 1;
}

using HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
client.DefaultRequestHeaders.UserAgent.ParseAdd("CanvasExplorer/1.0");

string coursesUrl = $"{baseUrl}/api/v1/courses?per_page=5";
HttpResponseMessage response = await client.GetAsync(coursesUrl);

if (!response.IsSuccessStatusCode)
{
    string errorBody = await response.Content.ReadAsStringAsync();
    Console.WriteLine($"Could not fetch courses: {(int)response.StatusCode} {response.StatusCode}");
    Console.WriteLine(errorBody);
    return 1;
}

string coursesJson = await response.Content.ReadAsStringAsync();

JsonSerializerOptions options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

List<Course>? courses = JsonSerializer.Deserialize<List<Course>>(coursesJson, options);

if (courses is null)
{
    Console.WriteLine("Could not parse the courses response.");
    return 1;
}

foreach (Course course in courses )
{
    Console.WriteLine($"{course.Id}  {course.Name}");
}


return 0;
record Course(long Id, string? Name);
