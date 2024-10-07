using System;
using System.Collections.Generic;

namespace Matryoshka
{
    class Program
    {
        static void Main(string[] args)
        {
            MatryoshkaDoll largestDoll = CreateDolls(24);

            List<MatryoshkaDoll> linedUpDolls = UnstackDolls(largestDoll);

            Console.WriteLine($"Total number of dolls: {CountDolls(linedUpDolls)}");
            Console.WriteLine("Dolls lined up from largest to smallest:");
            foreach (var doll in linedUpDolls)
            {
                Console.WriteLine($"Matryoshka Doll {doll.Size}");
            }
        }

        static MatryoshkaDoll CreateDolls(int count)
        {
            MatryoshkaDoll largestDoll = null;
            MatryoshkaDoll currentDoll = null;

            for (int i = count; i >= 1; i--)
            {
                var newDoll = new MatryoshkaDoll(i);
                if (largestDoll == null)
                {
                    largestDoll = newDoll;
                }
                else
                {
                    currentDoll.SmallerDoll = newDoll;
                }
                currentDoll = newDoll;
            }

            return largestDoll;
        }

        static List<MatryoshkaDoll> UnstackDolls(MatryoshkaDoll largestDoll)
        {
            List<MatryoshkaDoll> dolls = new List<MatryoshkaDoll>();
            MatryoshkaDoll currentDoll = largestDoll;

            while (currentDoll != null)
            {
                dolls.Add(currentDoll);
                currentDoll = currentDoll.SmallerDoll;
            }

            return dolls;
        }

        static int CountDolls(List<MatryoshkaDoll> dolls)
        {
            return dolls.Count;
        }
    }

    class MatryoshkaDoll
    {
        public int Size { get; private set; }
        public MatryoshkaDoll SmallerDoll { get; set; }

        public MatryoshkaDoll(int size)
        {
            Size = size;
        }
    }
}
