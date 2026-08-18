// See https://aka.ms/new-console-template for more information
/*
var generator = new FibonacciSequenceGenerator(0, 1);

var sequence = new List<int>
{
    generator.Previous,
    generator.Current
};

for (int i = 0; i < 8; i++)
{
    sequence.Add(generator.Next);
}

Console.WriteLine(string.Join(", ", sequence));
Console.WriteLine($"Üretilen yeni eleman sayısı: {generator.Count}");

////////////////////////////////////////////////////////////////////////////////////

var fibonacciGenerator = new FibonacciSequenceGenerator(0, 1);

var fibonacciSequence = new List<int>
{
    fibonacciGenerator.Previous,
    fibonacciGenerator.Current
};

for (int i = 0; i < 8; i++)
{
    fibonacciSequence.Add(fibonacciGenerator.Next);
}

Console.WriteLine("Fibonacci:");
Console.WriteLine(string.Join(", ", fibonacciSequence));

var integerGenerator = new IntegerSequenceGenerator(1, 2);

var integerSequence = new List<int>
{
    integerGenerator.Previous,
    integerGenerator.Current
};

for (int i = 0; i < 8; i++)
{
    integerSequence.Add(integerGenerator.Next);
}

Console.WriteLine();
Console.WriteLine("Integer:");
Console.WriteLine(string.Join(", ", integerSequence));

////////////////////////////////////////////////////////////////////////////////////

var doubleGenerator = new DoubleSequenceGenerator(1.0, 2.0);

var doubleSequence = new List<double>
{
    doubleGenerator.Previous,
    doubleGenerator.Current
};

for (int i = 0; i < 8; i++)
{
    doubleSequence.Add(doubleGenerator.Next);
}

Console.WriteLine();
Console.WriteLine("Double:");

foreach (double number in doubleSequence)
{
    Console.Write($"{number:F5} ");
}

Console.WriteLine();

////////////////////////////////////////////////////////////////////////////////////

var charGenerator = new CharSequenceGenerator('A', 'B');

var charSequence = new List<char>
{
    charGenerator.Previous,
    charGenerator.Current
};

for (int i = 0; i < 8; i++)
{
    charSequence.Add(charGenerator.Next);
}


Console.WriteLine();
Console.WriteLine("Char:");
Console.WriteLine(string.Join(", ", charSequence));

////////////////////////////////////////////////////////////////////////////////////

var delegateGenerator = new DelegateSequenceGenerator<int>(
    1,
    1,
    (previous, current) => previous + current
);

var delegateSequence = new List<int>
{
    delegateGenerator.Previous,
    delegateGenerator.Current
};

for (int i = 0; i < 6; i++)
{
    delegateSequence.Add(delegateGenerator.Next);
}

Console.WriteLine();
Console.WriteLine("Delegate Fibonacci:");
Console.WriteLine(string.Join(", ", delegateSequence));

////////////////////////////////////////////////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////
var solutionDoubleSequence =
    Solution.HowToUseDoubleSequenceGenerator(10, 1.0, 2.0);

Console.WriteLine();
Console.WriteLine("Solution Double:");

foreach (double number in solutionDoubleSequence)
{
    Console.Write($"{number:F5} ");
}

Console.WriteLine();

*/

Test(
    "Char A-B",
    Solution.HowToUseCharSequenceGenerator(10, 'A', 'B'),
    new[] { 'A', 'B', 'B', 'C', 'D', 'F', 'I', 'N', 'V', 'I' }
);

Test(
    "Char Y-Z",
    Solution.HowToUseCharSequenceGenerator(10, 'Y', 'Z'),
    new[] { 'Y', 'Z', 'X', 'W', 'T', 'P', 'I', 'X', 'F', 'C' }
);

Test(
    "Integer",
    Solution.HowToUseIntegerSequenceGenerator(10, 1, 2),
    new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 }
);

Test(
    "Fibonacci",
    Solution.HowToUseFibonacciSequenceGenerator(10, 0, 1),
    new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 }
);

TestDouble(
    "Double",
    Solution.HowToUseDoubleSequenceGenerator(10, 1.0, 2.0),
    new[]
    {
        1.0,
        2.0,
        2.5,
        3.3,
        4.05757575757576,
        4.87086926018965,
        5.70389834408211,
        6.55785277425587,
        7.42763417076325,
        8.31053343902137
    }
);

Test(
    "Delegate Fibonacci",
    Solution.HowToUseDelegateSequenceGenerator(
        8,
        1,
        1,
        (previous, current) => previous + current
    ),
    new[] { 1, 1, 2, 3, 5, 8, 13, 21 }
);

Test(
    "Delegate Integer",
    Solution.HowToUseDelegateSequenceGenerator(
        10,
        1,
        2,
        (previous, current) => (6 * current) - (8 * previous)
    ),
    new[] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512 }
);

TestDouble(
    "Delegate Double",
    Solution.HowToUseDelegateSequenceGenerator(
        10,
        1.0,
        2.0,
        (previous, current) => current + (previous / current)
    ),
    new[]
    {
        1.0,
        2.0,
        2.5,
        3.3,
        4.05757575757576,
        4.87086926018965,
        5.70389834408211,
        6.55785277425587,
        7.42763417076325,
        8.31053343902137
    }
);

static void Test<T>(
    string testName,
    IEnumerable<T> actual,
    IEnumerable<T> expected)
{
    bool passed = actual.SequenceEqual(expected);

    Console.WriteLine(
        $"{testName}: {(passed ? "BAŞARILI" : "BAŞARISIZ")}"
    );

    if (!passed)
    {
        Console.WriteLine($"Beklenen: {string.Join(", ", expected)}");
        Console.WriteLine($"Gerçek:   {string.Join(", ", actual)}");
    }
}

static void TestDouble(
    string testName,
    IEnumerable<double> actual,
    IEnumerable<double> expected)
{
    double[] actualArray = actual.ToArray();
    double[] expectedArray = expected.ToArray();

    bool passed =
        actualArray.Length == expectedArray.Length &&
        actualArray
            .Zip(expectedArray)
            .All(pair => Math.Abs(pair.First - pair.Second) < 0.00001);

    Console.WriteLine(
        $"{testName}: {(passed ? "BAŞARILI" : "BAŞARISIZ")}"
    );

    if (!passed)
    {
        Console.WriteLine(
            $"Beklenen: {string.Join(", ", expectedArray.Select(x => x.ToString("F5")))}"
        );

        Console.WriteLine(
            $"Gerçek:   {string.Join(", ", actualArray.Select(x => x.ToString("F5")))}"
        );
    }
}