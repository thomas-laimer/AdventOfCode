using System.Collections;
using System.Diagnostics;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

// The restrictions about which page has to appear before which can be described as a directed, 
// nonweighted graph. A topological sort yields a (in this case: _the_) valid page order.
// This can then be compared to the provided updates.

public class Day5
{
    private record Input((int Before, int After)[] PageOrder, int[][] Updates)
    {
        public static Input Parse(string input) {
            var parts = InputParser.Normalize(input).Split(Environment.NewLine + Environment.NewLine);
            Debug.Assert(parts.Length == 2);
            var rulesList = parts[0].SplitLines()
                                    .Select(line => line.Split('|').Select(int.Parse).ToArray())
                                    .Select(line => (line[0], line[1])) 
                                    .ToArray();
        
            var updates = InputParser.ParseIntLists(parts[1]);
            return new Input(rulesList, updates);
        }
    }
    
    public static int Part1 (string input) {
        var (rulesList, updates) = Input.Parse(input);
        var sum = 0;
        foreach (var pages in updates) {
            var relevantRules = rulesList.Where(rule => pages.Contains(rule.Item1) &&
                                                        pages.Contains(rule.Item2))
                                         .ToArray();
            var validOrder = Graph.TopologicalSort(relevantRules).ToArray();
            if (pages.SequenceEqual(validOrder)) {
                var middlePage = pages[pages.Length / 2];
                sum += middlePage;
            }
        }
        return sum;
    }
    public static int Part2 (string input) {
        var (rulesList, updates) = Input.Parse(input);
        var sum = 0;
        foreach (var pages in updates) {
            var relevantRules = rulesList.Where(rule => pages.Contains(rule.Item1) &&
                                                        pages.Contains(rule.Item2))
                                         .ToArray();
            var validOrder = Graph.TopologicalSort(relevantRules).ToArray();
            if (!pages.SequenceEqual(validOrder)) {
                var middlePage = validOrder[validOrder.Length / 2];
                sum += middlePage;
            }
        }
        return sum;
    }
}