using ConsoleLab1.Model;

namespace ConsoleLab1.Rules;

public interface ITeacherRule
{
    bool ShouldAsk(AskHistory history);
}
