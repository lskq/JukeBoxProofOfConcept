using System.Dynamic;

namespace JukeboxProofOfConcept;


public class JukeboxProofOfConcept
{
    static void Main(string[] args)
    {
        Melody melody = Melody.GetTetrisA(140);

        Play(melody, true);
    }

    static void Play(Melody melody, bool verbose = false)
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
    }
}
