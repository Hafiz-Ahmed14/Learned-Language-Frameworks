// Loop(for and while)

using System;

class Test
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        // for (int i = 1; i <= n; i++)
        // {
        //     Console.WriteLine(i);
        // }

        // int fact = 1;
        // int i = 1;
        // while(i <= n) {
        //     fact *= i;
        //     i++;
        // }

        // Console.WriteLine(fact);

        int even_sum = 0, odd_sum = 0;

        for(int i = 1; i <= n; i++) {
            if(i % 2 != 0) odd_sum += i;
            else even_sum += i;
        }

        Console.WriteLine(even_sum);
        Console.WriteLine(odd_sum);
    }
}
