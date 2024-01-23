namespace Foodify.Domain.Common.ValueObjects;

public sealed class TimeRange : ValueObject
{
    public TimeOnly Start { get; }
    public TimeOnly End { get; }

    public TimeRange(TimeOnly start, TimeOnly end)
    {
        Start = start;
        End = end;

        if (Start > End)
        {
            throw new ArgumentException("Start time must be before end time.");
        }
    }

    public bool IsOverlapping(TimeRange other)
    {
        return Start < other.End && other.Start < End;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
    }
}