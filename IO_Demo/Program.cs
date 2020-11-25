using System;
using System.IO;

namespace IO_Demo
{
    class Program
    {
        const string path = @"C:\Users\hakan\OneDrive\Desktop\Space distances.txt";

        static void Main(string[] args)
        {
            // StreamReader
            string[] lines = new string[1000];
            int index = -1;

            using (StreamReader sr = new StreamReader(path))
                while (!sr.EndOfStream)
                    lines[++index] = sr.ReadLine();

            for (int i = index; index - i <= index; i--)
                Console.WriteLine($"{index - i + 1, 2}: {lines[index - i]}");

            // StreamWriter
            lines[++index] = "The End Again";

            for (int i = index; i > -1; i--)
                lines[i + 1] = lines[i];

            index++;

            lines[0] = "The Beginning";

            using (StreamWriter sw = new StreamWriter(path))
                for (int i = index; index - i <= index; i--)
                    sw.WriteLine(lines[index - i]);
        }
    }
}
