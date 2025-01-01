
        var graph = new Graph();
        graph.AddEdge(0, 1);
        graph.AddEdge(0, 2);
        graph.AddEdge(1, 3);
        graph.AddEdge(2, 3);
        graph.AddEdge(3, 4);
        graph.AddEdge(4, 5);

        int start = 0;
        int goal = 5;

        // BFS
        var bfs = new BFS();
        var bfsPath = bfs.Search(graph, start, goal);
        Console.WriteLine("BFS Path: " + (bfsPath != null ? string.Join(" -> ", bfsPath) : "No path found"));

        // DFS
        var dfs = new DFS();
        var dfsPath = dfs.Search(graph, start, goal);
        Console.WriteLine("DFS Path: " + (dfsPath != null ? string.Join(" -> ", dfsPath) : "No path found"));

        // UCS
        var ucs = new UCS();
        var ucsPath = ucs.Search(graph, start, goal);
        Console.WriteLine("UCS Path: " + (ucsPath != null ? string.Join(" -> ", ucsPath) : "No path found"));

        /* Depth-Limited Search
        var dls = new DepthLimitedSearch();
        var dlsPath = dls.Search(graph, start, goal, 3);
        Console.WriteLine("Depth-Limited Search Path: " + (dlsPath != null ? string.Join(" -> ", dlsPath) : "No path found"));

        // IDDFS
        var iddfs = new IDDFS();
        var iddfsPath = iddfs.Search(graph, start, goal, 3);
        Console.WriteLine("IDDFS Path: " + (iddfsPath != null ? string.Join(" -> ", iddfsPath) : "No path found"));
  */