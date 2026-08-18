public interface ISequenceGenerator<T>
{
    T Previous { get; }

    T Current { get; }

    T Next { get; }
}