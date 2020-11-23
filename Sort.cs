using System;

namespace Algorithm
{
    public class Sort
    {
        /// <summary>
        /// Bubble sort is the simplest sorting algorithm that works by repeatedly swapping the adjacent elements if they are in wrong order
        /// </summary>
        public static void BubbleSort(int[] array)
        {
            int[] sorted = new int[array.Length];
            int temp;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (i == 0)
                        break;

                    if (array[i] < array[j]) // then swap
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;

                    }

                }

            }

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }



        }

        /// <summary>
        /// InsertSort algorithm sorts the numbers by shifting the bigger number to the right and the smaller to the left 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static void InsertSort(int[] array)
        {


            for (int i = 1; i < array.Length; i++)
            {
                int current = array[i];
                int index = i - 1;

                while (index >= 0 && array[index] > current) // shift on the right
                {
                    array[index + 1] = array[index];
                    index--;

                }

                array[index + 1] = current;
            }

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }



        /// <summary>
        /// One of the quickest sorting algorithm, it is based on the divide and conquer with one pivot and the partition of the array.
        /// </summary>
        /// <param name="array"></param>

        public static void QuickSort(int[] array) // best:O(n log(n))   Average: O(n log(n))    Worst: O(n^2)   Space complexity : O(log(n))
        {
            Sort_(array, 0, array.Length - 1);
        }
        private static void Sort_(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = Partition(array, start, end);

            Sort_(array, start, boundary - 1);
            Sort_(array, boundary + 1, end);

        }


        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int boundary = start - 1;

            for (int i = start; i <= end; i++)
            {
                if (array[i] <= pivot)
                {
                    boundary++;
                    Swap(array, ref array[i], ref array[boundary]);

                }

            }

            return boundary;
        }
        public static void Swap(int[] array, ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;

        }

        public static void MergeSort(int[] array)
        {
            if (array.Length < 2)       // this condition is really important in a recursive method! It says when the recursivity should stop, here when there's no element in the array or only one. 
                return;

            var middle = array.Length / 2;
            var left = new int[middle];

            for (int i = 0; i < middle; i++)
                left[i] = array[i];


            var right = new int[array.Length - middle];

            for (int i = middle; i < array.Length; i++)
                right[i - middle] = array[i]; // so that the elements of the array start from 0,1,2,3,4 etc..

            MergeSort(left);
            MergeSort(right);

            Merge(left, right, array);


        }


        private static void Merge(int[] left, int[] right, int[] result)
        {
            // i,j,k iterate over left, right and result.
            int i = 0, j = 0, k = 0;


            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    result[k++] = left[i++];
                else
                    result[k++] = right[j++];



            }

            while (i < left.Length)
                result[k++] = left[i++];
            // if one array has more array than the other, then the program should iterate over the rest of the element of the array.
            while (j < right.Length)
                result[k++] = right[j++];

        }


    }
}
