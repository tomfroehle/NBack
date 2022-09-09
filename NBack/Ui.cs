namespace NBack;

public static class Ui
{
    public static async Task Start(Action onCancel, Action onRegister, CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested is false)
        {
            while (Console.KeyAvailable is false && cancellationToken.IsCancellationRequested is false)
            {
                await Task.Delay(5, cancellationToken);
            }
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    onCancel();
                    break;
                case ConsoleKey.Spacebar:
                    onRegister();
                    break;
            }
        }
    }



    public static void Print(char i)
    {
        Console.Clear();
        Console.WriteLine(i);
    }


    public static void Print(TestAuswertung auswertung)
    {
        Console.Clear();
        Console.WriteLine($"Reize: {string.Concat(auswertung.Reize)}");
        Console.WriteLine($"Antworten: {string.Concat(auswertung.Antworten.Select(a => a ? "J" : "N"))}");
    }
}