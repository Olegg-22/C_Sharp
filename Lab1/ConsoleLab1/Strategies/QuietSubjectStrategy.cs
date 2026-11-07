using ConsoleLab1.Enums;
using ConsoleLab1.Model;

namespace ConsoleLab1.Strategies;

public class QuietSubjectStrategy(int quietDays) : ISkipStrategy
{
    public string Name => $"Прогуливаю, если {quietDays} дн. подряд не спрашивали";

    public bool ShouldAttend(int day, Subject subject, AskHistory history)
    {
        if (history.DaysCount < quietDays)
        {
            return true;
        }

        int lastDay = history.DaysCount;
        for (int d = lastDay; d > lastDay - quietDays; d--)
        {
            if (history.WasAsked(d, subject))
            {
                return true;
            }
        }

        return false;
    }
}