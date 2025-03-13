using System.Dynamic;

namespace JukeboxProofOfConcept;


public class JukeboxProofOfConcept
{
    static void Main(string[] args)
    {
        Melody melody = Melody.GetTetrisA(70);

        var coords = Console.GetCursorPosition();

        // Console.CursorVisible = false;

        for (int i = 1; i <= 4; i++)
        {
            Console.SetCursorPosition(coords.Item1, coords.Item2);
            Console.Write(i);
            Thread.Sleep(melody.Mpsb);
        }

        Play(melody);
    }

    static void Play(Melody melody)
    {
        var tune = melody.Tune;
        int mpsb = melody.Mpsb;

        foreach (var tone in tune)
        {
            int freq = (int)tone.Item1;
            int time = (int)tone.Item2 * mpsb;

            if (freq >= 37)
                Console.Beep(freq, time);
            else
                Thread.Sleep(time);
        }
    }
}
