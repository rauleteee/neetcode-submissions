public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int left = 0;
        int right = numbers.Length - 1;

        while(left < right){
            int sum = numbers[left] + numbers[right];

            if (sum == target) {
                // 1-indexed, so add 1 to each!!!
                return new int[] { left + 1, right + 1 };
            }
            else if(sum < target){
                left++;//sum too small -> grow it
            }
            else{
                right--; //sum too big -> shrink it
            }
        }
        return new int[] { };  // problem guarantees a solution, so we never reach here
    }
}
