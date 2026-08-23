public class MinStack {
    // Two stacks that always move together:
    private Stack<int> stack;     // holds ALL the values (the normal stack)
    private Stack<int> minStack;  // holds the MINIMUM so far at each level

    // CONSTRUCTOR: runs once when you create the object.
    // It prepares both stacks so they start empty.
    public MinStack() {
        stack = new Stack<int>();     // empty main stack
        minStack = new Stack<int>();  // empty min stack
    }

    // PUSH: add a new value on top.
    public void Push(int val) {
        // Step 1: put the value on the main stack, like a normal push.
        stack.Push(val);

        // Step 2: update the min stack so its top is the new minimum.
        if (minStack.Count == 0) {
            // If the min stack is empty, this is the first value,
            // so it is automatically the minimum.
            minStack.Push(val);
        } else {
            // Otherwise, the new minimum is the smaller of:
            //   - the value we are pushing (val)
            //   - the current minimum (minStack.Peek() = top of min stack)
            // We push that smaller number onto the min stack.
            minStack.Push(Math.Min(val, minStack.Peek()));
        }
    }

    // POP: remove the top value.
    public void Pop() {
        // Remove from BOTH stacks at the same time.
        // This keeps them in sync: every level in 'stack' has a
        // matching level in 'minStack'.
        stack.Pop();
        minStack.Pop();
    }

    // TOP: read the top value WITHOUT removing it.
    public int Top() {
        // Peek() looks at the top of the main stack and returns it.
        return stack.Peek();
    }

    // GETMIN: read the smallest value in the whole stack, instantly.
    public int GetMin() {
        // The top of the min stack is ALWAYS the current minimum,
        // because we kept it updated on every push.
        // So we just read it — no searching needed.
        return minStack.Peek();
    }
}