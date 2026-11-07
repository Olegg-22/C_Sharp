using System.Text;
using ConsoleLab1.Config;
using ConsoleLab1.Enums;
using ConsoleLab1.Model;
using ConsoleLab1.Rules;
using ConsoleLab1.Simulation;
using ConsoleLab1.Strategies;

var random = new Random();

var ruleGenerator = new RuleGenerator(random);
var teachers = new List<Teacher>();
foreach (var subject in SimulationSettings.AllSubjects)
{
    teachers.Add(new Teacher(subject, ruleGenerator.CreateRandomRule()));
}

Console.WriteLine("Правила преподавателей:");
foreach (Teacher teacher in teachers)
{
    Console.WriteLine($"  {teacher}");
}

ISkipStrategy strategy = new QuietSubjectStrategy(quietDays: 10);
Console.WriteLine($"\nСтратегия: {strategy.Name}");
Console.WriteLine("Обозначения: П — пришёл, - — прогулял, ? — спросили\n");

var simulator = new SemesterSimulator(teachers, strategy, SimulationSettings.SemesterDays);
while (!simulator.IsFinished)
{
    DayResult day = simulator.RunNextDay();
    Console.WriteLine(FormatDay(day));
}

Console.WriteLine();
Console.WriteLine(simulator.IsExpelled ? "ВЫЛЕТЕЛ!" : "Семестр пережит.");
Console.WriteLine($"Дней прошло: {simulator.CurrentDay}");
Console.WriteLine($"Общее удовольствие: {simulator.TotalPleasure}");
Console.WriteLine($"Среднее удовольствие в день: {simulator.AveragePleasurePerDay:F2}");

static string FormatDay(DayResult day)
{
    var sb = new StringBuilder();
    sb.Append($"День {day.Day,3}: ");

    foreach (LessonResult lesson in day.Lessons)
    {
        char presence = lesson.Attended ? 'П' : '-';
        char question = lesson.Asked ? '?' : ' ';
        sb.Append($"[{presence}{question}] ");
    }

    sb.Append($"| удовольствие: {day.TotalPleasure}");
    if (day.Expelled)
    {
        sb.Append("  <-- спросили на прогуле, вылет");
    }

    return sb.ToString();
}