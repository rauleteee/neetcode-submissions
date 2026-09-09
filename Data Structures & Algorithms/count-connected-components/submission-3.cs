public class Solution {
    public int CountComponents(int n, int[][] edges) {
        List<int>[] graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<int>();
        foreach (var e in edges) {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        HashSet<int> visited = new HashSet<int>();
        int components = 0;

        // Walk every node; each unvisited one starts a new component
        for(int i = 0; i < n; i++) {
            if(!visited.Contains(i)) {
                components++; // new component
                Dfs(i, graph, visited);
            }
        }
        return components;
    }

    private void Dfs(int node, List<int>[] graph, HashSet<int> visited) {
        if (visited.Contains(node)) return;
        visited.Add(node);
        foreach(int neighbor in graph[node])
            Dfs(neighbor, graph, visited);
    }
}
