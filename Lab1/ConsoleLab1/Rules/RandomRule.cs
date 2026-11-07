using ConsoleLab1.Model;

namespace ConsoleLab1.Rules;

public class RandomRule(Random random) : ITeacherRule
{
    public bool ShouldAsk(AskHistory history) => random.Next(2) == 1;

    public override string ToString() => "случайно 50%";
}
