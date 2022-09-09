namespace NBack;

internal static class ReizEmittierer
{
    public static async Task StarteReizEmittierung(IEnumerable<char> reize, int reizDauer, Action<char> onReiz, CancellationToken cancellationToken)
    {
        foreach (var reiz in reize)
        {
            onReiz(reiz);
            try
            {
                await Task.Delay(reizDauer, cancellationToken).ConfigureAwait(false);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
    }
}