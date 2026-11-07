using ConsoleLab1.Enums;

namespace ConsoleLab1.Model;

public class AskHistory
{
    private readonly List<Dictionary<Subject, bool>> _days = new();

    public int DaysCount => _days.Count;

    public void AddDay(Dictionary<Subject, bool> askedToday)
    {
        _days.Add(new Dictionary<Subject, bool>(askedToday));
    }

    public bool WasAsked(int day, Subject subject)
    {
        return _days[day - 1][subject];
    }

    public bool WasAskedYesterday(Subject subject)
    {
        return _days.Count != 0 && _days[^1][subject];
    }
}