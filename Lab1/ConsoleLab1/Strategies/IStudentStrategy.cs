using ConsoleLab1.Enums;
using ConsoleLab1.Model;

namespace ConsoleLab1.Strategies;

public interface ISkipStrategy
{
    string Name { get; }

    bool ShouldAttend(int day, Subject subject, AskHistory history);
}