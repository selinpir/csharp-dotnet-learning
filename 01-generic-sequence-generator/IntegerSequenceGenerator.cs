public class IntegerSequenceGenerator : SequenceGenerator<int>
{
    public IntegerSequenceGenerator(int previous, int current)
        : base(previous, current)
    {
    }

    protected override int GetNext()
{
    return (6 * Current) - (8 * Previous);
}
}