using System;
using System.Collections.Generic;

public class Graph
{
    public Dictionary<int, List<int>> adjList;

    public Graph()
    {
        adjList = new Dictionary<int, List<int>>();
    }

    public void AddEdge(int from, int to)
    {
        if (!adjList.ContainsKey(from))
            adjList[from] = new List<int>();

        adjList[from].Add(to);
    }

    public List<int> GetNeighbors(int node)
    {
        return adjList.ContainsKey(node) ? adjList[node] : new List<int>();
    }
}


public class UCS
{
    public List<int> Search(Graph graph, int start, int goal)
    {
        var visited = new Dictionary<int, int>(); // node -> cost
        var priorityQueue = new SortedSet<(int cost, List<int> path)>(Comparer<(int cost, List<int> path)>.Create((x, y) => x.cost.CompareTo(y.cost)));

        priorityQueue.Add((0, new List<int> { start }));

        while (priorityQueue.Count > 0)
        {
            var (cost, path) = priorityQueue.Min;
            priorityQueue.Remove(priorityQueue.Min);
            int node = path[path.Count - 1];

            if (node == goal)
                return path;

            if (!visited.ContainsKey(node) || visited[node] > cost)
            {
                visited[node] = cost;
                foreach (var neighbor in graph.GetNeighbors(node))
                {
                    var newCost = cost + 1; // Assuming each edge has a cost of 1
                    var newPath = new List<int>(path) { neighbor };
                    priorityQueue.Add((newCost, newPath));
                }
            }
        }
        return null; // No path found
    }
}

public class DFS
{
    public List<int> Search(Graph graph, int start, int goal)
    {
        var visited = new HashSet<int>();
        var stack = new Stack<List<int>>();
        stack.Push(new List<int> { start });

        while (stack.Count > 0)
        {
            var path = stack.Pop();
            int node = path[path.Count - 1];

            if (node == goal)
                return path;

            if (!visited.Contains(node))
            {
                visited.Add(node);
                foreach (var neighbor in graph.GetNeighbors(node))
                {
                    var newPath = new List<int>(path) { neighbor };
                    stack.Push(newPath);
                }
            }
        }
        return null; // No path found
    }
}
