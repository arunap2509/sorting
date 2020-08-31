using System;
using System.Collections.Generic;

namespace Sorting
{
    public static class SortingAlgorithm1
    {   

        public static int [] MaxHeapSort(int [] arr)
        {
            /*
                Time complexity of heapify is O(log n)
                Time Complexity of building a heap is O(n)
                So time complexity is O(N logN)

                Space complexity is an in place algorithm
            */
            int n = arr.Length;

            for(int i = n / 2 - 1; i >=0; i--)
            {
                Heapify(arr, n, i);
            }

            for(int i = n - 1; i >= 0; i--)
            {
                // swapping first idx with last
                Swap(arr, 0, i);

                // calling max heap on reduced heap
                Heapify(arr, i, 0);
            }

            return arr;
        }

        static void Heapify(int [] arr, int arrLen, int idx)
        {
            int largest = idx;
            int leftChild = 2 * idx + 1;
            int rightChild = 2 * idx + 2;

            if(leftChild < arrLen && arr[leftChild] > arr[largest])
            {
                largest = leftChild;
            } 

            if(rightChild < arrLen && arr[rightChild] > arr[largest])
            {
                largest = rightChild;
            }

            if(largest != idx)
            {
                Swap(arr, largest, idx);
                Heapify(arr, arrLen, largest);
            }
        }

        static void Swap(int [] arr, int idx1, int idx2)
        {
            int temp = arr[idx1];
            arr[idx1] = arr[idx2];
            arr[idx2] = temp;
        }

        public static int [] MinHeapSort(int [] arr)
        {
            int n = arr.Length;

            for(int i = n / 2 - 1; i >=0; i--)
            {
                MinHeapHeapify(arr, n, i);
            }

            for(int i = n - 1; i >= 0; i--)
            {
                Swap(arr, i, 0);
                MinHeapHeapify(arr, i, 0);
            }

            return arr;
        }

        static void MinHeapHeapify(int [] arr, int arrLen, int idx)
        {
            int smallest = idx;
            int leftChild = 2 * idx + 1;
            int rightChild = 2 * idx + 2;

            if(leftChild < arrLen && arr[leftChild] < arr[smallest])
            {
                smallest = leftChild;
            }

            if(rightChild < arrLen && arr[rightChild] < arr[smallest])
            {
                smallest = rightChild;
            }

            if(smallest != idx)
            {
                Swap(arr, smallest, idx);
                Heapify(arr, arrLen, smallest);
            }
        }
    }
}