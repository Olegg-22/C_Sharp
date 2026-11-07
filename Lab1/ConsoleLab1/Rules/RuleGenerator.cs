using ConsoleLab1.Config;
using ConsoleLab1.Enums;

namespace ConsoleLab1.Rules;

public class RuleGenerator(Random random)
{
    public ITeacherRule CreateRandomRule()
    {
        int ruleNumber = random.Next(3);

        return ruleNumber switch
        {
            0 => new RandomRule(random),
            1 => new FollowSubjectRule(PickSubject()),
            _ => CreateXorRule(),
        };
    }

    private XorRule CreateXorRule()
    {
        Subject a = PickSubject();
        Subject b;

        do
        {
            b = PickSubject();
        } while (b == a);

        return new XorRule(a, b);
    }

    private Subject PickSubject()
    {
        Subject[] all = SimulationSettings.AllSubjects;
        return all[random.Next(all.Length)];
    }
}