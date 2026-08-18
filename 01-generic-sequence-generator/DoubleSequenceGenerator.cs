public class DoubleSequenceGenerator : SequenceGenerator<double>
{
    public DoubleSequenceGenerator(double previous, double current)
        : base(previous, current)
    {
    }

    protected override double GetNext()
    {
        return Current + (Previous / Current);
    }
}