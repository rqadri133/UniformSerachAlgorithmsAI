public class BFS
{
    public List<int> Search(Graph graph, int start, int goal)
    {
        var visited = new HashSet<int>();
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int> { start });

        while (queue.Count > 0)
        {
            var path = queue.Dequeue();
            int node = path[path.Count - 1];

            if (node == goal)
                return path;

            if (!visited.Contains(node))
            {
                visited.Add(node);
                foreach (var neighbor in graph.GetNeighbors(node))
                {
                    var newPath = new List<int>(path) { neighbor };
                    queue.Enqueue(newPath);
                }
            }
        }
        return null; // No path found
    }
}
    