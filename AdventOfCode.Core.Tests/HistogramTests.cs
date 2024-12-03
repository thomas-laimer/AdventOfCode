namespace AdventOfCode.Core.Tests;

public class HistogramTests
{
    [Test,Parallelizable]
    public void TestHistogram() {
        int[] values = [1, 2, 2, 3, 3, 3];
        var histogram = Histogram.Compute(values);
        Assert.That(histogram[1], Is.EqualTo(1));
        Assert.That(histogram[2], Is.EqualTo(2));
        Assert.That(histogram[3], Is.EqualTo(3));
        Assert.That(histogram[4], Is.EqualTo(0));
    }
}