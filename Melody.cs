namespace JukeboxProofOfConcept;

public class Melody((Tone, Note)[] tune, int bpm)
{
    public (Tone, Note)[] Tune { get; set; } = tune;
    public int Bpm { get; set; } = bpm;
    public int Mpsb => 1000 / (Bpm / 60) / 16; // Mps: Milliseconds per sixteenth beat

    public static Melody GetTetrisA(int bpm = 140)
    {
        (Tone, Note)[] tune =
        [
            (Tone.E5, Note.Quarter),
            (Tone.E4, Note.Eighth),
            (Tone.B4, Note.Eighth),
            (Tone.C5, Note.Eighth),
            (Tone.D5, Note.Sixteenth),
            (Tone.E5, Note.Sixteenth),
            (Tone.C5, Note.Eighth),
            (Tone.B4, Note.Eighth),

            (Tone.A4, Note.Quarter),
            (Tone.E4, Note.Eighth),
            (Tone.A4, Note.Eighth),
            (Tone.C5, Note.Quarter),
            (Tone.E5, Note.Eighth),
            (Tone.E4, Note.Eighth),

            (Tone.D5, Note.Quarter),
            (Tone.C5, Note.Eighth),
            (Tone.B4, Note.Eighth),
            (Tone.E4, Note.Quarter),
            (Tone.B4, Note.Quarter),

            (Tone.C5, Note.Quarter),
            (Tone.D5, Note.Quarter),
            (Tone.E4, Note.Quarter),
            (Tone.QuarterRest, Note.Quarter),

            (Tone.E5, Note.Quarter),
            (Tone.E4, Note.Quarter),
            (Tone.C5, Note.Quarter),
            (Tone.E4, Note.Eighth),
            (Tone.A4, Note.Eighth),

            (Tone.E4, Note.Quarter),
            (Tone.A4, Note.Quarter),
            (Tone.E4, Note.Quarter),
            (Tone.C4, Note.Eighth),
            (Tone.E4, Note.Eighth),

            (Tone.D3, Note.Quarter),
            (Tone.D5, Note.Eighth),
            (Tone.D4, Note.Eighth),
            (Tone.F5, Note.Quarter),
            (Tone.A5, Note.Quarter),

            (Tone.F4, Note.Quarter),
            (Tone.G5, Note.Quarter),
            (Tone.QuarterRest, Note.Quarter),
        ];

        return new Melody(tune, bpm);
    }
}