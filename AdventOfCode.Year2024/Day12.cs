using System.Diagnostics;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Transactions;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day12
{
    public static int Part1(string input)
    {
        var map = new Map<char>(InputParser.ParseCharMatrix(input));
        var regions = GetRegions(map);
        var price = 0;
        foreach (var region in regions)
        {
            var positions = region.ToArray(); // faster iteration 
            var top = positions.Count(pos => !region.Contains(pos.Up));
            var left = positions.Count(pos => !region.Contains(pos.Left));
            var right = positions.Count(pos => !region.Contains(pos.Right));
            var bottom = positions.Count(pos => !region.Contains(pos.Down));
            var perimeters = top + left + right + bottom;
            var area = region.Count;
            price += (perimeters * area);
        }

        return price;
    }

    public static int Part2(string input)
    {
        var map = new Map<char>(InputParser.ParseCharMatrix(input));
        var regions = GetRegions(map);
        var price = 0;
        foreach (var region in regions)
        {
            var edges = CountEdges(region);
            var regionPrice = edges * region.Count;
            price += regionPrice;
        }

        return price;
    }

    internal static int CountEdges(HashSet<MapPosition> region)
    {
        int edges = 0;
        bool InRegion(MapPosition pos) => region.Contains(pos);

        foreach (var pos in region)
        {
            bool isUp = InRegion(pos.Up),
                 isUpRight = InRegion(pos.UpRight),
                 isRight = InRegion(pos.Right),
                 isDownRight = InRegion(pos.DownRight),
                 isDown = InRegion(pos.Down),
                 isDownLeft = InRegion(pos.DownLeft),
                 isLeft = InRegion(pos.Left),
                 isUpLeft = InRegion(pos.UpLeft);
            if(!isUpLeft && isLeft && isUp) edges++;
            if(!isUpRight && isRight && isUp) edges++;
            if(!isDownRight && isRight && isDown) edges++;
            if(!isDownLeft && isLeft && isDown) edges++;
            if(!isUp && !isLeft) edges++;
            if(!isUp && !isRight) edges++;
            if(!isDown && !isLeft) edges++;
            if(!isDown && !isRight) edges++;
        }
        return edges;
    }
    
    internal static List<HashSet<MapPosition>> GetRegions(Map<char> map)
    {
        var regions = new List<HashSet<MapPosition>>();
        var notVisited = map.Positions.ToHashSet();
        do
        {
            var current = notVisited.First();
            notVisited.Remove(current);
            var region = map.FloodFill(current);
            notVisited.ExceptWith(region);
            regions.Add(region);
        } while (notVisited.Any());

        return regions;
    }
}