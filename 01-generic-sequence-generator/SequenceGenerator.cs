public abstract class SequenceGenerator<T> : ISequenceGenerator<T>
{
    private T previous;
    private T current;

    public SequenceGenerator(T previous, T current)
    {
        this.previous = previous;
        this.current = current;
        Count = 2;
    }

    public T Previous
    {
        get { return previous; }
    }

    public T Current
    {
        get { return current; }
    }

    public T Next
    {
        get
        {
            T next = GetNext();

            previous = current;
            current = next;
            Count++;

            return next;
        }
    }

    public int Count { get; private set; }

    protected abstract T GetNext();
}