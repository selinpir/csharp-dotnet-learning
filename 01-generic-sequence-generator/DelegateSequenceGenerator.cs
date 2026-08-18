public class DelegateSequenceGenerator<T> : SequenceGenerator<T>
{
    private readonly Func<T, T, T> nextFunc;

    public DelegateSequenceGenerator(
        T previous,
        T current,
        Func<T, T, T> nextFunc)
        : base(previous, current)
    {
        ArgumentNullException.ThrowIfNull(nextFunc);

        this.nextFunc = nextFunc;
    }

    protected override T GetNext()
    {
        return nextFunc(Previous, Current);
    }
}