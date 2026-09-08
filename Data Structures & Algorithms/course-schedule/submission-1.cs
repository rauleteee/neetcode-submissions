public class Solution {
    private List<int>[] graph;
    private int[] state; // 0 = unvisited; 1 = visiting; 2 = donde

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        // Build the graph (a list of prerequisites for each course) 
        graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++){ graph[i] = new List<int>(); }
        foreach(var pair in prerequisites) {
            graph[pair[0]].Add(pair[1]); // course pair[0] needs pair[1] 
        }

        state = new int[numCourses];
        for (int i = 0; i < numCourses; i++) {
            if(HasCycle(i)){
                return false;
            }
        }
        return true;
    }
    // dfs: return true if a cycle is found starting from this course
    private bool HasCycle(int course){
        if (state[course] == 1) return true; // git a "visiting" node -> cycle
        if (state[course] == 2) return false; // already done, safe -> no cycle here

        // mark visiting 
        state[course] = 1;
        foreach(int need in graph[course]) {
            if(HasCycle(need)) return true; // cycle found deeper -> pass it up
        }

        state[course] = 2; // mark done, fully checked safe
        return false;
    }
}
