using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmComparererCS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random n = new Random();
            runCopare(n);



        }
        static int[] CreateArray(int size, Random r)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = r.Next(1000, 100000);
            }
            return array;
        }
        static void menu()
        {
            Console.WriteLine("Alogorithm Comparerer");
            Console.WriteLine("=====================");
            Console.WriteLine("1: Set size of numerical Array");
            Console.WriteLine("2: Bubble Sort Time");
            Console.WriteLine("3: Merge sort time");
            Console.WriteLine("4: Linear Search time");
            Console.WriteLine("5: Binary Search time");
            Console.WriteLine("9: Quit");
            Console.Write("Enter Choice: ");

        }
        static void runCopare(Random r)
        {
            int[] a = null;
            int size = 1;
            Stopwatch sw = new Stopwatch();
            int menuChoice;
            int[] b = null;
            do
            {
                sw.Reset();

                menu();
                menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        Console.Write("Enter size of array to work with: ");
                        size = Convert.ToInt32(Console.ReadLine());
                        a = CreateArray(size, r);
                        break;

                    case 2:
                        b = a.ToArray();
                        sw.Start();
                        BubbleSort(a);
                        sw.Stop();
                        Console.WriteLine($"To BubbleSort an array with {size} values took {sw.ElapsedMilliseconds} millisecods");
                        break;
                    case 3:
                        sw.Start();
                        MergeSortRecursive(a, 0, a.Length - 1);
                        sw.Stop();
                        Console.WriteLine($"To MergeSort an array with {size} values took {sw.ElapsedMilliseconds} millisecods");

                        break;
                    case 4:

                        break;
                }

            } while (menuChoice != 9);
        }
        static void BubbleSort(int[] a)
        {
            int n = a.Length;
            bool swapped = false;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (a[i - 1] > a[i])
                    {
                        int temp = a[i - 1];
                        a[i - 1] = a[i];
                        a[i] = temp;
                        swapped = true;
                    }
                }
                n--;
            } while (swapped);
        }
        static void Merge(int[] a, int low, int mid, int high)
        {
            int i, j, k;
            int num1 = mid - low + 1;
            int num2 = high - mid;
            int[] L = new int[num1];
            int[] R = new int[num2];
            for (i = 0; i < num1; i++)
            {
                L[i] = a[low + i];
            }
            for (j = 0; j < num2; j++)
            {
                R[j] = a[mid + j + 1];
            }
            i = 0;
            j = 0;
            k = low;
            while (i < num1 && j < num2)
            {
                if (L[i] <= R[j])
                {
                    a[k] = L[i];
                    i++;
                }
                else
                {
                    a[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < num1)
            {
                a[k] = L[i];
                i++;
                k++;
            }
            while (j < num2)
            {
                a[k] = R[j];
                j++; k++;
            }
        }
        static void MergeSortRecursive(int[] a, int low, int high)
        {
            if (low < high)
            {
                int mid = (low + high) / 2;
                MergeSortRecursive(a, low, mid);
                MergeSortRecursive(a, mid + 1, high);
                Merge(a, low, mid, high);
            }
        }
        static int LinearSearchStopIfFound(int[] a, int numToFind)
        {
            int index = 0;
            do
            {
                if (a[index] == numToFind)
                {
                    return index;
                }
            } while (index < a.Length);
            return -1;
        }
        static bool LinearSearchIfFound(int[] a, int numToFind)
        {

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == numToFind)
                {
                    return true;
                }
            }
            return false;
        }
        static bool BinarySearch(int[] a, int numToFind)
        {
            bool found = false;
            int upper, lower, mid;
            upper = a.Length - 1;
            lower = 0;
           
            while (!found)
            {
                mid = upper + lower / 2;
                if (numToFind == a[mid])
                {
                    found = true;
                    return found;
                }else if(numToFind > a[mid])
                {
                    lower = mid + 1;
                }
                else
                {
                    upper = mid - 1;
                }

            }
            return found;
        }

    }
}

