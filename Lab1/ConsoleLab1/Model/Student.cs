using ConsoleLab1.Config;

namespace ConsoleLab1.Model;

public class Student
{
    public int Pleasure { get; private set; }
    public bool IsExpelled { get; private set; }

    public void EnjoySkip()
    {
        Pleasure += SimulationSettings.PleasurePerSkip;
    }

    public void EatPie()
    {
        Pleasure += SimulationSettings.PleasurePerPie;
    }

    public void Expel()
    {
        IsExpelled = true;
        Pleasure = 0;
    }
}