using System;

public class CustomIndexRandom
{
    private uint index;
    private int seed;

    public CustomIndexRandom() : this(Environment.TickCount)
    {
    }

    public CustomIndexRandom(int seed)
    {
        this.index = 0;
        this.seed = seed;
    }

    private double Frac(double value)
    {
        return value - Math.Floor(value);
    }

    // [0, 1)
    protected double Sample()
    {
        return Sample(index++);
    }

    protected double Sample(uint i)
    {
        var x = i << 3;
        var y = (i * 13) >> 2;
        var z = seed;
        return Frac(Math.Sin(12.9898 * x + 78.233 * y + 6.283 * z) * 43758.5453);
    }

    public void SetIndex(uint pIndex)
    {
        this.index = pIndex;
    }

    public uint GetIndex()
    {
        return this.index;
    }

    #region GetNext

    public int Next(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue),
                string.Format("minvalue:{0} is bigger than maxvalue:{1}", minValue, maxValue));
        }

        var num = maxValue - minValue;
        return (int) (this.Sample() * num) + minValue;
    }

    public int Next(int maxValue)
    {
        return Next(0, maxValue);
    }

    public double Next()
    {
        return Sample();
    }

    public int NextByIndex(uint index, int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(minValue),
                string.Format("minvalue:{0} is bigger than maxvalue:{1}", minValue, maxValue));
        }

        var num = maxValue - minValue;
        return (int) (this.Sample() * num) + minValue;
    }

    public int NextByIndex(uint index, int maxValue)
    {
        return NextByIndex(0, maxValue);
    }

    public double NextByIndex(uint index)
    {
        return Sample(index);
    }

    #endregion
}
