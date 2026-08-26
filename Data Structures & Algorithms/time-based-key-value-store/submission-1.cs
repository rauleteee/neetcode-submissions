public class TimeMap {

    private Dictionary<string, List<(string value, int time)>> store;

    public TimeMap() {
        store = new Dictionary<string, List<(string, int)>>();
    }
    
    public void Set(string key, string value, int timestamp) {
        if(!store.ContainsKey(key)) {
            store[key] = new List<(string, int)>();
        }
        store[key].Add((value, timestamp));
    }
    
    public string Get(string key, int timestamp) {
        if (!store.ContainsKey(key)) return "";

        List<(string value, int time)> list = store[key];
        string result = "";

        // then binary search
        int left = 0;
        int right = list.Count - 1;
        
        while (left <= right) {
            int mid = left + (right - left) / 2;

            if(list[mid].time <= timestamp) {
                result = list[mid].value;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return result;
    }
}
