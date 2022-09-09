namespace NBack;

public record TestAuswertung(IReadOnlyList<char> Reize, bool[] Antworten, double ProzentKorrekt);

internal static class TestAuswerter
{
    public static TestAuswertung WerteTestAus(IReadOnlyList<char> reize, bool[] antworten, int aktuellerIndex)
    {
        return new TestAuswertung(reize, antworten,  antworten.Count(a => a));
    }
}