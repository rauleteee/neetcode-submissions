public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        // search speed starts at 1 to the max number of bananas of the entire pile
        int left = 1;
        int right = 0;
        foreach(int bananas in piles) {
            right = Math.Max(right, bananas);
        }

        int answer = right; // we start the right pointer as the maximum speed that we need, but we want the minimum.
        while (left <= right) {

            int k = left + (right - left) / 2; // mid, how many bananas per hour we need
            // count the hours needed at speed k
            long hours = 0;
            foreach(int bananas in piles) {
                hours += (bananas + k - 1) / k; // (bananas + bananas/h)/bananas/h
            }

            // Now decide which half to search
            if(hours <= h) {
                answer = k; // speed k works -> search a slower one
                right = k - 1;
            } else {
                left = k + 1; // too slow -> need a k faster
            }

        }
        return answer;
    }
}
