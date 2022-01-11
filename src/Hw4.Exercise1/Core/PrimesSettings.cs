namespace Hw4.Exercise1.Core;

public class PrimesSettings
{
    public int From { get; }
    public int To { get; }

    public PrimesSettings(int from, int to)
    {
        From = from;
        To = to;
    }

    public PrimesSettings()
    {
        From = -1;
        To = -1;
    }
}
