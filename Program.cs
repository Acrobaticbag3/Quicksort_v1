using System;
using System.Diagnostics;

namespace Quicksort_v1
{
    class Program
    {
        static void Main(string[] args) {
            int[] numberArray = new int[8000]; // Array with 1000 ints
            Random intRng = new Random(); // Random number generator
            

            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Randomly generated array:");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.ReadKey();

            for(int i = 0; i < 8000 ; i++) { // Assigns random values to the ints
                numberArray[i] = intRng.Next(1, 1001);
                Console.Write(numberArray[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Time to sort the array: ");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.ReadKey();
            
            var timer = Stopwatch.StartNew(); // Creates and starts a timer
            Quick_Sort(numberArray, 0, numberArray.Length-1);
		    foreach (var item in numberArray) {
                Console.Write(" " + item + " ");
            }
            timer.Stop();

            Console.WriteLine();
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.WriteLine("Array sorted! it took " + timer.ElapsedMilliseconds + " ms");
            Console.WriteLine("= = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =");
            Console.ReadKey();
        }
        // === === === === === === === === === \\
        // === ===The sorting algorithem== === \\
        // === === === === === === === === === \\
        private static void Quick_Sort(int[] numberArray, int left, int right) {
            if (left < right) {
                int pivot = Partition(numberArray, left, right);

                if (pivot > 1) {
                    Quick_Sort(numberArray, left, pivot - 1);
                }
                if (pivot + 1 < right) {
                    Quick_Sort(numberArray, pivot + 1, right);
                }
            }
        
        }

        private static int Partition(int[] numberArray, int left, int right) {
            int pivot = numberArray[left];
            while (true) {

                while (numberArray[left] < pivot) {
                    left++;
                }

                while (numberArray[right] > pivot) {
                    right--;
                }

                if (left < right) {
                    if (numberArray[left] == numberArray[right]) return right;

                    int temp = numberArray[left];
                    numberArray[left] = numberArray[right];
                    numberArray[right] = temp;
                } else {
                    return right;
                }
            }
        }
    }
}
