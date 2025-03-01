using System;

public struct ClockTime
{
    public int value { get; }
    public int hours => value / 3600;
    public int minutes => value % 3600 / 60;
    public int seconds => value % 3600 % 60;

    public ClockTime(int value)
    {
        if (value < 0) throw nonNegativeException;
        this.value = value;
    }

    public ClockTime(float value)
    {
        if (value < 0) throw nonNegativeException;
        this.value = (int)value;
    }

    public ClockTime(string value)
    {
        if (int.TryParse(value, out var intResult))
        {
            if (intResult < 0) throw nonNegativeException;
            this.value = intResult;
        }
        else
        {
            if (float.TryParse(value, out var floatResult))
            {
                if (floatResult < 0) throw nonNegativeException;
                this.value = (int)floatResult;
            }
            else
            {
                throw acceptException;
            }
        }
    }

    public override string ToString()
    {
        return $"{hours}:{minutes}:{seconds}";
    }

    public string ToStringWithoutSeparator()
    {
        return $"{hours}{minutes}{seconds}";
    }

    public string ToStringChineseFormat()
    {
        return $"{hours}小时{minutes}分钟{seconds}秒";
    }

    private static ArgumentException nonNegativeException => new ArgumentException("Value must be non-negative.");
    private static ArgumentException acceptException => new ArgumentException("The value cannot be accepted");
}