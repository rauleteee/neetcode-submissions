public class LRUCache {
    private class Node {
        // A node in the Double Linked List
        public int key;
        public int value;
        public Node prev;
        public Node next;
        public Node (int key, int value) {
            this.key = key;
            this.value = value;
        }
    }

    private Dictionary <int, Node> map; // key -> Node
    private Node head; // dummy head (least recent)
    private Node tail; // dummy tail (most recent)
    private int capacity;

    public LRUCache(int capacity) {
        this.capacity = capacity;
        map = new Dictionary<int, Node>();

        // Set up the two dummy nodes linked to each other
        head = new Node(0,0);
        tail = new Node(0,0);
        head.next = tail;
        tail.next = head; // double loop linked list head >< tail
    }

    // Remove a node from the list (unlink it from its neighbours)
    private void Remove(Node node) {
        node.prev.next = node.next;
        node.next.prev = node.prev;

    }

    // Insert a node right after head (the most recent position)
    private void InsertFront(Node node) { // *
        node.next = head.next;
        node.prev = head;
        head.next.prev = node;
        head.next = node;
    }

    
    public int Get(int key) {
        if (!map.ContainsKey(key)) return -1;
        
        Node node = map[key];
        Remove(node); // take it out from its current position
        InsertFront(node); // insert it as most recent in the cache
        
        return node.value;
    }
    
    public void Put(int key, int value) {

        if (map.ContainsKey(key)) {
            // key exists -> update its value and move to the front
            Node node = map[key];
            node.value = value;
            Remove(node);
            InsertFront(node);
        } else {
            // New key -> remove Least Recently Used node and add it to the front
            if (map.Count == capacity) {
                Node lru = tail.prev; // least recent real node *
                Remove(lru);
                map.Remove(lru.key);
            }
            // Add the new node at the front
            Node newNode = new Node(key, value);
            map[key] = newNode;
            InsertFront(newNode);
        }
    }
}
