using ConsoleLab1.Enums;
using ConsoleLab1.Model;

namespace ConsoleLab1.Rules;

public class XorRule : ITeacherRule
{
    private readonly Subject _subjectA;
    private readonly Subject _subjectB;

    public XorRule(Subject subjectA, Subject subjectB)
    {
        if (subjectA == subjectB)
        {
            throw new ArgumentException("Предметы A и Б должны быть разными");
        }

        _subjectA = subjectA;
        _subjectB = subjectB;
    }

    public bool ShouldAsk(AskHistory history)
    {
        bool askedA = history.WasAskedYesterday(_subjectA);
        bool askedB = history.WasAskedYesterday(_subjectB);

        return askedA != askedB;
    }

    public override string ToString() => $"спросить, если вчера спросили ровно по одному из {_subjectA}, {_subjectB}";
}