public class Solution {
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        // Kahn's algorithm
        List<int>[] graph = new List<int>[numCourses];
        for(int i = 0; i < numCourses; i++) graph[i] = new List<int>();
        int[] indegree = new int[numCourses];

        foreach(var p in prerequisites) {
            graph[p[1]].Add(p[0]); // p1 unlocks p0
            indegree[p[0]]++;

        }

        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) queue.Enqueue(i);
        }

        int[] order = new int[numCourses];
        int taken = 0;

        while (queue.Count > 0) {

            int course = queue.Dequeue();
            order[taken++] = course; // record the order taken

            foreach (int next in graph[course]) {
                
                indegree[next]--;

                if(indegree[next] == 0) 
                    queue.Enqueue(next);
            }
        }

        return taken == numCourses ? order : new int[0];
    }
}
