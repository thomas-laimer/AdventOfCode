using System.Collections.Generic;
namespace AdventOfCode.Core;

public static class Graph
{
    public static List<T> TopologicalSort<T>((T From, T To)[] edges) where T: struct {
        ArgumentNullException.ThrowIfNull(edges);
        var vertices = edges.Select(e => e.From)
                            .Concat(edges.Select(e => e.To))
                            .Distinct()
                            .ToArray();
        var graph = vertices.ToDictionary(v => v, _ => new List<T>());
        var inDegrees = vertices.ToDictionary(v => v, _ => 0);
        foreach (var edge in edges) {
            graph[edge.From].Add(edge.To);
            inDegrees[edge.To] += 1;
        }
        var sorted = new List<T>();
        var queue = inDegrees.Where(kv => kv.Value == 0).Select(kv => kv.Key).ToQueue();
        while (queue.TryDequeue(out var from)) {
            sorted.Add(from);
            foreach (var target in graph[from]) {
                var inDegree = inDegrees[target] -= 1;
                if (inDegree == 0) {
                    queue.Enqueue(target);
                }
            }
        }
        return sorted;
    }
}