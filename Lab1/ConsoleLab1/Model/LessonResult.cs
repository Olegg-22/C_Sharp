using ConsoleLab1.Enums;

namespace ConsoleLab1.Model;

public record LessonResult(Subject Subject, bool Attended, bool Asked)
{
    public bool IsSkipped => !Attended && !Asked;
    public bool IsFatal => !Attended && Asked;
}