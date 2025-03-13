namespace JukeboxProofOfConcept;

public class Melody((Tone, Note)[] tune, int bpm)
{
    public (Tone, Note)[] Tune { get; set; } = tune;
    public int Bpm { get; set; } = bpm;
    public int Mpsb => 1000 / (Bpm / 60) / 4; // Mps: Milliseconds per sixteenth beat

    public static Melody GetTetrisA(int bpm = 140)
    {
        (Tone, Note)[] tune =
        [
            (Tone.E5, Note.Quarter),
            (Tone.B4, Note.Eighth),
            (Tone.C5, Note.Eighth),
            (Tone.D5, Note.Quarter),
            (Tone.C5, Note.Eighth),
            (Tone.B4, Note.Eighth),

            (Tone.A4, Note.Quarter),
            (Tone.A4, Note.Eighth),
            (Tone.C5, Note.Eighth),
            (Tone.E5, Note.Quarter),
            (Tone.D5, Note.Eighth),
            (Tone.C5, Note.Eighth),

            (Tone.B4, Note.QuarterHalf),
            (Tone.C5, Note.Eighth),
            (Tone.D5, Note.Quarter),
            (Tone.E5, Note.Quarter),

            (Tone.C5, Note.Quarter),
            (Tone.A4, Note.Quarter),
            (Tone.A4, Note.Quarter),
            (Tone.QuarterRest, Note.Quarter),

        ];

        return new Melody(tune, bpm);
    }
}