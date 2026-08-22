public class Solution {
    public int MaxProfit(int[] prices) {
        int max = 0; // best profit so far
        int min = int.MaxValue; //cheapest price seen so far

        foreach(int price in prices) {
            if(price < min)
                min = price; // found a cheaper day to buy
            else if (price - min > max) {
                max = price - min; // selling today beats our best
            }
        }
        return max;
    }
}
