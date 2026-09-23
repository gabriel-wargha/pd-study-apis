using CanvasTrelloSync.Models;
using System.Text.Json;

Course course = new Course();
course.Id = 3392;
course.Name = "Prompt Engineering";
course.CourseCode = "USF-PE-26";

Console.WriteLine(course);


string json = """{ "id": 2728, "name": "Enhancing Learning", "course_code": "PD-0141" }""";
Course? fromJson = JsonSerializer.Deserialize<Course>(json);

string assignmentJson = """
      { "id": 34905, "name": "M1: AI Prompting Lab Part I", "due_at": null,
        "html_url": "https://learn.canvas.net/courses/3392/assignments/34905",
        "points_possible": 10, "submission": { "workflow_state": "unsubmitted" } }
      """;

Assignment? assignment = JsonSerializer.Deserialize<Assignment>(assignmentJson);
assignment!.CourseCode = "USF-PE-26";

Console.WriteLine(assignment);
