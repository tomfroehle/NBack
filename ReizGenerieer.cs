namespace NBack;

internal static class ReizGenerieer
{
    public static IReadOnlyList<char> GeneriereReize(int numberOfGuesses)
    {
        return new List<char> { 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D', 'A', 'B', 'C', 'D' }.Take(numberOfGuesses).ToList();
    }
}