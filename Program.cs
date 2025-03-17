namespace JukeboxProofOfConcept;

public class JukeboxProofOfConcept
{
    static async Task Main(string[] args)
    {
        Melody melody = Melody.TetrisA(140);

        var (left, top) = Console.GetCursorPosition();

        var source = new CancellationTokenSource();
        var token = source.Token;

        var interceptTask = InterceptInput(token);
        var animTask = Anim(left, top, token);
        var playTask = Play(melody, source, 1);

        await interceptTask;
        await animTask;
        await playTask;

        static async Task InterceptInput(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (await Task.Run(() => Console.KeyAvailable))
                {
                    await Task.Run(() => Console.ReadKey(true));
                }
            }
        }

        static async Task Anim(int left, int top, CancellationToken token)
        {
            char[] frames = ['/', '—', '\\', '|'];
            while (true)
            {
                foreach (char frame in frames)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(frame);
                    await Task.Delay(500);

                    if (token.IsCancellationRequested)
                        return;
                }
            }
        }

        static async Task Play(Melody melody, CancellationTokenSource source, int loops = 1, bool verbose = false)
        {
            var tune = melody.Tune;
            int mpsb = melody.Mpsb;

            for (int i = 0; i < loops; i++)
            {
                foreach (var tone in tune)
                {
                    int freq = (int)tone.Item1;
                    freq = freq >= 37 ? freq : 0;
                    int time = (int)((int)tone.Item2 * mpsb * 1.0);

                    if (verbose) Console.WriteLine($"Hz:{freq}, Ms: {time}");

                    if (freq != 0)
                    {
                        Console.Beep(freq, time);
                    }
                    else
                        await Task.Delay(time);
                }
            }

            source.Cancel();
        }
    }
}