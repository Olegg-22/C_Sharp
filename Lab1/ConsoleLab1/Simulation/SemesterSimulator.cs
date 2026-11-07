using ConsoleLab1.Enums;
using ConsoleLab1.Model;
using ConsoleLab1.Strategies;

namespace ConsoleLab1.Simulation;

public class SemesterSimulator(List<Teacher> teachers, ISkipStrategy strategy, int totalDays)
{
    private readonly Student _student = new();
    private readonly AskHistory _history = new();

    public int CurrentDay { get; private set; }

    public int TotalPleasure => _student.Pleasure;
    public bool IsExpelled => _student.IsExpelled;
    public bool IsFinished => IsExpelled || CurrentDay >= totalDays;
    
    public double AveragePleasurePerDay => CurrentDay == 0 ? 0 : (double)TotalPleasure / CurrentDay;

    public DayResult RunNextDay()
    {
        if (IsFinished)
        {
            throw new Exception("Семестр уже закончился");
        }

        CurrentDay++;
        var lessons = new List<LessonResult>();
        var askedToday = new Dictionary<Subject, bool>();

        foreach (Teacher teacher in teachers)
        {
            bool attend = strategy.ShouldAttend(CurrentDay, teacher.Subject, _history);
            bool asked = teacher.DecideToAsk(_history);

            var lesson = new LessonResult(teacher.Subject, attend, asked);
            lessons.Add(lesson);
            askedToday[teacher.Subject] = asked;

            if (lesson.IsFatal)
            {
                _student.Expel();
                return new DayResult(CurrentDay, lessons, TotalPleasure, Expelled: true);
            }

            if (lesson.IsSkipped)
            {
                _student.EnjoySkip();
            }
        }

        _history.AddDay(askedToday);
        _student.EatPie();

        return new DayResult(CurrentDay, lessons, TotalPleasure, Expelled: false);
    }
}