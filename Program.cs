using System.Threading.Tasks;

namespace JukeboxProofOfConcept;


public class JukeboxProofOfConcept
{
    static async Task Main(string[] args)
    {
        Melody melody = Melody.GetTetrisA(140);
        bool verbose = false;

        if (args.Length > 0 && args.Contains("-v") || args.Contains("-verbose"))
        {
            verbose = true;
        }
        if (args.Length > 0 && args.Contains("-a") || args.Contains("-async"))
        {
            bool done = false;

            done = await AsyncPlay(melody, verbose);

            var coords = Console.GetCursorPosition();

            if (!verbose)
                do { Anim(coords.Left, coords.Top); } while (!done);
        }
        else
        {
            _ = Play(melody, verbose);
        }
    }

    static void Anim(int left, int top)
    {
        char[] frames = ['/', '—', '\\', '|'];

        foreach (char frame in frames)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(frame);
            Thread.Sleep(500);
        }
    }

    static async Task<bool> AsyncPlay(Melody melody, bool verbose = false)
    {
        return await Task.Run(() => Play(melody, verbose));
    }

    static bool Play(Melody melody, bool verbose = false)
    {
        try
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
                    Thread.Sleep(time);
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
