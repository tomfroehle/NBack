using NBack;

while (true)
{
    await StarteNeuenTestlauf();
}

static async Task StarteNeuenTestlauf()
{
    Console.Write("Anzahl Reize: ");
    var anzahlReize = int.Parse(Console.ReadLine()!);
    using var cts = new CancellationTokenSource();
    var testAusführung = new TestAusführung(anzahlReize);
    Ui.Start(cts.Cancel, testAusführung.RegistriereReizWiederholung, cts.Token).Forget();
    var ergebnis = await testAusführung.FühreTestAus(1000, Ui.Print, cts.Token);
    Ui.Print(ergebnis);
}