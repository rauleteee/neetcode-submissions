public class PrefixTree {

    private class Node {
        public Node[] children = new Node[26];
        public bool isEnd = false;
    }

    private Node root;

    public PrefixTree() {
       root = new Node();
    }
    
    public void Insert(string word) {
        Node curr = root;
        foreach(char c in word) {
            int i = c - 'a'; //this gives you the position in the dictionary for that letter e.g: a=0, b=1,...
            if(curr.children[i] == null) curr.children[i] = new Node();
            curr = curr.children[i];
        }
        curr.isEnd = true; //mark the end of a full word
    }
    
    public bool Search(string word) {
        Node node = Find(word);
        return node != null && node.isEnd; // path exists AND is a word
    }
    
    public bool StartsWith(string prefix) {
        return Find(prefix) != null;
    }

    private Node Find(string s) {
        // Walk the letters; return the final node, or null if the path breaks
        Node curr = root;
        foreach(char c in s) {
            int i = c - 'a';
            if(curr.children[i] == null) return null;
            curr = curr.children[i];
        }
        return curr;
    }
}
