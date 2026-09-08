public class Solution {
    private List<int>[] graph;
    private int[] state; // 0 = unvisited; 1 = visiting; 2 = donde

    public bool CanFinish(int numCourses, int[][] prerequisites) {
        /*
        BUILD GRAPH + INDEGREE
        -graph[c] = list of courses that c unlocks (courses that need c as a prereq)
        -indegree[c] = how many prerequs course c still needs before it can be taken
        Example: numCourses=3; prerequisites=[[0,1], [2,1]]
        - 0 needs course 1, 1 unlocks 0, so 0 needs +1 prereq
        - 2 needs course 1, 1 unlocks 2, so 2 needs +1 prereq
        */
        List<int>[] graph = new List<int>[numCourses];
        for (int i = 0; i < numCourses; i++) graph[i] = new List<int>();
        int[] indegree = new int[numCourses];

        foreach(var pair in prerequisites) {
            // pair[0] needs pair[1] -> pair[1] points to (unlocks) pair[0]
            graph[pair[1]].Add(pair[0]); // graph[1] = [0,2]
            indegree[pair[0]]++; // indegree[0] = 1; indegree[2] = 1; indegree[1]= 0
        }
        // After this: graph[1]=[0,2], graph[0]=[], graph[2]=[], indegree=[1,0,1] You need 1 course to take the number 0, you need 0 courses to take the number 1 and you need 1 course to take the number 2
        // SEED QUEUE WITH READY COURSES (indegree 0)
        // A course with indegree 0 needs no prereqs, so we can take it right now
        Queue<int> queue = new Queue<int>();
        for (int i = 0; i < numCourses; i++) {
            if (indegree[i] == 0) queue.Enqueue(i);
        }

        // TAKE COURSES, UNLOCK DEPENDENTS
        int taken = 0;
        while(queue.Count > 0) {
            // how many courses we've managed to take
            int course = queue.Dequeue();
            taken++;

            // taking course removes it as a prereq for everything it unlocks
            foreach (int next in graph[course]) {
                indegree[next]--; // e.g. indegree[0]: 1->0, indegree[2]: 1->0
                if(indegree[next] == 0)
                    queue.Enqueue(next);
            }
        }

        // FINAL CHECK
        // If we take every course there was no cycle -> true
        // If we got stuck (taken < numCourses) a cycle blocked some courses -> false
        // Cycle example: prerequisites=[[0,1],[1,0]]  ->  indegree=[1,1], queue starts EMPTY,
        //   loop never runs, taken=0, 0 != 2  ->  return false
        return taken == numCourses;
    }
}
