public class Twitter {

    private int timestamp;
    private Dictionary<int, List<(int time, int tweetId)>> tweets; //user->tweet
    private Dictionary<int, HashSet<int>> following; // user -> who they follow

    public Twitter() {
        timestamp = 0;
        tweets = new Dictionary<int, List<(int, int)>>();
        following = new Dictionary<int, HashSet<int>>();
    }
    
    public void PostTweet(int userId, int tweetId) {
        if(!tweets.ContainsKey(userId)) {
            tweets[userId] = new List<(int, int)>();
        }

        tweets[userId].Add((timestamp, tweetId)); // mark the tweer qtih unique timestamp
        timestamp++;
        
    }
    
    public List<int> GetNewsFeed(int userId) {
        // Max-heap: get the least recent tweets
        PriorityQueue<int, int> maxHeap = new PriorityQueue<int, int>();

        // Build the list of people whose tweets count: the user + everyone they follow
        List<int> people = new List<int>();
        people.Add(userId); // the user's own tweets
        if(following.ContainsKey(userId)) {
            foreach(int followeeId in following[userId]) {
                people.Add(followeeId); // people = [userId, followee1, followee2...]
            }
        }

        // Put all their tweets in the heap and put the least recent first
        foreach(int personId in people) {
            if (tweets.ContainsKey(personId)) {
                foreach(var tweet in tweets[personId]) {
                    maxHeap.Enqueue(tweet.tweetId, -tweet.time);
                }
            }
        }

        // Take the 10 newest
        List<int> result = new List<int>();
        while (maxHeap.Count > 0 && result.Count < 10) {
            result.Add(maxHeap.Dequeue());
        }

        return result;
    }
    
    public void Follow(int followerId, int followeeId) {
        if(!following.ContainsKey(followerId)) {
            following[followerId] = new HashSet<int>();
        }

        following[followerId].Add(followeeId);  
    }
    
    public void Unfollow(int followerId, int followeeId) {
        if(following.ContainsKey(followerId))
            following[followerId].Remove(followeeId);
    }
}
