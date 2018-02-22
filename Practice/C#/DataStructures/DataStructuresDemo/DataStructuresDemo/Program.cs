using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("This program is solely for demonstrating my understanding of basic algorithms and data structures by solving some coding challenges");

            // Problem 1 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Using Recursion to find the Power Set of a Set. Traversing a Tree
            // 
            List<string> inputSet = new List<string>()
            {
                "Item1",
                "Item2",
                "Item3",
                "Item4"
            };
            Console.WriteLine("Problem 1: Power Set Tree Traversal Using Recursion:");
            Console.WriteLine("Input Tree: [" + string.Join(",", inputSet) + "]");

            List<List<string>> powerSet = new List<List<string>>();
            TraverseSet(new List<string>(), 0, inputSet, powerSet);

            Console.WriteLine("Power Set:");
            powerSet.ForEach(i => Console.WriteLine( "[" + string.Join(",",i) + "]"));
            
            Console.WriteLine();

            // Problem 2 --------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            // Basic Merge Sort
            Console.WriteLine("Problem 2: Looping Merge Sort Basic");
            Random randomNumber = new Random();
            int[] inputSet2 = new int[20];
            for(int i = 0; i < inputSet2.Length; i++)
            {
                inputSet2[i] = randomNumber.Next(0,20);
            }
            List<int> correctAnswer = inputSet2.ToList();
            correctAnswer.Sort();

            Console.WriteLine("Input Set:");
            Console.WriteLine( string.Join(",", inputSet2));
            LoopingMergeSort(inputSet2);
            Console.WriteLine("Merge Sorted Set:");
            Console.WriteLine(string.Join(",", inputSet2));
            Console.WriteLine("Correct Answer:");
            Console.WriteLine(string.Join(",", correctAnswer));

            Console.Read();
        }

        /// <summary>
        /// Problem 1 Solution. Using recursion, one can easily find the power set of a set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentSet"></param>
        /// <param name="place"></param>
        /// <param name="inputSet"></param>
        /// <param name="powerSetList"></param>
        private static void TraverseSet<T>(List<T> currentSet, int place, List<T> inputSet, List<List<T>> powerSetList)
        {
            if (currentSet == null || inputSet == null || powerSetList == null)
                throw new Exception("Invalid Inputs Problem 1");

            List<T> currentSetCopy = new List<T>(currentSet);

            // Add current Set to Power Set List if at the bottom of the tree
            if (place == inputSet.Count())
            {
                powerSetList.Add(currentSetCopy);
                return;
            }
            
            int next = place + 1;

            // Traverse Left (If Item would not be in the set)
            TraverseSet(currentSetCopy, next, inputSet, powerSetList);
            
            // Traverse Right (If Item would be in the set)
            currentSetCopy.Add(inputSet[place]);
            TraverseSet(currentSetCopy, next, inputSet, powerSetList);
        }

        /// <summary>
        /// Problem 2 Solution. Basic Looping Merge Sort
        /// </summary>
        /// <param name="items"></param>
        private static void LoopingMergeSort(int[] items)
        {
            int gapSize = 1;
            int pairPos = 0;

            // Merge Levels
            while(gapSize < items.Count())
            {
                // Merge items in level
                while (pairPos < items.Count())
                {
                    //Console.WriteLine("Pair:" + pairPos + "," + (pairPos + gapSize ));
                    Merge(items, pairPos, pairPos + gapSize, pairPos +  (2*gapSize) - 1);

                    pairPos = pairPos + (2 * gapSize);
                }

                //Console.WriteLine("GAPSIZE:" + gapSize + " STATE: " + string.Join(",", items));
                pairPos = 0;
                gapSize = gapSize * 2;
            }
        }

        /// <summary>
        /// Merge for Problem 2
        /// </summary>
        /// <param name="items"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        private static void Merge(int[] items, int left, int right, int rightE)
        {
            int leftPos = left;
            int leftStart = left;
            int leftEnd = right - 1;
            int rightPos = right;
            int rightStart = right;
            int rightEnd = rightE;
            int fillPos = left;

            if (items.Count() <= 0 || left >= right )
                return;

            int[] toReturn = new int[items.Count()];
            items.CopyTo(toReturn, 0);
            
            while ((leftPos < items.Count() && rightPos < items.Count()) && (leftPos <= leftEnd && rightPos <= rightEnd))
            {
                
                // If implementing Comparators, they eventually go here

                // Merge left Item in
                if (items[leftPos] <= items[rightPos])
                {
                    toReturn[fillPos] = items[leftPos];
                    leftPos++;
                }

                // Merge right Item in
                else if (items[rightPos] < items[leftPos] )
                {
                    toReturn[fillPos] = items[rightPos];
                    rightPos++;
                }
                else
                {
                    throw new Exception("Could not merge");
                }
                
                //Console.WriteLine("Inner Merge State " + string.Join(",", items) + "----" + string.Join(",", toReturn));
                
                fillPos++;
            }

            while(leftPos < items.Count() && leftPos <= leftEnd)
            {
                toReturn[fillPos] = items[leftPos];
                leftPos++;
                fillPos++;
            }


            while(rightPos < items.Count() && rightPos <= rightEnd )
            {
                toReturn[fillPos] = items[rightPos];
                rightPos++;
                fillPos++;
            }


            //Console.WriteLine("Inner STATE: " + string.Join(",", toReturn));

            toReturn.CopyTo(items, 0);
        }
    }
}
