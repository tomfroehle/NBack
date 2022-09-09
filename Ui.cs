namespace NBack;

public static class Ui
{
    public static void Start(Action onCancel, Action onRegister, CancellationToken cancellationToken)
    {
        Task.Run(() =>
            {
                while (cancellationToken.IsCancellationRequested is false)
                {
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
            }, cancellationToken);
    }



    public static void Print(char i)
    {
        Console.Clear();
        Console.WriteLine(i);
    }


    public static void Print(TestAuswertung auswertung)
    {
        Console.Clear();
        Console.WriteLine(auswertung);
    }
}