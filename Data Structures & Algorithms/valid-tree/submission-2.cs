public class Solution {
    public bool ValidTree(int n, int[][] edges) {
/*A graph is a valid tree if it satisfies two conditions:

- Exactly n - 1 edges (a tree with n nodes always has n-1 edges — fewer means disconnected, more means a cycle).
- Fully connected (all nodes reachable from node 0).


*/
        if (edges.Length != n - 1) return false; // must have exactly n - 1 edges

        List<int>[] graph = new List<int>[n];
        for(int i = 0; i < n; i++) graph[i] = new List<int>();
        foreach(var e in edges) {
            graph[e[0]].Add(e[1]); // undirected -> both ways
            graph[e[1]].Add(e[0]); // undirected -> both ways
        }

        HashSet<int> visited = new HashSet<int>();
        Dfs(0, graph, visited);

        return visited.Count == n; // all nodes reachable -> connected -> valid tree
    }

    private void Dfs(int node, List<int>[] graph, HashSet<int> visited) {
        if(visited.Contains(node)) return;
        visited.Add(node);
        foreach(int neighbor in graph[node]) {
            Dfs(neighbor, graph, visited);
        }
    }
}
