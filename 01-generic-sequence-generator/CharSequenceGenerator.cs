public class CharSequenceGenerator : SequenceGenerator<char>
{
    public CharSequenceGenerator(char previous, char current)
        : base(previous, current)
    {
    }

    protected override char GetNext()
    {
        int previousIndex = Previous - 'A';
        int currentIndex = Current - 'A';

        int nextIndex = (previousIndex + currentIndex) % 26;

        return (char)('A' + nextIndex);
    }
}

