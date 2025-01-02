// Array Basics
using System;
using System.Runtime.CompilerServices;
class Test
{
    public static void Main(string[] args)
    {
        // string[] names = { "Hafiz", "Momo", "Bubu" };
        // Console.WriteLine("Print Name: ");

        // for (int i = 0; i < names.Length; i++)
        // {
        //     Console.WriteLine(names[i]);
        // }
        // // Using foreach
        // foreach (string name in names)
        // {
        //     Console.WriteLine(name);
        // }

        // // Multi dimentional array
        // int [,] age = {{1 , 2, 3}, {4, 5, 6}};

        // for(int i = 0; i < 2; i++) {
        //     for(int j = 0; j < 3; j++) {
        //         Console.Write($"{age[i, j]} ");
        //     }
        //     Console.WriteLine();
        // }


        // Jagged Array
        int [][] JaggedArray = new int[3][];

        JaggedArray[0] = new int[] {1, 2, 3};
        JaggedArray[1] = new int[] {1, 2};
        JaggedArray[2] = new int[] {1, 2, 3 , 4};

        for(int i = 0; i < JaggedArray.Length; i++) {
            for(int j = 0; j < JaggedArray[i].Length; j++) {
                Console.Write($"{JaggedArray[i][j]} ");
            }
            Console.WriteLine();
        }

        foreach(var row in JaggedArray) {
            foreach(var col in row) {
                Console.Write(col + " ");
            }
            Console.WriteLine();
        }

    }
}
