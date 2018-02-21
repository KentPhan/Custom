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
            Console.WriteLine("Problem 2: ");

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
    }
}
