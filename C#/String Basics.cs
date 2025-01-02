// string

using System;

class Test {
    public static void Main(string[] args) {
        // string? s = Console.ReadLine();

        // //Console.WriteLine($"Length of the string is: {s.Length}");

        // bool ok = string.IsNullOrEmpty(s);
        // Console.WriteLine($"Is the string is Null or Empty: {ok}");

        // string upper = s.ToUpper();
        // Console.WriteLine($"The string is: {upper}");
        // string lower = s.ToLower();
        // Console.WriteLine($"The string is: {lower}");


        // string TrimString = s.Trim();
        // Console.WriteLine($"The string is: {TrimString}");

        // string SubStr = s.Substring(3);
        // Console.WriteLine($"The string is: {SubStr}");


        // string revstr = new string(s.Reverse().ToArray());
        // Console.WriteLine($"The string is: {revstr}");

        // var word = s.Split(" ");
        // foreach(var x in word) {
        //     Console.Write(x + " ");
        // }

        string s = "My name is Hafiz";
        int cnt_vowel = s.Count(c => "aeiouAEIOU".Contains(c));
        Console.WriteLine("Number of Vowels: " + cnt_vowel);

        int cnt_consonant = s.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));
        Console.WriteLine("Number of Consonant: " + cnt_consonant);

        int digit = s.Count(char.IsDigit);
        Console.WriteLine("Number of Digits: " + digit);
        int special_char = s.Count(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c));
        Console.WriteLine("Number of Special Character: " + cnt_consonant);  

    }
}
