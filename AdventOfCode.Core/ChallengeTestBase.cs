namespace AdventOfCode.Core;

public class ChallengeTestBase
{
    protected string SampleInput { get; private set; }

    public ChallengeTestBase(string sampleInput) {
        ArgumentNullException.ThrowIfNull(sampleInput);
        SampleInput = sampleInput;
    }
}