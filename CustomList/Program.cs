using System;

namespace CustomList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList<int> MyList = new CustomList<int>();
            MyList.Add(5);
            MyList.Add(7);
            Console.WriteLine(MyList.Count);
        }
    }
}

