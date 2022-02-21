using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Random random= new Random();
            int n = 10000;
            
            for(int j=1; j<4; j++)
            {
                Stopwatch Stopwatch = new Stopwatch();
                int[] TestArray = new int[n];
                for (int i = 0; i < n; i++)
                {
                    TestArray[i] = random.Next(0, 100000);
                }
                Stopwatch.Start();
                MergeSortMT(TestArray, 0, n - 1, j);
                Stopwatch.Stop();
                Console.WriteLine($"Thread Count: {j * 2}");
                Console.WriteLine($"Execution of Program Completed, \n Execution Time: {Stopwatch.ElapsedMilliseconds} ms");
                Console.WriteLine("\n ---------------------------- \n \n");
            
            }
            Console.ReadLine();
        }


        // Simple Merge Sort 
        static void MergeSortMT(this int[] array, int initial, int final, int mtCount)
        {
            if (initial == final) return;

            if (mtCount > 0)
            {
                Task t = Task.Run(() =>
                {
                    MergeSortMT(array, initial, (initial + final) / 2, mtCount - 1);
                });
                MergeSortMT(array, (initial + final) / 2 + 1, final, mtCount - 1);

                t.Wait();
            }
            else
            {
                MergeSort(array, initial, (initial + final) / 2);
                MergeSort(array, (initial + final) / 2 + 1, final);
            }
            sort(array, initial, final);
        }
        static void MergeSort(this int[] array, int initial, int final)
        {
            if (initial == final) return;
            MergeSort(array, initial, (initial + final) / 2);
            MergeSort(array, (initial + final) / 2 + 1, final);
            sort(array, initial, final);
        }
        static void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;
            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];
            i = 0;
            j = 0;
            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }
            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }
        static void sort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                sort(arr, l, m);
                sort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }
   
    }
}
