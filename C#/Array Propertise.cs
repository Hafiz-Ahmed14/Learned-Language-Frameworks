// using System;

// class Test
// {
//     public static void Main(string[] args)
//     {
//         try
//         {
//             Console.WriteLine("Enter the size of the array:");
//             int n = int.Parse(Console.ReadLine());
            

//             int[] arr = new int[n];

//             Console.WriteLine($"Enter {n} integers:");
//             for (int i = 0; i < n; i++)
//             {
//                 arr[i] = int.Parse(Console.ReadLine());
//             }

//             Console.WriteLine("Array elements are:");
//             for (int i = 0; i < n; i++)
//             {
//                 Console.WriteLine(arr[i]);
//             }
//         }
//         catch (FormatException)
//         {
//             Console.WriteLine("Invalid input. Please enter valid integers.");
//         }
//         catch (OverflowException)
//         {
//             Console.WriteLine("Number too large. Please enter smaller integers.");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"An unexpected error occurred: {ex.Message}");
//         }
//     }
// }

// using System;
// using System.Globalization;

// class Test {

//     public static void printArray(int[] nums) {
//         Console.WriteLine("Elements are: ");
//         foreach(int x in nums) {
//             Console.Write(x + " ");
//         }
//     }
//     public static void Main(string[] args) {
//         int[] num = {1, 2, 28, 4, 5};

//         Console.WriteLine($"Length of the array: {num.Length}");
//         Console.WriteLine($"Dimention of the Array: {num.Rank}");
//         Console.WriteLine($"Maximum of the array: {num.Max()}");
//         Console.WriteLine($"Maximum of the array: {num.Min()}");
//         Console.WriteLine($"Maximum of the array: {num.Sum()}");
//         Console.WriteLine($"Maximum of the array: {num.Average()}");

//         printArray(num);

//         Console.WriteLine("After Sorting");
//         Array.Sort(num);
//         printArray(num);

//         Console.WriteLine("After Reverse");
//         Array.Reverse(num);
//         printArray(num);

//         int ind = Array.IndexOf(num, 28);
//         Console.WriteLine(ind);

//     }
// }

// Using params keyword
using System;

class Test {
    public static int sum(params int[] num) {
        int sum = 0;
        foreach(int x in num) {
            sum += x;
        }

        return sum;
    }
    public static void Main(string[] args) {
        Console.WriteLine(sum(10, 20));
        Console.WriteLine(sum(10, 20, 30));
        Console.WriteLine(sum(10, 20, 30, 40));
        Console.WriteLine(sum(10, 20, 30, 40, 50));
        
    }
}



