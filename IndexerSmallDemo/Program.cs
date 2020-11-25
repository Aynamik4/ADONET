using System;

namespace IndexerSmallDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();

            list[true] = "Håkan";
            list[false] = "N/A";

            Console.WriteLine(list[true]);
            Console.WriteLine(list[false]);
        }
    }
}
