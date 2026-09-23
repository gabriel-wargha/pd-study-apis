using CanvasTrelloSync.Models;
using System.Text.Json;

Course course = new Course();
course.Id = 3392;
course.Name = "Prompt Engineering";
course.CourseCode = "USF-PE-26";

Console.WriteLine(course);


string json = """{ "id": 2728, "name": "Enhancing Learning", "course_code": "PD-0141" }""";
Course? fromJson = JsonSerializer.Deserialize<Course>(json);

Console.WriteLine(fromJson);
