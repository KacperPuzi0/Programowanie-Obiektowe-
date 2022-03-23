
    internal class Program
    {
        class Stack<T>
        {
            private T[] _arr = new T[10];
            private int last = -1;
            public void Push(T item)
            {
                _arr[++last] = item;
            }
        }

        class Person
        {

        }

        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            Stack<string> stack2 = new Stack<string>();
            stack2.Push("aaa");
            ValueTuple<string, decimal, int> product = ValueTuple.Create("laptop", 1200m, 2);
            (string, decimal, int) tuple = product;
            tuple = ("laptop", 1200m, 2);
            Console.WriteLine(product);
            var tuple1 = (name: "laptop", price: 1200m, quantity: 2);
            Console.WriteLine(tuple1 == product);
        }
    }