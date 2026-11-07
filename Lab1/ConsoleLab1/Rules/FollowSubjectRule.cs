using ConsoleLab1.Enums;
using ConsoleLab1.Model;

namespace ConsoleLab1.Rules;

public class FollowSubjectRule(Subject subjectA) : ITeacherRule
{
    public bool ShouldAsk(AskHistory history) => history.WasAskedYesterday(subjectA);

    public override string ToString() => $"спросить, если вчера спросили по {subjectA}";
}
