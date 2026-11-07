using ConsoleLab1.Enums;
using ConsoleLab1.Model;

namespace ConsoleLab1.Strategies;

public class AlwaysAttendStrategy : ISkipStrategy
{
    public string Name => "Хожу на всё";

    public bool ShouldAttend(int day, Subject subject, AskHistory history) => true;
}
