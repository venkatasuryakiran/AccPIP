// C# implementation of iterative Binary Search
using System;

class Binarysearch
{
    // Partition function
    static int Partition(int[] arr, int low, int high)
    {

        // Choose the pivot
        int pivot = arr[high];

        // Index of smaller element and indicates 
        // the right position of pivot found so far
        int i = low - 1;

        // Traverse arr[low..high] and move all smaller
        // elements to the left side. Elements from low to 
        // i are smaller after every iteration
        for (int j = low; j <= high - 1; j++)
        {
            if (arr[j] < pivot)
            {
                i++;
                Swap(arr, i, j);
            }
        }

        // Move pivot after smaller elements and
        // return its position
        Swap(arr, i + 1, high);
        return i + 1;
    }

    // Swap function
    static void Swap(int[] arr, int i, int j)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    // The QuickSort function implementation
    static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {

            // pi is the partition return index of pivot
            int pi = Partition(arr, low, high);

            // Recursion calls for smaller elements
            // and greater or equals elements
            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    // Returns index of x if it is present in arr[]
    static int binarySearch(int[] arr, int x)
    {
        int low = 0, high = arr.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;

            // Check if x is present at mid
            if (arr[mid] == x)
                return mid;

            // If x greater, ignore left half
            if (arr[mid] < x)
                low = mid + 1;

            // If x is smaller, ignore right half
            else
                high = mid - 1;
        }

        // If we reach here, then element was
        // not present
        return -1;
    }

    // Driver code
    public static void Main()
    {
        Console.WriteLine("Enter numbers:");
        var numbers = Console.ReadLine().Split(' ').Select(token => int.Parse(token));

        // if you must have it as an array...
        int[] arr = numbers.ToArray();
        int n = arr.Length;

        Console.WriteLine("Enter number to searching");
        //var tosearch = ;
        int x =int.Parse(Console.ReadLine());

        //sorting before searching
        QuickSort(arr, 0, n - 1);

        int result = binarySearch(arr, x);
        if (result == -1)
            Console.WriteLine(
                "Element is not present in array");
        else
            Console.WriteLine("Element is present");
                             // + result);
    }
}