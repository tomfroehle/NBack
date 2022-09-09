namespace NBack;

public class TestAusführung
{
    private readonly  bool[] _antworten;
    private int _aktuellerIndex;
    private readonly int _anzahlReize;

    public TestAusführung(int anzahlReize)
    {
        _aktuellerIndex = 0;
        _antworten = new bool[anzahlReize];
        _anzahlReize = anzahlReize;
    }

    public async Task<TestAuswertung> FühreTestAus(int reizDauer, Action<char> onReiz, CancellationToken cancellationToken)
    {
        var chars = ReizGenerieer.GeneriereReize(_anzahlReize);
        await ReizEmittierer.StarteReizEmittierung(chars, reizDauer, OnReiz, cancellationToken);
        return TestAuswerter.WerteTestAus(chars, _antworten, _aktuellerIndex);

        void OnReiz(char reiz)
        {
            _aktuellerIndex++;
            onReiz(reiz);
        }
    }


    public void RegistriereReizWiederholung()
    {
        _antworten[_aktuellerIndex] = true;
    }
}