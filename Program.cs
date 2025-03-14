using System.Threading.Tasks;

namespace JukeboxProofOfConcept;


public class JukeboxProofOfConcept
{
    static async Task Main(string[] args)
    {
        Melody melody = Melody.GetTetrisA(140);

        if (args.Length > 0 && (args[0] == "-a" || args[0] == "-anim"))
        {
            var (left, top) = Console.GetCursorPosition();

            //await Anim(left, top);
            //await Play(melody, false);

            var animTask = Anim(left, top, 4);
            var playTask = Play(melody, false);

            await animTask;
            await playTask;
        }
        else if (args.Length > 0 && (args[0] == "-v" || args[0] == "-verbose"))
        {
            _ = Play(melody, true);
        }
        else
        {
            _ = Play(melody, false);
        }

        static async Task Anim(int left, int top, int loops = 1)
        {
            char[] frames = ['/', '—', '\\', '|'];
            for (int i = 0; i < loops; i++)
            {
                foreach (char frame in frames)
                {
                    Console.SetCursorPosition(left, top);
                    Console.Write(frame);
                    await Task.Delay(500);
                }
            }
        }

        static async Task Play(Melody melody, bool verbose = false)
        {
            var tune = melody.Tune;
            int mpsb = melody.Mpsb;

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
    }
}