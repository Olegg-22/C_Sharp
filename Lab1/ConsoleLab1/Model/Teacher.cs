using ConsoleLab1.Enums;
using ConsoleLab1.Rules;

namespace ConsoleLab1.Model;

public class Teacher(Subject subject, ITeacherRule rule)
{
    public Subject Subject { get; } = subject;

    public bool DecideToAsk(AskHistory history) => rule.ShouldAsk(history);

    public override string ToString() => $"{Subject}: {rule}";
}