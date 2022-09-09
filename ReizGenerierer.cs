namespace NBack;

internal static class ReizGenerierer
{
    public static IReadOnlyList<char> GeneriereReize(int numberOfGuesses)
    {
        return new List<char> { 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D' }.Take(numberOfGuesses).ToList();
    }
}