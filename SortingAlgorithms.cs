using System;

namespace Sorting
{
    public static class SortingAlgorithms
    {
        public static int [] BubbleSort(int [] arr)
        {
            /*
                WORST CASE = O(N2)
                BEST CASE = O(N)
            */
            bool noSwap = true;
            
            for(int i = arr.Length - 1; i >= 0; i--)
            {
                for(int j = 0; j < i; j++)
                {
                    if(arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;

                        noSwap = false;
                    }
                }

                if(noSwap)
                {
                    break;
                }
            }

            return arr;
        }

        public static int [] InsertionSort(int[] arr)
        {
            /*
                WORST CASE = O(N2)
                BEST CASE = O(N)
            */
            // for(int i = 1; i < arr.Length; i++)
            // {
            //     int j = i;

            //     while(j - 1 >= 0 && arr[j] < arr[j - 1])
            //     {
            //         var temp = arr[j];
            //         arr[j] = arr[j - 1];
            //         arr[j - 1] = temp;

            //         j--;
            //     }
            // }

            for(int i = 1; i < arr.Length; i++)
            {
                for(int j = i; j > 0; j--)
                {
                    if(arr[j] < arr[j-1])
                    {
                        var temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                }
            }

            return arr;
        }

        public static int [] SelectionSort(int [] arr)
        {
            /*
                WORST CASE = O(N2)
                BEST CASE = O(N2)
            */
            for(int i = 0; i < arr.Length; i++)
            {
                int min = i;

                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if(min != i)
                {
                    var temp = arr[min];
                    arr[min] = arr[i];
                    arr[i] = temp;
                }
            }
            return arr;
        }

        public static int [] MergeSort(int [] arr)
        {
            /*
                WORST CASE = O(N logN)
                SPACE = O(N)
            */
            if(arr.Length == 1) return arr;

            int mid = 0 + (arr.Length - 0) / 2;

            int [] left = new int [mid];
            int [] right = new int [arr.Length - mid];

            for(int i = 0; i < left.Length; i++)
            {
                left[i] = arr[i];
            }

            for(int i = 0; i < right.Length; i++)
            {
                right[i] = arr[mid + i];
            }

            var mergedArr =  MergeSortHelper(MergeSort(left), MergeSort(right));

            return mergedArr;
        }

        private static int [] MergeSortHelper(int [] leftArray, int [] rightArray)
        {
            int [] sortedArray = new int [leftArray.Length + rightArray.Length];

            int i = 0, j = 0, k = 0;

            while(i < leftArray.Length && j < rightArray.Length)
            {
                if(leftArray[i] < rightArray[j])
                {
                    sortedArray[k] = leftArray[i];
                    i++;
                }
                else
                {
                    sortedArray[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            while(i < leftArray.Length)
            {
                sortedArray[k] = leftArray[i];
                k++;
                i++;
            }

            while(j < rightArray.Length)
            {
                sortedArray[k] = rightArray[j];
                k++;
                j++;
            }

            return sortedArray;
        }

        public static int [] QuickSort(int [] arr)
        {
            QuickSortHelper(arr, 0, arr.Length - 1);
            
            return arr;
        }

        private static int [] QuickSortHelper(int [] arr, int startIdx, int endIdx)
        {
            if(startIdx >= endIdx) return arr;

            int pivot = startIdx;
            int left = startIdx + 1;
            int right = endIdx;

            while(left < right)
            {
                if(arr[left] > arr[pivot] && arr[right] < arr[pivot])
                {
                    var temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }

                if(arr[left] <= arr[pivot])
                {
                    left++;
                }

                if(arr[right] >= arr[pivot])
                {
                    right--;
                }
            }

            var temp1 = arr[right];
            arr[right] = arr[pivot];
            arr[pivot] = temp1;

            bool leftSubArrayIsSmaller = right - 1 - startIdx < endIdx - right + 1;

            if(leftSubArrayIsSmaller)
            {
                QuickSortHelper(arr, startIdx, right -1);
                QuickSortHelper(arr, right + 1, endIdx);
            } 
            else
            {
                QuickSortHelper(arr, right + 1, endIdx);
                QuickSortHelper(arr, startIdx, right -1);
            }

            return arr;
        }
    }
}