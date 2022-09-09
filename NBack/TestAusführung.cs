namespace NBack;

public class TestAusführung
{
    private readonly  bool[] _antworten;
    private int _aktuellerIndex;
    private readonly int _anzahlReize;

    public TestAusführung(int anzahlReize)
    {
        _aktuellerIndex = -1;
        _antworten = new bool[anzahlReize];
        _anzahlReize = anzahlReize;
    }

    public async Task<TestAuswertung> FühreTestAus(int reizDauer, Action<char> onReiz, CancellationToken cancellationToken)
    {
        var reize = ReizGenerierer.GeneriereReize(_anzahlReize);
        //await foreach (var reiz in ReizEmittierer.StarteReizEmittierung(reize, reizDauer, cancellationToken))
        //{
        //    OnReiz(reiz);
        //}
        await ReizEmittierer.StarteReizEmittierung(reize, reizDauer, OnReiz, cancellationToken);
        return TestAuswerter.WerteTestAus(reize, _antworten, _aktuellerIndex);

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