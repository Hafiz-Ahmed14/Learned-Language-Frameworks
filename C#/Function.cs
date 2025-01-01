// Function 
using System;


class Test {
    public static int factorialofNum(int x) {
        int fact = 1;
        for(int i = 1; i <= x; i++) {
            fact *= i;
        }
        return fact;
    }

    public static int sum_of_num(int x) {
        int sum = 0;
        for(int i = 1; i <= x; i++) {
            sum += i;
        }
        return sum;
    }
    public static void Main(string [] args) {
        int a = 5, b = 10;
        Console.WriteLine(factorialofNum(a));
        Console.WriteLine(sum_of_num(b));
    }
}
