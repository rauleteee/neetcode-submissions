public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {

        Dictionary<int,int> count = new Dictionary<int, int>();
   
        // Count how many times appears each number
        foreach( int n in nums){
            if(count.ContainsKey(n)){
                count[n]++;
            } else {
                count[n] = 1;
            }
        }
        // Sort the keys by count descending, take the first "k" keys
        List<int> keys = new List<int>(count.Keys);
        keys.Sort((a,b) => count[b] - count[a]); // descending by count

        // take the first K
        int[] result = new int[k];
        for(int i = 0; i < k; i++){
            result[i] = keys [i];
        }
        return result;
    }
}
