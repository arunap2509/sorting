namespace Sorting
{
    public static class SearchingAlgorithm
    {
        public static int LinerSearch(int [] arr, int target)
        {
            for(int i = 0; i < arr.Length; i++) 
            {
                if(arr[i] == target) 
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BinarySearch(int [] arr, int target)
        {
            int low = 0;
            int high = arr.Length;

            while (low < high)
            {
                int mid = low + (high - low) / 2;

                if(arr[mid] == target)
                {
                    return mid;
                }
                else if(arr[mid] > target)
                {
                    high = mid - 1;
                }
                else if(arr[mid] < target)
                {
                    low = mid + 1;
                }
            }

            return -1;
        }
    } 
}