using ConsoleLab1.Enums;

namespace ConsoleLab1.Config;

public static class SimulationSettings
{
    public const int SemesterDays = 100;
    public const int PleasurePerSkip = 1;
    public const int PleasurePerPie = 1;

    public static readonly Subject[] AllSubjects = Enum.GetValues<Subject>();
}