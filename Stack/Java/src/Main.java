
public class Main {
    public static void main(String[] args) {

        Stack stack = new Stack(true);
        System.out.println("Is Empty : " + stack.isEmpty());
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        System.out.println("Is Empty : " + stack.isEmpty());
        stack.printStack();
        stack.printStack();
        stack.peek();
        System.out.println(stack.peek());
        System.out.println("Size : " + stack.GetLen());
        while(!stack.isEmpty()){
            stack.Pop();
            stack.printStack();
        }
        System.out.println("-----------------------------------------------");

        stackArray stackA = new stackArray();
        stackA.push(10);
        stackA.push(20);
        stackA.push(30);
        stackA.push(40);
        stackA.push(50);
        stackA.push(50);
        stackA.push(100);
        stackA.push(100);
        stackA.push(10);
        stackA.push(20);
        stackA.push(30);
        stackA.push(40);
        stackA.push(50);
        stackA.push(50);
        stackA.push(100);
        stackA.push(100);
        System.out.println("The Size is: " + stackA.size());
        while(!stackA.isEmpty()){
            int value = stackA.pop();
            System.out.println("The Value: " + value);
        }
        System.out.println(stackA.isEmpty());
        System.out.println("The Size is: " + stackA.size());

    }
}