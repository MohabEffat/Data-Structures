
public class Main {
    public static void main(String[] args) {

        StackLinkedListBased<String> stackL = new StackLinkedListBased<>(true);
        stackL.Push("Hello");
        stackL.Push("World");
        stackL.Push("!");
        // while (!stackL.isEmpty()) {
        // System.out.println(stackL.pop());
        // }
        stackL.printStack();
        // StackLinkedListBased<Integer> stack= new StackLinkedListBased<>(true);
        System.out.println("-----------------------------------------------");
        StackArrayBased<Integer> stackA = new StackArrayBased<>(5);
        stackA.push(1);
        stackA.push(2);
        stackA.push(3);
        stackA.push(4);
        stackA.push(5);
        stackA.push(6);
        stackA.push(7);
        stackA.push(8);
        stackA.push(9);
        stackA.push(10);
        // while (!stackA.isEmpty()) {
        // System.out.println(stackA.pop());
        // }
        // System.out.println("-----------------------------------------------");

    }
}