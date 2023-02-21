namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StackOfStrings stack= new StackOfStrings();
            stack.Push("1");
            stack.Pop();
            Console.WriteLine(stack.IsEmpty());
            
        }
    }
}
