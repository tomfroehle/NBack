using System.Runtime.CompilerServices;

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
                await Task.Delay(reizDauer, cancellationToken).ConfigureAwait(true);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
    }

    public static async IAsyncEnumerable<char> StarteReizEmittierung(IEnumerable<char> reize, int reizDauer,[EnumeratorCancellation] CancellationToken cancellationToken)
    {
        foreach (var reiz in reize)
        {
            yield return reiz;
            try
            {
                await Task.Delay(reizDauer, cancellationToken).ConfigureAwait(true);
            }
            catch (TaskCanceledException)
            {
                break;
            }
        }
    }
}